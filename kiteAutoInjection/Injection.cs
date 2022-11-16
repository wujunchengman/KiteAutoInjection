using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace kiteAutoInjection
{
    public static class Injection
    {
        public static void AutoInjection(this IServiceCollection services)
        {
         
            
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x=>!(
            x.GetName().FullName.StartsWith("System") || 
            x.GetName().FullName.StartsWith("Microsoft") ||
            x.GetName().FullName.StartsWith("WindowsBase") ||
            x.GetName().FullName.StartsWith("netstandard") ||
            x.GetName().FullName.StartsWith("mscorlib") ||
            x.GetName().FullName == typeof(Injection).Assembly.GetName().FullName
            ));
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    

                    if (type.GetInterface("ITransientDependency") !=null)
                    {
                        services.AddTransient(type);
                    }
                    else if(type.GetInterface("ISingletonDependency") !=null)
                    {
                        services.AddSingleton(type);
                    }else if(type.GetInterface("IScopedDependency") !=null)
                    {
                        services.AddScoped(type);
                    }

                }
            }

        }
    }
}