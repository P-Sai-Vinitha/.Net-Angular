using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]  //http://localhost:5015/api/v2.0/EventDetails/
    [ApiController]
    public class EventDetailsController : ControllerBase
    {
        private readonly IEventDetailsRepo<EventDetails> _eventRepo;

        public EventDetailsController(IEventDetailsRepo<EventDetails> eventRepo)
        {
            _eventRepo = eventRepo;
        }

        [HttpGet]
        [Route("GetAll")]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetAllEvents()
        {
            var events = _eventRepo.GetAllEvents();
            if (events != null && events.Count > 0)
                return Ok(events);
            return NotFound("No events found.");
        }

        [HttpGet]
        [Route("GetByCategory/{category}")]
        public IActionResult GetByCategory(string category)
        {
            var events = _eventRepo.GetEventsByCategory(category);
            if (events != null && events.Count > 0)
                return Ok(events);
            return NotFound($"No events found for category '{category}'.");
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddEvent([FromBody] EventDetails eventDetails)
        {
            if (ModelState.IsValid)
            {
                var added = _eventRepo.AddEvent(eventDetails);
                return Created(HttpContext.Request.Path, added);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateEvent([FromBody] EventDetails eventDetails)
        {
            if (ModelState.IsValid)
            {
                var updated = _eventRepo.UpdateEvent(eventDetails);
                if (updated != null)
                    return Ok(updated);
                return NotFound("Event not found.");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteEvent(int id)
        {
            var deleted = _eventRepo.DeleteEvent(id);
            if (deleted != null)
                return Ok(deleted);
            return NotFound("Event not found.");
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var evt = _eventRepo.GetEventById(id);
            if (evt != null)
                return Ok(evt);
            return NotFound("Event not found.");
        }

    }
}
