using AgendaApp.Domain.Entities;

namespace AgendaApp.Domain.Interfaces.Repositories;

/// <summary>
/// contrato que define os métodos abstratos de tarefa
/// </summary>
public interface ITarefaRepository
{
    void Add(Tarefa tarefa);
    void Update(Tarefa tarefa);
    void Delete(Tarefa tarefa);
    List<Tarefa> Get(DateTime dataMin, DateTime dataMax);
    Tarefa? GetById(Guid id);
}
