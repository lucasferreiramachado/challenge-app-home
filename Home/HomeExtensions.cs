using Home.Presentation;

namespace Home;

public static class HomeExtensions
{
    public static IServiceCollection AddHomeModule(this IServiceCollection services)
    {
        services.AddTransient<HomeViewModel>();
        services.AddTransient<HomeView>();
        return services;
    }
}
