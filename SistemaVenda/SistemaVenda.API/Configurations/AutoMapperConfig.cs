using SistemaVenda.Application.Profiles;
using System.Reflection;

namespace SistemaVenda.API.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
           => services.AddAutoMapper(Assembly.GetAssembly(typeof(AutoMapperProfiles)));
    }
}
