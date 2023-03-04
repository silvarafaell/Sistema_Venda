using Microsoft.EntityFrameworkCore;
using SistemaVenda.Domain.Models;

namespace SistemaVenda.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        
        public DbSet<Product> produtos { get; set; }
        public DbSet<User> users { get; set; }
    }
}
