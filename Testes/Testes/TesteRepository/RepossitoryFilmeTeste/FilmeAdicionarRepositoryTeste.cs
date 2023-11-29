using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api_Filme.Domain.Model;
using Api_Filme.Infrastructure.Data;
using Api_Filme.Infrastructure.Repository.RepositoryFilme;
using Moq;

namespace Testes.Testes.TesteRepository.RepossitoryFilmeTeste
{
    public class FilmeAdicionarRepositoryTeste
    {
       
        [Test]
        public async Task AdicionarAsync_Deve_Retornar_Verdadeiro_Em_Atualizacao_Bem_Sucedida()
        {
            // Arrange
            var databaseConnectionMock = new Mock<IDatabaseConnection>();
            databaseConnectionMock.Setup(x => x.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                                 .ReturnsAsync(1); // Simula a adição bem-sucedida

            var filmeAdicionarRepository = new FilmeAdicionarRepository(databaseConnectionMock.Object);

            var filmeModel = new FilmeModel
            {
                Titulo = "Novo Filme",
                Diretor = "Diretor",
                Ano_Lancamento = new DateTime(2023, 1, 1),
                Duracao = 120,
                Genero = "Ação"
            };

            // Act
            var result = await filmeAdicionarRepository.AdicionarAsync(filmeModel);

            // Assert
            Assert.IsTrue(result); // Verifica se a adição foi bem-sucedida
            databaseConnectionMock.Verify(x => x.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once); // Verifica se o método ExecuteAsync foi chamado uma vez
        }


    }
}

