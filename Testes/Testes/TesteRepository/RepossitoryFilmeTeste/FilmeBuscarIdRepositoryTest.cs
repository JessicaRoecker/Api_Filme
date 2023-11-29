using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api_Filme.Domain.Model;
using Api_Filme.Infrastructure.Data;
using Api_Filme.Infrastructure.Repository.RepositoryFilme;
using Api_Filme.Infrastructure.Repository.RepositorySessao;
using Microsoft.Extensions.Configuration;

namespace Testes.Testes.TesteRepository.RepossitoryFilmeTeste
{
    public class FilmeBuscarIdRepositoryTest
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
        public async Task FilmeRepository_BuscarSessoesId_Deve_Retornar_True_Para_Id_Existente()
        {
            var databaseConnection = new DatabaseConnection(_configuration);

            var filmeBuscarIdRepository = new FilmeBuscarIdRepository(databaseConnection);

            var expectedSessao = new FilmeModel
            {
                Id = 3,

            };

            // Act
            var result = await filmeBuscarIdRepository.BuscarFilmesIdAsync(expectedSessao.Id);

            // Assert
            Assert.IsNotNull(result); // Verifica se o resultado não é nulo
            Assert.AreEqual(expectedSessao.Id, result.Id); // Verifica se as propriedades são iguais

        }

        [Test]
        public async Task BuscarSessoesId_Deve_Retornar_Nulo_Para_Id_Inexistente()
        {
            // Arrange

            var databaseConnection = new DatabaseConnection(_configuration);

            var filmeBuscarIdRepository = new FilmeBuscarIdRepository(databaseConnection);

            // Act
            var result = await filmeBuscarIdRepository.BuscarFilmesIdAsync(999); // ID não existente

            // Assert
            Assert.IsNull(result); // Verifica se o resultado é nulo para um ID inexistente
        }

    }
}
