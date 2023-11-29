using Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryFilme;
using Api_Filme.Domain.Model;
using Api_Filme.Infrastructure.Data;

namespace Api_Filme.Infrastructure.Repository.RepositoryFilme
{
    public class FilmeBuscarRepository : IFilmeBuscarRepository
    {
        private readonly IDatabaseConnection _connection;

        public FilmeBuscarRepository(IDatabaseConnection databaseConnection)
        {
            _connection = databaseConnection;
        }

        public async Task<IEnumerable<FilmeModel>> BuscarTodosFilmesAsync()
        {

            const string query = "Select * from filme";
            return await _connection.QueryAsync<FilmeModel>(query, null);
        }
    }
}
