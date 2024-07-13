namespace Gateway.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddGatewayServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOcelotWithJwt(configuration);
        }
    }
}
