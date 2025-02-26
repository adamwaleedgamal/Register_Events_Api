using login.DTOs;
using login.Models;
using login.Repo.Events_Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")] // Ensuring only Admins can manage events
    public class EventsController : ControllerBase
    {
        private readonly IEvents _repo;
        public EventsController(IEvents repo)
        {
            _repo = repo;
        }

        [HttpPost("AddEvent")]
        public IActionResult Add([FromBody] EventsAdd addd)
        {
            if (addd == null)
                return BadRequest("Invalid event data");

            _repo.AddEvent(addd);
            return Ok(new { message = "Added Successfully" });
        }

        [HttpGet("GetAllEvents")]
        [AllowAnonymous] // Allow public access for event listing
        public IActionResult Get()
        {
            var events = _repo.GetEvent();
            return Ok(events);
        }

        [HttpDelete("DeleteEvent/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _repo.DeleteEvent(id);
            if (!response.Status)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPut("UpdateEvent/{id}")]
        public IActionResult Update(int id, [FromBody] EventsAdd eventsDTO)
        {
            if (eventsDTO == null)
                return BadRequest("Invalid event data");

            var response = _repo.UpdateEvent(eventsDTO, id);
            if (!response.Status)
                return NotFound(response);

            return Ok(response);
        }
    }
}
