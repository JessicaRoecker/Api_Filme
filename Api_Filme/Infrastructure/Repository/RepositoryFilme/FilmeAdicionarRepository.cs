using Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryFilme;
using Api_Filme.Domain.Model;
using Api_Filme.Infrastructure.Data;

namespace Api_Filme.Infrastructure.Repository.RepositoryFilme
{
    public class FilmeAdicionarRepository : IFilmeAdicionarRepository
    {
        private IDatabaseConnection _connection;

        public FilmeAdicionarRepository(IDatabaseConnection databaseConnection)
        {
            _connection = databaseConnection;
        }

        public async Task<bool> AdicionarAsync(FilmeModel model)
        {
            const string query = "INSERT INTO filme (titulo,diretor,ano_lancamento,duracao,genero) VALUES (@Titulo,@Diretor,@Ano_Lancamento,@Duracao,@Genero)";
            var rowsAffected = await _connection.ExecuteAsync(query, model);
            return rowsAffected > 0;
        }
    }
}
