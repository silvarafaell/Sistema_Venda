using AutoMapper;
using SistemaVenda.Application.Extensions;
using SistemaVenda.Application.Interfaces;
using SistemaVenda.Domain.Interfaces;
using SistemaVenda.Domain.Models;
using System.Net;

namespace SistemaVenda.Application.Services
{
    public class ProductService : Service, IProductService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProductService(IProdutoRepository produtoRepository, IMapper mapper) : base(mapper)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<OperationResult> Create(Product product)
        {
            if (product is null)
                return Error(ErrorMessages.IdNotFoundError(), HttpStatusCode.NotFound);

            await _produtoRepository.InsertAsync(product);

            return Success();
        }

        public async Task<OperationResult> Delete(int id)
        {
            var product = await _produtoRepository.GetByIdAsync(id);

            if (product is null)
                return Error(ErrorMessages.IdNotFoundError(), HttpStatusCode.NotFound);

            await _produtoRepository.DeleteAsync(product);

            return Success(product);
        }

        public async Task<OperationResult> FindAll()
        {
            var listproducts = await _produtoRepository.GetAllAsync();

            var product = listproducts.Where(s => s.Reserved == false);

            if (!product.Any())
                return Error(ErrorMessages.IdNotFoundError(), HttpStatusCode.NotFound);

            return Success(product);
        }

        public async Task<OperationResult> FindById(int id)
        {
            var product = await _produtoRepository.GetByIdAsync(id);

            if (product is null)
                return Error(ErrorMessages.IdNotFoundError(), HttpStatusCode.NotFound);

            return Success(product);
        }

        public async Task<OperationResult> Update(Product product)
        {
            var entity = await _produtoRepository.GetByIdAsync(product.Id);

            if (entity is null)
                return Error(ErrorMessages.IdNotFoundError(), HttpStatusCode.NotFound);

            await _produtoRepository.UpdateAsync(entity);

            return Success(entity);
        }

        public async Task<OperationResult> Update(int id, bool reservation)
        {
            var product = await _produtoRepository.GetByIdAsync(id);

            if (product is null)
                return Error(ErrorMessages.IdNotFoundError(), HttpStatusCode.NotFound);    

            product.Reserved = reservation;

            await _produtoRepository.UpdateAsync(product);

            return Success(product);
        }
    }
}
