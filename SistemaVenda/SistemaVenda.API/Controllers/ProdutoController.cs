using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Application.Interfaces;
using SistemaVenda.Application.ViewModels;
using SistemaVenda.Domain.Models;

namespace SistemaVenda.API.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class ProdutoController : ApiController
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        => _service = service;

        [HttpPost]
        [ProducesResponseType(typeof(Produto), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Post(Produto produto)
         => CustomResponse(await _service.Create(produto));

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Produto>), 200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Produto>>> Get()
            => CustomResponse(await _service.FindAll());

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Produto), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Produto>> Get(int id)
            => CustomResponse(await _service.FindById(id));

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Produto), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Produto>> Delete(int id)
            => CustomResponse(await _service.Delete(id));

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Produto), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Produto>> Update(int id)
           => CustomResponse(await _service.Update(id));

    }
}
