using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Exceptions;
using AgendaApp.Domain.Interfaces.Repositories;
using AgendaApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Services
{
    /// <summary>
    /// Implementação dos serviços de domínio para tarefa
    /// </summary>
    public class TarefaDomainService : ITarefaDomainService
    {
        //atributos
        private readonly ITarefaRepository _tarefaRepository;

        //método construtor para injeção de dependência da interface ITarefaRepository
        public TarefaDomainService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public Tarefa Adicionar(Tarefa tarefa)
        {
            tarefa.Id = Guid.NewGuid();
            tarefa.CadastradoEm = DateTime.Now;
            tarefa.UltimaAtualizacaoEm = DateTime.Now;
            tarefa.Ativo = true;

            _tarefaRepository.Add(tarefa);

            return tarefa;
        }

        public Tarefa Atualizar(Tarefa tarefa)
        {
            var tarefaEdicao = _tarefaRepository.GetById(tarefa.Id.Value);

            DomainExceptions.When(tarefaEdicao == null, "tarefa inválida para edição, busque uma tarefa existente");


            tarefaEdicao.Nome = tarefa.Nome;
            tarefaEdicao.Descricao = tarefa.Descricao;
            tarefaEdicao.DataHora = tarefa.DataHora;
            tarefaEdicao.Prioridade = tarefa.Prioridade;
            tarefaEdicao.UltimaAtualizacaoEm = DateTime.Now;

            _tarefaRepository.Update(tarefaEdicao);

            return tarefaEdicao;
        }

        public Tarefa Excluir(Guid id)
        {
            var tarefaExclusao = _tarefaRepository.GetById(id);

            DomainExceptions.When(tarefaExclusao == null, "tarefa inválida para exclusão, busque uma tarefa existente");

            _tarefaRepository.Delete(tarefaExclusao);

            return tarefaExclusao;
        }

        public List<Tarefa> Consultar(DateTime dataMin, DateTime dataMax)
        {
            return _tarefaRepository.Get(dataMin, dataMax);
        }

        public Tarefa? ObterPorId(Guid id)
        {
            return _tarefaRepository.GetById(id);
        }
    }
}



