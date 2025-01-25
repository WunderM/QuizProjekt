using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SoftwareEngineering
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7160/api/User"; // Basis-URL der API

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

                var response = await _httpClient.PostAsync($"{_baseUrl}/Login", content);

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

                var response = await _httpClient.PostAsync($"{_baseUrl}/Register", content);

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
    }
}
