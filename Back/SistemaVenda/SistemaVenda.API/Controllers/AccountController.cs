using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Application.Interfaces;
using SistemaVenda.Application.ViewModels;
using SistemaVenda.Domain.Models;

namespace SistemaVenda.API.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        => _service = service;

        [HttpPost("Register")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Register(User user)
         => CustomResponse(await _service.Register(user));

        [HttpPost("Login")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Login(User user)
         => CustomResponse(await _service.Login(user));


        [HttpGet("GetUser/{userName}")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<User>> Get(string userName)
            => CustomResponse(await _service.GetUser(userName));


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<User>> Update(int id)
           => CustomResponse(await _service.Update(id));
    }
}
