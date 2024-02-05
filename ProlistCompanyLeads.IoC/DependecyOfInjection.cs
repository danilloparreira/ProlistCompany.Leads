namespace ProlistCompany.Leads.IoC;

public static class DependecyOfInjection
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfraServices();
        services.AddRepositories(configuration);
        services.AddServices();
        services.AddHandlers();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["CONNECTION_STRING"];

        if (string.IsNullOrEmpty(connectionString))
            throw new ArgumentNullException(nameof(connectionString));

        services.AddScoped<ILeadRepository>(a => { return new LeadRepository(connectionString); });

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ILeadService, LeadService>();

        return services;
    }

    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddScoped<IMediator, Mediator>();
        services.AddScoped<IRequestHandler<ObterLeadRequestDto, ObterLeadResponseDto>, ObterLeadsHandler>();
        services.AddScoped<IRequestHandler<ObterLeadPorStatusRequestDto, ObterLeadPorStatusResponseDto>, ObterLeadPorStatusHandler>();
        services.AddScoped<IRequestHandler<AceitarLeadRequestDto, AceitarLeadResponseDto>, AceitarLeadHandler>();
        services.AddScoped<IRequestHandler<RecusarLeadRequestDto, RecusarLeadResponseDto>, RecusarLeadHandler>();

        return services;
    }

    public static IServiceCollection AddInfraServices(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, EmailService>();

        return services;
    }
}
