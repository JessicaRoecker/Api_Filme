using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api_Filme.Infrastructure.Data;
using Api_Filme.Infrastructure.Repository.RepositoryFilme;
using Moq;

namespace Testes.Testes.TesteRepository.RepossitoryFilmeTeste
{
    public class FilmeDeleteRepositoryTeste
    {
        [Test]
        public async Task FilmeDeleteRepository_DeletarAsync_Deve_Retornar_True_Ao_Excluir_Com_Sucesso()
        {
            // Arrange
            var databaseConnectionMock = new Mock<IDatabaseConnection>();

            var filmeDeleteRepository = new FilmeDeleteRepository(databaseConnectionMock.Object);

            // Configurar o mock para retornar um valor indicando que a exclusão foi bem-sucedida
            databaseConnectionMock.Setup(x => x.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                                 .ReturnsAsync(1);

            // Act
            var result = await filmeDeleteRepository.DeletarAsync(1);

            // Assert
            Assert.IsTrue(result); // Verifica se a exclusão foi bem-sucedida
            databaseConnectionMock.Verify(x => x.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once); // Verifica se o método ExecuteAsync foi chamado uma vez
        }

        [Test]
        public async Task FilmeDeleteRepository_DeletarAsync_Deve_Retornar_False_Ao_Nao_Excluir_Com_Sucesso()
        {
            // Arrange
            var databaseConnectionMock = new Mock<IDatabaseConnection>();

            var filmeDeleteRepository = new FilmeDeleteRepository(databaseConnectionMock.Object);

            // Configurar o mock para retornar um valor indicando que a exclusão não foi bem-sucedida
            databaseConnectionMock.Setup(x => x.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                                 .ReturnsAsync(0);

            // Act
            var result = await filmeDeleteRepository.DeletarAsync(1);

            // Assert
            Assert.IsFalse(result); // Verifica se a exclusão não foi bem-sucedida
            databaseConnectionMock.Verify(x => x.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once); // Verifica se o método ExecuteAsync foi chamado uma vez
        }

    }
}
