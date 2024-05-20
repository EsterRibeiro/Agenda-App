using AgendaApp.API.Models;
using AgendaApp.Domain.Entities;
using AutoMapper;

namespace AgendaApp.API.Mappings;

/// <summary>
/// Mapeamento das transferências de dados realizados pelo automapper
/// </summary>
public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<TarefasPostRequestModel, Tarefa>();
        CreateMap<TarefasPutRequestModel, Tarefa>();

        CreateMap<Tarefa, TarefasGetResponseModel>();
    }
}
