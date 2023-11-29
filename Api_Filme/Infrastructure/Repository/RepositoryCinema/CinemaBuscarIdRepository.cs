using Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryCinema;
using Api_Filme.Domain.Model;
using Api_Filme.Infrastructure.Data;

namespace Api_Filme.Infrastructure.Repository.RepositoryCinema
{
    public class CinemaBuscarIdRepository : ICinemaBuscarIdRepository
    {
        private readonly IDatabaseConnection _connection;

        public CinemaBuscarIdRepository(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public async Task<CinemaModel> BuscarCinemaId(int id)
        {
            const string query = "Select * from cinema where id = @id";
            return await _connection.QueryFirstOrDefaultAsync<CinemaModel>(query, new { Id = id });

        }
    }
}
