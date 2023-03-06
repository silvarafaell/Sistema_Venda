using SistemaVenda.Domain.Interfaces;
using SistemaVenda.Domain.Models;

namespace SistemaVenda.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProdutoRepository
    {
        public ProductRepository(Context context) : base(context)
        {
        }
    }
}
