using Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryFilme;
using Api_Filme.Domain.Model;
using Api_Filme.Infrastructure.Data;

namespace Api_Filme.Infrastructure.Repository.RepositoryFilme
{
    public class FilmeAtualizarRepository : IFilmeAtualizarRepository
    {
        private IDatabaseConnection _connection;

        public FilmeAtualizarRepository(IDatabaseConnection databaseConnection)
        {
            _connection = databaseConnection;
        }

        public async Task<bool> AtualizarAsync(FilmeModel model, int id)
        {
            const string query = "UPDATE filme SET titulo = @Titulo, diretor = @Diretor, ano_lancamento = @Ano_Lancamento, duracao = @Duracao, genero = @Genero WHERE id = @Id";
            var updatedModel = new { Id = id, model.Titulo, model.Diretor, model.Ano_Lancamento, model.Duracao, model.Genero };
            var rowsAffected = _connection.ExecuteAsync(query, updatedModel);
            return await rowsAffected > 0;
        }
    }
}
