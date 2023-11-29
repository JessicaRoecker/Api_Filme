using Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryCinema;
using Api_Filme.Infrastructure.Data;

namespace Api_Filme.Infrastructure.Repository.RepositoryCinema
{
    public class CinemaDeleteRepository : ICinemaDeleteRepository
    {
        private readonly IDatabaseConnection _connection;

        public CinemaDeleteRepository(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> DeleteCinema(int id)
        {
            const string query = "Delete from Cinema where id = @Id";
            var rowsAffected = _connection.ExecuteAsync(query, new { Id = id });
            return await rowsAffected > 0;
        }
    }
}
