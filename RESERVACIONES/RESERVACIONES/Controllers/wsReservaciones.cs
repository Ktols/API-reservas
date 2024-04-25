using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESERVACIONES.BL;
using RESERVACIONES.DAO;
using System.Text.Json;

namespace RESERVACIONES.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ReservacionesController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public ReservacionesController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservaciones()
        {
            var client = _clientFactory.CreateClient("RestfulBooker");
            var response = await client.GetAsync("booking");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var reservaciones = JsonSerializer.Deserialize<List<Reservacion>>(jsonResponse);
                return Ok(reservaciones);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservacion(int id)
        {
            var client = _clientFactory.CreateClient("RestfulBooker");
            var response = await client.GetAsync($"booking/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var reservacion = JsonSerializer.Deserialize<Reservacion>(jsonResponse);
                return Ok(reservacion);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservacion(Reservacion reservacion)
        {
            var client = _clientFactory.CreateClient("RestfulBooker");
            var jsonContent = JsonSerializer.Serialize(reservacion);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("booking", content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var reservacionCreada = JsonSerializer.Deserialize<Reservacion>(jsonResponse);
                return CreatedAtAction(nameof(GetReservacion), new { id = reservacionCreada.Id }, reservacionCreada);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservacion(int id, Reservacion reservacion)
        {
            var client = _clientFactory.CreateClient("RestfulBooker");
            var jsonContent = JsonSerializer.Serialize(reservacion);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"booking/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservacion(int id)
        {
            var client = _clientFactory.CreateClient("RestfulBooker");
            var response = await client.DeleteAsync($"booking/{id}");

            if (response.IsSuccessStatusCode)
            {
                return NoContent();
            }

            return NotFound();
        }
    }

}

