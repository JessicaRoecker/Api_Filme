using Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryFilme;
using Api_Filme.Infrastructure.Data;

namespace Api_Filme.Infrastructure.Repository.RepositoryFilme
{
    public class FilmeDeleteRepository : IFilmeDeleteRepository
    {
        private IDatabaseConnection _connection;

        public FilmeDeleteRepository(IDatabaseConnection databaseConnection)
        {
            _connection = databaseConnection;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            const string query = "DELETE FROM filme WHERE id = @Id";
            var rowsAffected = await _connection.ExecuteAsync(query, new { Id = id });
            return rowsAffected > 0;
        }
    }
}
