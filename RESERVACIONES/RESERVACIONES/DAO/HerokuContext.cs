using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RESERVACIONES.BL;



namespace RESERVACIONES.DAO
{
    public class HerokuContext
    {

        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public HerokuContext(string baseUrl)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl.TrimEnd('/') + "/"; // Para leer la url
        }


        public async Task<List<Reservacion>> GetBookingIds()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "booking");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Reservacion>>(content);
        }

        // Método para obtener un elemento por su ID
        public async Task<Reservacion> GetBooking(int id)
        {
            var response = await _httpClient.GetAsync(_baseUrl + $"booking/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Reservacion>(content);
        }

        // Método para crear un nuevo elemento
        public async Task<Reservacion> CreateBooking(Reservacion newItem)
        {
            var json = JsonConvert.SerializeObject(newItem);
            var response = await _httpClient.PostAsync(_baseUrl + "booking", new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Reservacion>(content);
        }

        // Método para actualizar un elemento existente
        public async Task<Reservacion> UpdateItem(Reservacion updatedItem)
        {
            var json = JsonConvert.SerializeObject(updatedItem);
            var response = await _httpClient.PutAsync(_baseUrl + $"booking/{updatedItem.Id}", new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Reservacion>(content);
        }

        // Método para eliminar un elemento por su ID
        public async Task DeleteItem(int id)
        {
            var response = await _httpClient.DeleteAsync(_baseUrl + $"booking/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

