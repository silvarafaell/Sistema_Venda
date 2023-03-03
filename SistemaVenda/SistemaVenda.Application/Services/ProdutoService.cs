using AutoMapper;
using SistemaVenda.Application.Extensions;
using SistemaVenda.Application.Interfaces;
using SistemaVenda.Domain.Interfaces;
using SistemaVenda.Domain.Models;
using System.Net;

namespace SistemaVenda.Application.Services
{
    public class ProdutoService : Service, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper) : base(mapper)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<OperationResult> Create(Produto produto)
        {
            if (produto is null)
                return Error(ErrorMessages.IdNotFoundError(), HttpStatusCode.NotFound);

            await _produtoRepository.InsertAsync(produto);

            return Success();
        }

        public async Task<OperationResult> Delete(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);

            if (produto is null)
                return Error(ErrorMessages.IdNotFoundError(), HttpStatusCode.NotFound);

            await _produtoRepository.DeleteAsync(produto);

            return Success(produto);
        }

        public async Task<OperationResult> FindAll()
        {
            var produtos = await _produtoRepository.GetAllAsync();

            if (!produtos.Any())
                return Error(ErrorMessages.IdNotFoundError(), HttpStatusCode.NotFound);

            return Success(produtos);
        }

        public async Task<OperationResult> FindById(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);

            if (produto is null)
                return Error(ErrorMessages.IdNotFoundError(), HttpStatusCode.NotFound);

            return Success(produto);
        }

        public async Task<OperationResult> Update(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);

            if (produto is null)
                return Error(ErrorMessages.IdNotFoundError(), HttpStatusCode.NotFound);

            await _produtoRepository.UpdateAsync(produto);

            return Success(produto);
        }

        public async Task<OperationResult> Update(int id, bool reservation)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);

            if (produto is null)
                return Error(ErrorMessages.IdNotFoundError(), HttpStatusCode.NotFound);

            if (produto.Reserved == true)
                return Error(ErrorMessages.ProductReservation(), HttpStatusCode.NotFound);

            produto.Reserved = reservation;

            await _produtoRepository.UpdateAsync(produto);

            return Success(produto);
        }
    }
}
