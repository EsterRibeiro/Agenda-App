using AgendaApp.Domain.Interfaces.Repositories;
using AgendaApp.Domain.Interfaces.Services;
using AgendaApp.Domain.Services;
using AgendaApp.Infra.Data.Repositories;

namespace AgendaApp.API.Extensions;

/// <summary>
/// Classe de extensão para configurarmos as injeções de dependência do projeto
/// </summary>
public static class DependencyInjectionExtension
{
    public static IServiceCollection AddDependecyInjection(this IServiceCollection services)
    {
        //mapeamento de injeção de dependência, epsquisar depois o scopped e outros tipos
        services.AddScoped<ITarefaDomainService, TarefaDomainService>();
        services.AddScoped<ITarefaRepository, TarefaRepository>();
        return services;
    }
}
