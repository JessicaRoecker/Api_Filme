using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api_Filme.Domain.Model;
using Api_Filme.Infrastructure.Data;
using Api_Filme.Infrastructure.Repository.RepositoryFilme;
using Microsoft.Extensions.Configuration;
using Moq;

namespace Testes.Testes.TesteRepository.RepossitoryFilmeTeste
{
    public class FilmeBuscarRepositoryTeste
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
        public async Task FilmeDeleteRepository_BuscarTodosFilmesAsync_Deve_Retornar_Nao_Nulo()
        {
            // Arrange
         
            var databaseConnection = new DatabaseConnection(_configuration);

            var filmeBuscarRepository = new FilmeBuscarRepository(databaseConnection);

            // Act
            var result = await filmeBuscarRepository.BuscarTodosFilmesAsync();

            // Assert
            Assert.IsNotNull(result); // Verifica se o resultado não é nulo
            Assert.IsNotEmpty(result); // Verifica se a coleção retornada não está vazia
                                       
        }


        [Test]
        public async Task FilmeBuscarRepository_BuscarTodosFilmesAsync_Deve_Retornar_Lista_Equivalente()
        {
            // Arrange
            var databaseConnectionMock = new Mock<IDatabaseConnection>();
            var expectedFilmes = new List<FilmeModel>
    {
        new FilmeModel { Id = 1, Titulo = "Filme 1", Diretor = "Diretor 1", Ano_Lancamento = new DateTime(2023, 1, 1), Duracao = 120, Genero = "Ação" },
        new FilmeModel { Id = 2, Titulo = "Filme 2", Diretor = "Diretor 2", Ano_Lancamento = new DateTime(2023, 1, 2), Duracao = 130, Genero = "Drama" },
        // Adicione mais filmes conforme necessário
    };

            databaseConnectionMock.Setup(x => x.QueryAsync<FilmeModel>(It.IsAny<string>(), It.IsAny<object>()))
                                 .ReturnsAsync(expectedFilmes);

            var filmeBuscarRepository = new FilmeBuscarRepository(databaseConnectionMock.Object);

            // Act
            var result = await filmeBuscarRepository.BuscarTodosFilmesAsync();

            // Assert
            Assert.IsNotNull(result); // Verifica se o resultado não é nulo
            CollectionAssert.AreEquivalent(expectedFilmes, result); // Verifica se a coleção retornada é equivalente à coleção esperada
            databaseConnectionMock.Verify(x => x.QueryAsync<FilmeModel>(It.IsAny<string>(), It.IsAny<object>()), Times.Once); // Verifica se o método QueryAsync foi chamado uma vez
        }

    }

}
