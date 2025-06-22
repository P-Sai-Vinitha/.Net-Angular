using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer.Controllers
{
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/[controller]")]  //http://localhost:5015/api/v3.0/ParticipantEventDetails/
    [ApiController]
    public class ParticipantEventDetailsController : ControllerBase
    {
        private readonly IParticipantEventDetailsRepo<ParticipantEventDetails> _participantRepo;

        public ParticipantEventDetailsController(IParticipantEventDetailsRepo<ParticipantEventDetails> participantRepo)
        {
            _participantRepo = participantRepo;
        }

        [HttpGet("GetAll")]
        
        public IActionResult GetAllParticipantEvents()
        {
            var list = _participantRepo.GetAllParticipantEvents();
            if (list != null && list.Any())
                return Ok(list);
            return NotFound("No participant records found.");
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetParticipantEventById(int id)
        {
            var participant = _participantRepo.GetParticipantEventById(id);
            if (participant != null)
                return Ok(participant);
            return NotFound($"Participant record with ID {id} not found.");
        }

        [HttpPost("Register")]
        public IActionResult AddParticipantEvent([FromBody] ParticipantEventDetails participant)
        {
            if (ModelState.IsValid)
            {
                participant.Id = 0;
                var added = _participantRepo.AddParticipantEvent(participant);
                return Created(HttpContext.Request.Path, added);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("Update")]
        public IActionResult UpdateParticipantEvent([FromBody] ParticipantEventDetails participant)
        {
            if (ModelState.IsValid)
            {
                var updated = _participantRepo.UpdateParticipantEvent(participant);
                if (updated != null)
                    return Ok(updated);
                return NotFound($"Participant record with ID {participant.Id} not found.");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteParticipantEvent(int id)
        {
            var deleted = _participantRepo.DeleteParticipantEvent(id);
            if (deleted != null)
                return Ok(deleted);
            return NotFound($"Participant record with ID {id} not found.");
        }
    }
}
