using SistemaVenda.Application.Interfaces;
using SistemaVenda.Application.Services;
using SistemaVenda.Data.Repositories;
using SistemaVenda.Domain.Interfaces;

namespace SistemaVenda.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {
            //Repository
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();



            //Service
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IAccountService, AccountService>();

        }
    }
}
