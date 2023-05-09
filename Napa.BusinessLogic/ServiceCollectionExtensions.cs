using Microsoft.Extensions.DependencyInjection;
using Napa.BusinessLogic.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napa.BusinessLogic
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            var serviceType = typeof(IService);
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var types = assemblies
                .SelectMany(s => s.GetTypes())
                .Where(p => serviceType.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract
                    && (p.Name.EndsWith("Service") || p.Namespace.EndsWith(".IServices")));

            foreach (var type in types)
            {
                var interfaceType = type.GetInterfaces()
                    .FirstOrDefault(p => p != serviceType && serviceType.IsAssignableFrom(p));
                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, type);
                }
            }
        }
    }
}
