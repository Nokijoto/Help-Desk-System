using ServiceDesk.Assets.API.Interfaces;
using ServiceDesk.Assets.API.Services;
using ServiceDesk.Assets.Storage.Entities;

namespace ServiceDesk.Assets.API.Extensions
{
    public static class ServicesExtensions
    {

        public static IServiceCollection AddCustomServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));
            //serviceCollection.AddScoped<AssetService>();
            //serviceCollection.AddScoped<IBaseService<AssetService>, AssetService>();
            //serviceCollection.AddTransient<IAssetsService, AssetsService>();
            return serviceCollection;
        }



    }
}
