﻿namespace RPGCalendar.Api.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core.Dto;
    using Core.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService service)
        {
            this._userService = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<User?> GetPlayer() => await _userService.GetPlayer();

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<List<User>> GetAllPlayers() => await _userService.GetPlayersList();

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<User?> GetUser(int id)
        {
            User? user = await _userService.GetUserByIdAsync(id);
            if (user is null)
            {
                return null;
            }
            return user;
        }
    }
}
