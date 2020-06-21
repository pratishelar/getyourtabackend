using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.Dtos;
using backend.Helpers;
using backend.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace backend.Controllers
{
    [Authorize]
    [Route("api/users/{userId}/events")]
    [ApiController]

    public class EventsController : ControllerBase
    {
        private readonly IEventCrudRepository _repo;
        private readonly IMapper _mapper;

        public EventsController(IEventCrudRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }

        [HttpGet("{Id}", Name = "GetEvent")]
        public async Task<IActionResult> GetEvent(int Id)
        {
            var eventFromRepo = await _repo.GetEvent(Id);

            var eventtosend = _mapper.Map<EventForReturnDto>(eventFromRepo);

            return Ok(eventtosend);
        }

        //GET All events: api/users/1/events
        [HttpGet]
        public async Task<IActionResult> GetEvents([FromQuery] EventParams eventParams)
        {

            var eventFromRepo = await _repo.GetEvents(eventParams);
            
            Response.AddPagination(eventFromRepo.CurrentPage, eventFromRepo.PageSize, 
                    eventFromRepo.TotalCount, eventFromRepo.TotalPages );

            var eventsToReturn = _mapper.Map<IEnumerable<EventForReturnDto>>(eventFromRepo);

            return Ok(eventsToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddEventForUser(int userId, EventForReturnDto eventForReturnDto)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            var eventToAdd = _mapper.Map<Event>(eventForReturnDto);

            eventToAdd.UserId = userId;

            var createdEvent = await _repo.AddEvent(eventToAdd);

            return CreatedAtRoute("GetEvent", new { userId = userId, Id = eventToAdd.Id }, createdEvent);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent(int userId, int id)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            var eventFromRepo = await _repo.GetEvent(id);

            if (eventFromRepo != null)
            {
                _repo.Delete(eventFromRepo);
            }

            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Failed to delete Event");
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int userId, int id, EventForReturnDto eventForReturnDto)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            var eventFromRepo = await _repo.GetEvent(id);

            _mapper.Map(eventForReturnDto, eventFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"updating user {id} failed on save");
        }


    }
}