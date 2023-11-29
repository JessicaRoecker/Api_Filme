using Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryFilme;
using Api_Filme.Domain.Model;
using Api_Filme.Infrastructure.Data;

namespace Api_Filme.Infrastructure.Repository.RepositoryFilme
{
    public class FilmeBuscarIdRepository : IFilmeBuscarIdRepository
    {
        private IDatabaseConnection _connection;
        public FilmeBuscarIdRepository(IDatabaseConnection databaseConnection)
        {
            _connection = databaseConnection;
        }
        public async Task<FilmeModel> BuscarFilmesIdAsync(int id)
        {
            const string query = "SELECT * FROM filme WHERE id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<FilmeModel>(query, new { Id = id });
        }
    }
}
