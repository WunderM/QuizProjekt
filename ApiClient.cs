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

        // Login
        public async Task<bool> LoginAsync(string username, string password)
        {
            try
            {
                var payload = new { Username = username, Password = password };
                var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{_baseUrl}/User/Login", content);

                if (response.IsSuccessStatusCode)
                {
                    return true; // Login erfolgreich
                }

                return false; // Login fehlgeschlagen
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Login: {ex.Message}");
                return false;
            }
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

         // Kategorien abrufen
        public async Task<List<string>> GetCategoriesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/QuizCategory");
                response.EnsureSuccessStatusCode(); // Überprüfen, ob der Statuscode erfolgreich ist

                var responseData = await response.Content.ReadAsStringAsync();
                var categories = JsonSerializer.Deserialize<List<Category>>(responseData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return categories?.Select(c => c.Title).ToList() ?? new List<string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Abrufen der Kategorien: {ex.Message}");
                return new List<string>();
            }
        }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<object> Quizzes { get; set; } // Typ anpassen, falls bekannt
    }
}
