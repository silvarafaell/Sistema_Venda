using Microsoft.EntityFrameworkCore;
using SistemaVenda.Domain.Models;

namespace SistemaVenda.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        
        public DbSet<Produto> produtos { get; set; }
    }
}
