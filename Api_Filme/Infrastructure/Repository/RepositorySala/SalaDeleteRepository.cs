using Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySala;
using Api_Filme.Infrastructure.Data;

namespace Api_Filme.Infrastructure.Repository.RepositorySala
{
    public class SalaDeleteRepository : ISalaDeleteRepository
    {
        private readonly IDatabaseConnection _connection;

        public SalaDeleteRepository(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> DeleteSala(int id)
        {
            const string query = "Delete from sala where jid= @id";
            var rowsAffected = _connection.ExecuteAsync(query, new { Id = id });
            return await rowsAffected > 0;
        }
    }
}
