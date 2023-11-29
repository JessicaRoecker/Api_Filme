using Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryCinema;
using Api_Filme.Domain.Model;
using Api_Filme.Infrastructure.Data;

namespace Api_Filme.Infrastructure.Repository.RepositoryCinema
{
    public class CinemaBuscarRepository : ICinemaBuscarRepository
    {
        private readonly IDatabaseConnection _connection;

        public CinemaBuscarRepository(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<CinemaModel>> BuscarCinema()
        {
            const string query = "Select * from cinema";
            return await _connection.QueryAsync<CinemaModel>(query, null);
        }
    }
}
