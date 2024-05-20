using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Interfaces.Repositories;
using AgendaApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Infra.Data.Repositories;
public class TarefaRepository : ITarefaRepository
{
    public void Add(Tarefa tarefa)
    {
        using (var dataContext = new DataContext())
        {
            dataContext.Add(tarefa);
            dataContext.SaveChanges();
        }
    }

    public void Delete(Tarefa tarefa)
    {
        using (var dataContext = new DataContext())
        {
            dataContext.Remove(tarefa);
            dataContext.SaveChanges();
        }
    }

    public List<Tarefa> Get(DateTime dataMin, DateTime dataMax)
    {
        using (var dataContext = new DataContext())
        {
            return dataContext.Set<Tarefa>()
                .Where(x => x.DataHora >= dataMin && x.DataHora <= dataMax)
                .OrderByDescending(x => x.DataHora)
                .ToList();
        }
    }

    public Tarefa? GetById(Guid id)
    {
        using (var dataContext = new DataContext())
        {
            return dataContext.Set<Tarefa>().Find(id); // o find já busca a chave primária
        }
    }


    public void Update(Tarefa tarefa)
    {
        using (var dataContext = new DataContext())
        {
            dataContext.Update(tarefa);
            dataContext.SaveChanges();
        }
    }
}
