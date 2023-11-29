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
using Moq;

namespace Testes.Testes.TesteRepository.RepossitoryFilmeTeste
{
    public class FilmeAtualizarRepositoryTeste
    {
        [Test]
        public async Task FilmeAtualizarRepository_AtualizarAsync_Deve_Retornar_Verdadeiro_Em_Atualizacao_Bem_Sucedida()
        {
            // Arrange
            var databaseConnectionMock = new Mock<IDatabaseConnection>();

            var filmeModel = new FilmeModel
            {
                Id = 1,
                Titulo = "Novo Título",
                Diretor = "Novo Diretor",
                Ano_Lancamento = new DateTime(2023, 11, 15),
                Duracao = 120,
                Genero = "Novo Gênero"
            };

            var filmeAtualizarRepository = new FilmeAtualizarRepository(databaseConnectionMock.Object);

            // Configurar o mock para retornar um valor indicando que a atualização foi bem-sucedida
            databaseConnectionMock.Setup(x => x.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                                 .ReturnsAsync(1);

            // Act
            var result = await filmeAtualizarRepository.AtualizarAsync(filmeModel, 1);

            // Assert
            Assert.IsTrue(result); // Verifica se a atualização foi bem-sucedida
            databaseConnectionMock.Verify(x => x.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once); // Verifica se o método ExecuteAsync foi chamado uma vez
        }

        [Test]
        public async Task FilmeAtualizarRepository_AtualizarAsync_Deve_Retornar_Falso_Em_Atualizacao_Nao_Bem_Sucedida()
        {
            // Arrange
            var databaseConnectionMock = new Mock<IDatabaseConnection>();

            var filmeModel = new FilmeModel
            {
                Id = 1,
                Titulo = "Novo Título",
                Diretor = "Novo Diretor",
                Ano_Lancamento = new DateTime(2023, 11, 15),
                Duracao = 120,
                Genero = "Novo Gênero"
                
            };

            var filmeAtualizarRepository = new FilmeAtualizarRepository(databaseConnectionMock.Object);

            // Configurar o mock para retornar um valor indicando que a atualização não foi bem-sucedida
            databaseConnectionMock.Setup(x => x.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                                 .ReturnsAsync(0);

            // Act
            var result = await filmeAtualizarRepository.AtualizarAsync(filmeModel, 1);

            // Assert
            Assert.IsFalse(result); // Verifica se a atualização não foi bem-sucedida
            databaseConnectionMock.Verify(x => x.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once); // Verifica se o método ExecuteAsync foi chamado uma vez
        }

    }
}
