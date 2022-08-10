using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructures.Repository;

namespace SelfieAWookie.API.UI.ExtensionMethods;

public static class DIMethods
{
    public static void AddInjections(this IServiceCollection Services)
    {
        Services.AddScoped<ISelfieRepository, DefaultSelfieRepository>();
    }
}
