using AgendaApp.API.Models;
using AgendaApp.Tests.Helpers;
using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using Xunit;

namespace AgendaApp.Tests.Tasks;

/// <summary>
/// Classe de testes para o endpoint /api/tarefas
/// </summary>
public class TarefasTests
{
    private Faker _faker => new Faker("pt_BR");
    private string _endpoint => "/api/tarefas";

    [Fact]
    public void Post_Tarefas_Returns_Created()
    {
        var request = new TarefasPostRequestModel
        {
            Nome = _faker.Lorem.Sentences(1),
            Descricao = _faker.Lorem.Sentences(3).Substring(0, 250),
            DataHora = _faker.Date.Between(new DateTime(2024, 04, 01), new DateTime(2024, 04, 30)),
            Prioridade = _faker.Random.Int(1, 3)
        };

        //var jsonRequest = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

        //fazendo a chamada para a api
        //var client = new WebApplicationFactory<Program>().CreateClient();

        var result = TestHelper.CreateClient
            .PostAsync(_endpoint, TestHelper.CreateContent(request)).Result;

        result.StatusCode.Should().Be(HttpStatusCode.Created);

        //lendo os dados obtidos da API
        var response = TestHelper.ReadContent<TarefasGetResponseModel>(result);

        response?.Id.Should().NotBeEmpty(); //ID não pode ser vazio
        response?.Nome.Should().Be(request.Nome); //nome deve ser igual ao valor enviado
        response?.Descricao.Should().Be(request.Descricao); //descrição deve ser igual ao valor enviado
        response?.DataHora.Should().Be(request.DataHora); //data e hora deve ser igual ao valor enviado
        response?.Prioridade.Should().Be(request.Prioridade); //prioridade deve ser igual ao valor enviado
        response?.CadastradoEm.Should().NotBeNull(); //CadastradoEm não pode ser vazio
        response?.UltimaAtualizacaoEm.Should().NotBeNull(); //UltimaAtualizacaoEm não pode ser vazio

    }

    [Fact]
    public void Post_Tarefas_Returns_BadRequest()
    {
        #region Enviando uma requisição POST para o ENDPOINT de tarefas

        var request = new TarefasPostRequestModel();
        var result = TestHelper.CreateClient.PostAsync(_endpoint, TestHelper.CreateContent(request)).Result;

        #endregion

        #region Verificar o resultado obtido

        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var response = result.Content.ReadAsStringAsync().Result;

        response?.Should().Contain("Por favor, informe o nome da tarefa.");
        response?.Should().Contain("Por favor, informe a descrição da tarefa.");
        response?.Should().Contain("Por favor, informe a data e hora da tarefa.");
        response?.Should().Contain("Por favor, informe a prioridade da tarefa.");

        #endregion
    }



    [Fact(Skip = "não implementado")]
    public void Put_Tarefas_Returns_Created()
    {

    }

    [Fact(Skip = "não implementado")]
    public void Delete_Tarefas_Returns_Created()
    {

    }

    [Fact(Skip = "não implementado")]
    public void Get_Tarefas_By_Datas_Returns_Created()
    {

    }

    [Fact(Skip = "não implementado")]
    public void Get_Tarefas_By_Id_Returns_Created()
    {

    }
}
