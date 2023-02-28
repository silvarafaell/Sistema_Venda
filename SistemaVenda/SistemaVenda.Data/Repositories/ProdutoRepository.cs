using SistemaVenda.Domain.Interfaces;
using SistemaVenda.Domain.Models;

namespace SistemaVenda.Data.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(Contexto context) : base(context)
        {
        }
    }
}
