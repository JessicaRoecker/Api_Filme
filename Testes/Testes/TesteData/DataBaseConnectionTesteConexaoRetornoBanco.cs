using System.IO;
using Api_Filme.Application.Controllers;
using Api_Filme.Domain.Model;
using Api_Filme.Infrastructure.Data;
using Api_Filme.Infrastructure.Repository.RepositoryFilme;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;

namespace Testes.Testes.TesteData
{
    public class DataBaseConnectionTesteConexaoRetornoBanco
    {
        private IConfiguration _configuration;

        [SetUp]
        public void Setup()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        [Test]
        public async Task QueryAsync_Devera_Retornar_Dados()
        {
            // Arrange
            var databaseConnection = new DatabaseConnection(_configuration);

            // Act
            var results = await databaseConnection.QueryAsync<FilmeModel>("SELECT * FROM Filme", null);

            // Assert
            var filmeEsperado = new FilmeModel
            {
                Id = 3,
                Titulo = "Eu Sou a Lenda",
                Ano_Lancamento = new DateTime(2023, 11, 15),
                Diretor = "Natan",
                Genero = "Suspense",
                Duracao = 150
            };

            // Verificar se a lista contém o filme esperado
            Assert.IsTrue(results.Any(filme =>
                filme.Id == filmeEsperado.Id &&
                filme.Titulo == filmeEsperado.Titulo &&
                filme.Ano_Lancamento == filmeEsperado.Ano_Lancamento &&
                filme.Diretor == filmeEsperado.Diretor &&
                filme.Genero == filmeEsperado.Genero &&
                filme.Duracao == filmeEsperado.Duracao));
        }


        [Test]
        public async Task QueryFirstOrDefaultAsync_Devera_Retornar_o_Primeiro_Item()
        {
            // Arrange
            var databaseConnection = new DatabaseConnection(_configuration);
            var resultadosEsperados = new FilmeModel
        {
            Id = 3,
            Ano_Lancamento = new DateTime(2023, 11, 15),
            Genero = "Suspense",
            Titulo = "Eu Sou a Lenda",
            Diretor = "Natan",
            Duracao = 150
    };

            // Act
            var result = await databaseConnection.QueryFirstOrDefaultAsync<FilmeModel>("SELECT * FROM Filme",null );

            // Assert
            Assert.IsNotNull(result);  // Garante que o resultado não é nulo
            Assert.AreEqual(3, result.Id);  // Verifica se o Id é 1 
            result.Should().BeEquivalentTo(resultadosEsperados);//compara a lista de resultados obtida do banco de dados com a lista esperada usando a biblioteca FluentAssertions
        }

    } 
}
