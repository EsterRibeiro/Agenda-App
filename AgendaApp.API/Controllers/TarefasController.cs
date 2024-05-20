using AgendaApp.API.Models;
using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Entities.Enums;
using AgendaApp.Domain.Exceptions;
using AgendaApp.Domain.Interfaces.Services;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AgendaApp.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TarefasController : ControllerBase
{
    private readonly ITarefaDomainService _tarefaDomainService;
    private readonly IMapper _mapper;

    public TarefasController(ITarefaDomainService tarefaDomainService,
        IMapper mapper)
    {
        _tarefaDomainService = tarefaDomainService;
        _mapper = mapper;
    }

    [HttpPost] //cadastro da tarefa
    [ProducesResponseType(typeof(TarefasGetResponseModel), (int)HttpStatusCode.Created)]
    public IActionResult Post(TarefasPostRequestModel model) { 
        try
        {
            //inicializar aqui apenas oque não é preenchido na model
            
            var tarefa = _tarefaDomainService.Adicionar(_mapper.Map<Tarefa>(model));

            //copia tudo que tem em tarefa e copia em outro objeto usando automapper como acima
            var response = _mapper.Map<TarefasGetResponseModel>(tarefa);

            return StatusCode(201, response);
        }
        catch(DomainExceptions ex)
        {
            return StatusCode(422, new { message = ex.Message });
        }
        catch (Exception ex) {

            return StatusCode(500, new { message = ex.Message });
        }

    }

    [HttpPut] //-> annotation
    [ProducesResponseType(typeof(TarefasGetResponseModel), (int)HttpStatusCode.OK)]
    public IActionResult Put(TarefasPutRequestModel model) //método de edição das tarefas
    {
        try
        {
            //pesquisar a tarefa no banco de dados através do ID
            var tarefa = _mapper.Map<Tarefa>(model);
            _tarefaDomainService.Atualizar(tarefa);

            var response = _mapper.Map<TarefasGetResponseModel>(tarefa);
            return StatusCode(200, response);

        }
        catch (DomainExceptions ex)
        {
            return StatusCode(422, new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(TarefasGetResponseModel), (int)HttpStatusCode.OK)]
    public IActionResult Delete(Guid id) //método de deleção da tarefa
    {
        try {
            var tarefa = _tarefaDomainService.Excluir(id);
            
            //objeto para retornar os dados da resposta
            var response = _mapper.Map<TarefasGetResponseModel>(tarefa);
            return StatusCode(200, response);
        }
        catch (DomainExceptions ex)
        {
            return StatusCode(422, new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }

    }

    [HttpGet("{dataMin}/{dataMax}")]
    [ProducesResponseType(typeof(List<TarefasGetResponseModel>), (int)HttpStatusCode.OK)]
    public IActionResult Get(DateTime dataMin, DateTime dataMax) //método de consulta da tarefa
    {
        try
        {   //busca a tarefa
            var tarefas = _tarefaDomainService.Consultar(dataMin, dataMax);

            //se não encontrar nada, retorna no content (204)
            if (!tarefas.Any())
                return StatusCode(204);

            var response = _mapper.Map<List<TarefasGetResponseModel>>(tarefas);
            return StatusCode(200, response);

        }catch(Exception ex) {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TarefasGetResponseModel), (int)HttpStatusCode.OK)]
    public IActionResult Get(Guid id)
    {
        try
        {   //busca a tarefa
            var tarefa = _tarefaDomainService.ObterPorId(id);

            //se não encontrar nada, retorna no content (204)
            if (tarefa == null)
                return StatusCode(204);

            var response = _mapper.Map<TarefasGetResponseModel>(tarefa);
            return StatusCode(200, response);

        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }
}
