using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersCrudController : ControllerBase
    {
        private readonly IUsersCrudRepository _repo;
        private readonly IMapper _mapper;

        public UsersCrudController(IUsersCrudRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

         //GET All Users: api/UsersCrud
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {

            var users = await _repo.GetUsers();
            var usertoreturn = _mapper.Map<IEnumerable<UserForListDto>>(users);

            return Ok(usertoreturn);
        }


        //GET Single User: api/UsersCrud/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(long id)
        {
            var user = await _repo.GetUser(id);

            var usertoreturn = _mapper.Map<UserForDetailsDto>(user);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(usertoreturn);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(long id, UserToUpdateDto userToUpdateDto)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

             var userFromRepo = await _repo.GetUser(id);

             _mapper.Map(userToUpdateDto , userFromRepo);

             if(await _repo.SaveAll())
             return NoContent();

             throw new Exception($"updating user {id} failed on save");
        }

    }
}