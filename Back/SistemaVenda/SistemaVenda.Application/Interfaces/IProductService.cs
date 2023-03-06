using SistemaVenda.Application.Extensions;
using SistemaVenda.Domain.Models;

namespace SistemaVenda.Application.Interfaces
{
    public interface IProductService
    {
        Task<OperationResult> Create(Product produto);

        Task<OperationResult> FindAll();

        Task<OperationResult> FindById(int id);

        Task<OperationResult> Delete(int id);

        Task<OperationResult> Update(Product product);
        Task<OperationResult> Update(int id, bool reservation);
    }

}
