using Microsoft.EntityFrameworkCore;
using SistemaVenda.Domain.Interfaces;
using SistemaVenda.Domain.Models;

namespace SistemaVenda.Data.Repositories
{
    public class AccountRepository : Repository<User>, IAccountRepository
    {
        public AccountRepository(Contexto context) : base(context)
        {
        }

        public async Task<User> GetUserName(string name)
         => await _currentSet
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(x => x.Name == name);
    }
}
