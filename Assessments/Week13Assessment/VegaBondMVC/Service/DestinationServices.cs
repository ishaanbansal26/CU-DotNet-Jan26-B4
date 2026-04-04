using System.Net.Http.Json;
using VagaBondAPI.Models;

namespace VegaBondMVC.Service
{
    public class DestinationServices
    {
        private readonly HttpClient _httpClient;

        public DestinationServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Destination>> GetAllAsync()
        {
            var resp = await _httpClient.GetAsync("/api/Destinations");
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<List<Destination>>() ?? new List<Destination>();
        }

        public async Task<Destination?> GetByIdAsync(int id)
        {
            var resp = await _httpClient.GetAsync($"/api/Destinations/{id}");
            if (!resp.IsSuccessStatusCode) return null;
            return await resp.Content.ReadFromJsonAsync<Destination>();
        }

        public async Task<bool> CreateAsync(Destination destination)
        {
            var resp = await _httpClient.PostAsJsonAsync("/api/Destinations", destination);
            return resp.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, Destination destination)
        {
            var resp = await _httpClient.PutAsJsonAsync($"/api/Destinations/{id}", destination);
            return resp.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var resp = await _httpClient.DeleteAsync($"/api/Destinations/{id}");
            return resp.IsSuccessStatusCode;
        }
    }
}

