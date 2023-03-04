using SistemaVenda.Application.Dtos;
using SistemaVenda.Application.Extensions;
using SistemaVenda.Domain.Models;

namespace SistemaVenda.Application.Interfaces
{
    public interface IAccountService
    {
        Task<OperationResult> Register(User user);

        Task<OperationResult> GetUser(string userName);

        Task<OperationResult> Login(User user);

        Task<OperationResult> Update(int id);
    }
}
