using AppUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace AppUI.Controllers
{
    [Route("ParticipantEventDetails")]
    public class ParticipantEventDetailsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ParticipantEventDetailsController(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        [NonAction]
        public HttpClient GetClient()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var token = HttpContext.Session.GetString("jwttoken");
            if (!string.IsNullOrEmpty(token))
            {
                token = token.Trim('"');
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return client;
        }

        [Route("ParticipantEventList", Name = "ParticipantEventList")]
        public async Task<IActionResult> GetAllParticipantEventDetails()
        {
            var client = GetClient();
            var participantEvents = await client.GetFromJsonAsync<List<ParticipantEventDetails>>("api/v3.0/ParticipantEventDetails/GetAll");
            return View(participantEvents);
        }

        [Route("Register", Name = "RegisterParticipantEvent")]
        public IActionResult AddParticipantEventDetails()
        {
            return View();
        }

        [HttpPost]
        [Route("Register", Name = "RegisterParticipantEventPost")]
        public async Task<IActionResult> AddParticipantEventDetails(ParticipantEventDetails participantEventDetails)
        {
            var client = GetClient();
            var response = await client.PostAsJsonAsync("api/v3.0/ParticipantEventDetails/Register", participantEventDetails);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToRoute("ParticipantEventList");
            }
            return View(participantEventDetails);
        }

        [Route("Update/{id}", Name = "UpdateParticipantEvent")]
        public async Task<IActionResult> UpdateParticipantEventDetails(int id)
        {
            var client = GetClient();
            var data = await client.GetFromJsonAsync<ParticipantEventDetails>($"api/v3.0/ParticipantEventDetails/GetById/{id}");
            return View(data);
        }

        [HttpPost]
        [Route("Update", Name = "EditParticipantEvent")]
        public async Task<IActionResult> UpdateParticipantEventDetails(ParticipantEventDetails participantEventDetails)
        {
            var client = GetClient();
            var response = await client.PutAsJsonAsync("api/v3.0/ParticipantEventDetails/Update", participantEventDetails);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToRoute("ParticipantEventList");
            }
            return View(participantEventDetails);
        }

        [Route("Delete/{id}", Name = "DeleteParticipantEventDetails")]
        public async Task<IActionResult> DeleteParticipantEventDetails(int id)
        {
            var client = GetClient();
            var data = await client.GetFromJsonAsync<ParticipantEventDetails>($"api/v3.0/ParticipantEventDetails/GetById/{id}");
            return View(data);
        }

        [HttpPost]
        [Route("Delete", Name = "DeleteParticipantEventDetailsConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int participantId)
        {
            var client = GetClient();
            var response = await client.DeleteAsync($"api/v3.0/ParticipantEventDetails/Delete/{participantId}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToRoute("ParticipantEventList");
            }
            return View();
        }

        [Route("GetById/{id}", Name = "GetParticipantEventDetailsById")]
        public async Task<IActionResult> GetParticipantEventDetailsById(int id)
        {
            var client = GetClient();
            var evt = await client.GetFromJsonAsync<ParticipantEventDetails>($"api/v3.0/ParticipantEventDetails/GetById/{id}");
            return View(evt);
        }
    }
}