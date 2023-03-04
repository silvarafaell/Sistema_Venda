using SistemaVenda.Domain.Models;

namespace SistemaVenda.Domain.Interfaces
{
    public interface IAccountRepository : IRepository<User>
    {
        Task<User> GetUserName(string name);
    }
}
