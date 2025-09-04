using AutoMapper;

namespace ECommerce_API;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionStrings:DefaultConnection"] ??
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
        services.AddControllers();

        services.AddSwaggerServices();

        services.AddFluentValidationConfigs();

        services.AddAutoMapperConfigs();

        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();

        return services;
    }

    private static IServiceCollection AddSwaggerServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    private static IServiceCollection AddFluentValidationConfigs(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());    
        services.AddFluentValidationAutoValidation();

        return services;
    }

    private static IServiceCollection AddAutoMapperConfigs(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ProductMap).Assembly);
        services.AddAutoMapper(typeof(CategoryMap).Assembly);

        return services;
    }
}
