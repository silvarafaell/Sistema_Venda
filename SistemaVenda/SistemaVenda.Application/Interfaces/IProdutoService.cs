using SistemaVenda.Application.Extensions;
using SistemaVenda.Domain.Models;

namespace SistemaVenda.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<OperationResult> Create(Produto produto);

        Task<OperationResult> FindAll();

        Task<OperationResult> FindById(int id);

        Task<OperationResult> Delete(int id);

        Task<OperationResult> Update(int id);
        Task<OperationResult> Update(int id, bool reservation);
    }

}
