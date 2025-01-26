using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;

namespace SoftwareEngineering
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7160/api"; // Basis-URL der API

        public ApiClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<long?> LoginAsync(string username, string password)
        {
            try
            {
                var payload = new { Username = username, Password = password };
                var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{_baseUrl}/User/Login", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<LoginResponse>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return result?.UserId; // Rückgabe der User ID
                }

                return null; // Login fehlgeschlagen
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Login: {ex.Message}");
                return null;
            }
        }

        public class LoginResponse
        {
            public long UserId { get; set; }
            public string Message { get; set; }
        }



        // Registrierung
        public async Task<bool> RegisterAsync(string username, string password)
        {
            try
            {
                var payload = new { Username = username, Password = password };
                var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{_baseUrl}/User/Register", content);

                if (response.IsSuccessStatusCode)
                {
                    return true; // Registrierung erfolgreich
                }

                return false; // Registrierung fehlgeschlagen
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler bei der Registrierung: {ex.Message}");
                return false;
            }
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/QuizCategory");
                response.EnsureSuccessStatusCode(); // Überprüfen, ob der Statuscode erfolgreich ist

                var responseData = await response.Content.ReadAsStringAsync();
                var categories = JsonSerializer.Deserialize<List<Category>>(responseData, new JsonSerializerOptions
                {
                    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
                    PropertyNameCaseInsensitive = true

                });

                return categories ?? new List<Category>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Abrufen der Kategorien: {ex.Message}");
                return new List<Category>();
            }
        }


        public async Task<List<QuizQuestion>> GetQuizQuestionsAsync(long quizId, int limit = 20)
        {
            try
            {
                // Anfrage an den API-Endpunkt mit der QuizId und der Anzahl der Fragen
                var response = await _httpClient.GetAsync($"{_baseUrl}/QuizQuestion/{quizId}?limit={limit}");
                response.EnsureSuccessStatusCode();

                // Antwortdaten deserialisieren
                var responseData = await response.Content.ReadAsStringAsync();

                var wrapper = JsonSerializer.Deserialize<QuizQuestionWrapper>(responseData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var quizzes = wrapper?.Questions ?? new List<QuizQuestion>();

                return quizzes ?? new List<QuizQuestion>();
            }// Rückgabe der Highscore-Liste
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Abrufen der Quizfragen: {ex.Message}");
                return new List<QuizQuestion>();
            }
        }

        public async Task<SubmitAnswersResult> SubmitAnswersAsync(long quizId, List<AnswerSubmission> answers)
        {
            try
            {
                // Wrapper erstellen
                var request = new AnswerSubmissionRequest
                {
                    UserId = App.SharedViewModel.UserID,
                    QuizId = quizId,
                    Answers = answers
                };

                // Wrapper serialisieren
                var json = JsonSerializer.Serialize(request, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                // HTTP-Request erstellen
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{_baseUrl}/QuizQuestion/SubmitAnswers", content);

                if (response.IsSuccessStatusCode)
                {
                    // Server-Antwort lesen
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    // Antwort deserialisieren
                    var result = JsonSerializer.Deserialize<SubmitAnswersResult>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return result; // Ergebnis zurückgeben
                }

                Console.WriteLine($"Server-Fehler: {response.StatusCode}");
                return null; // Kein gültiges Ergebnis
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Übermitteln der Antworten: {ex.Message}");
                return null; // Bei Fehler kein Ergebnis
            }
        }



        public async Task<List<Quiz>> GetAvailableQuizzesAsync(long categoryId)
        {
            try
            {
                // API-Endpunkt für verfügbare Quizzes basierend auf einer Kategorie
                string endpoint = $"{_baseUrl}/Quiz/ByCategory/{categoryId}";

                // Sende GET-Anfrage
                var response = await _httpClient.GetAsync(endpoint);

                // Überprüfen, ob die Anfrage erfolgreich war
                response.EnsureSuccessStatusCode();

                // JSON-Antwort lesen
                var jsonResponse = await response.Content.ReadAsStringAsync();

                // JSON in Liste von Quiz-Objekten deserialisieren
                var wrapper = JsonSerializer.Deserialize<QuizWrapper>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var quizzes = wrapper?.Quizzes ?? new List<Quiz>();

                return quizzes ?? new List<Quiz>(); // Rückgabe der Quiz-Liste
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Abrufen der Quizzes: {ex.Message}");
                return new List<Quiz>(); // Leere Liste zurückgeben, wenn ein Fehler auftritt
            }
        }

        public async Task<List<Highscore>> GetHighscoresAsync(long quizId)
        {
            try
            {
                // Endpunkt für Highscores eines bestimmten Quizzes
                string endpoint = $"{_baseUrl}/Highscore/Quiz/{quizId}";

                // Sende GET-Anfrage
                var response = await _httpClient.GetAsync(endpoint);

                // Überprüfen, ob die Anfrage erfolgreich war
                response.EnsureSuccessStatusCode();

                // JSON-Antwort lesen
                var jsonResponse = await response.Content.ReadAsStringAsync();

                // JSON in Liste von Quiz-Objekten deserialisieren
                var wrapper = JsonSerializer.Deserialize<HighscoreWrapper>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var highscores = wrapper?.Highscores ?? new List<Highscore>();

                return highscores ?? new List<Highscore>(); // Rückgabe der Highscore-Liste
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Abrufen der Highscores: {ex.Message}");
                return new List<Highscore>(); // Rückgabe einer leeren Liste bei Fehler
            }
        }


    }

    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
