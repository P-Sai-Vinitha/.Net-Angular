using AppUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace AppUI.Controllers
{
    [Route("EventDetails")]
    public class EventDetailsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EventDetailsController(IHttpClientFactory httpClientFactory)
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


        [Route("EventList", Name = "EventList")]
        public async Task<IActionResult> GetAllEvents()
        {
            var client = GetClient();
            var events = await client.GetFromJsonAsync<List<EventDetails>>("api/v2.0/EventDetails/GetAll");
            return View(events);
        }

        [HttpGet]
        [Route("AddEvent", Name = "AddEvent")]
        public IActionResult AddEvent()
        {
            return View();
        }


        [HttpPost]
        [Route("SaveEvent")]
        public async Task<IActionResult> SaveEvent(EventDetails eventDetails)
        {
            var client = GetClient();
            var response = await client.PostAsJsonAsync("api/v2.0/EventDetails/Add", eventDetails);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToRoute("EventList");
            }
            return View(eventDetails);
        }

        [Route("UpdateEvent/{id}", Name = "UpdateEvent")]
        public async Task<IActionResult> UpdateEvent(int id)
        {
            var client = GetClient();
            var eventDetails = await client.GetFromJsonAsync<EventDetails>($"api/v2.0/EventDetails/GetById/{id}");
            return View(eventDetails);
        }

        [HttpPost]
        [Route("EditEvent", Name = "EditEvent")]
        public async Task<IActionResult> UpdateEvent(EventDetails eventDetails)
        {
            var client = GetClient();
            var response = await client.PutAsJsonAsync("api/v2.0/EventDetails/Update", eventDetails);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToRoute("EventList");
            }
            return View(eventDetails);
        }


        [Route("DeleteEvent/{id}", Name = "DeleteEvent")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var client = GetClient();
            var evt = await client.GetFromJsonAsync<EventDetails>($"api/v2.0/EventDetails/GetById/{id}");
            return View(evt);
        }

        [HttpPost]
        [Route("RemoveEvent", Name = "RemoveEvent")]
        public async Task<IActionResult> DeleteEvent(EventDetails eventDetails)
        {
            var client = GetClient();
            var token = HttpContext.Session.GetString("jwttoken");
            token = token.Trim('"');
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await client.DeleteAsync($"api/v2.0/EventDetails/Delete/{eventDetails.EventId}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToRoute("EventList");
            }
            else
            {
                return View();
            }
        }


        [Route("GetById/{id}", Name = "GetEventById")]
        public async Task<IActionResult> GetEventsById(int id)
        {
            var client = GetClient();
            var evt = await client.GetFromJsonAsync<EventDetails>($"api/v2.0/EventDetails/GetById/{id}");
            return View(evt);
        }
    }
}