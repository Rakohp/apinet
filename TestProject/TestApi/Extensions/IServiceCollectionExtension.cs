using System.Reflection;
using TestApi.Base;

namespace TestApi.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            var optionsClass = GetOptions();
            
            foreach (var implementation in optionsClass)
                AddConfigurate(services, implementation);            

            return services;
        }
        public static void AddConfigurate(IServiceCollection services, Type? implementation)
        {
            Type type = implementation.GetInterfaces().FirstOrDefault(x => x.Name.Equals($"I{implementation.Name}"));
            services.AddTransient(type, implementation);
        }
        public static List<Type> GetOptions()
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            List<Type> optionsClass = types.Where(x => x.GetInterfaces().Any(z => z.UnderlyingSystemType.Equals(typeof(IBaseService)))).ToList();

            return optionsClass;
        }
    }
}
