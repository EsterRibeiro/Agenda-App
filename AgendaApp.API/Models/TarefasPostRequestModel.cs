using System.ComponentModel.DataAnnotations;

namespace AgendaApp.API.Models;

/// <summary>
/// Modelo de dados paa nossa requisição de cadastro de tarefas
/// </summary>
public class TarefasPostRequestModel
{
    [MinLength(8, ErrorMessage = "Informe no mínimo {1} caracteres")]
    [MaxLength(100, ErrorMessage = "Informe no máximo {1} caracteres")]
    [Required(ErrorMessage = "Informe o nome da tarefa")] //data annotation
    public string? Nome { get; set; }

    [MinLength(8, ErrorMessage = "Informe no mínimo {1} caracteres")]
    [MaxLength(250, ErrorMessage = "Informe no máximo {1} caracteres")]
    [Required(ErrorMessage = "Informe a descrição da tarefa")]
    public string? Descricao { get; set; }

    [Required(ErrorMessage = "Informe a data da tarefa")]
    public DateTime? DataHora { get; set; }

    [Required(ErrorMessage = "Informe o prioridade da tarefa")]
    public int? Prioridade { get; set; }
}
