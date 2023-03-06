using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Application.Interfaces;
using SistemaVenda.Application.ViewModels;
using SistemaVenda.Domain.Models;

namespace SistemaVenda.API.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class ProductController : ApiController
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        => _service = service;

        [HttpPost]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Post(Product produto)
         => CustomResponse(await _service.Create(produto));

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), 200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
            => CustomResponse(await _service.FindAll());

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Product>> Get(int id)
            => CustomResponse(await _service.FindById(id));

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Product>> Delete(int id)
            => CustomResponse(await _service.Delete(id));

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Product>> Update(Product product)
           => CustomResponse(await _service.Update(product));

        [HttpPut("reservation")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Product>> Update(int id, bool resevation)
           => CustomResponse(await _service.Update(id, resevation));

    }
}
