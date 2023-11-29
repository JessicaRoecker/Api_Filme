using Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySessao;
using Api_Filme.Infrastructure.Data;

namespace Api_Filme.Infrastructure.Repository.RepositorySessao
{
    public class SessaoDeleteRepository : ISessaoDeleteRepository
    {
        private readonly IDatabaseConnection _connection;

        public SessaoDeleteRepository(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> DeleteSessao(int id)
        {
            const string query = "Delete * from Sessoes where id = @id";
            var rowsAffected = _connection.ExecuteAsync(query, new { Id = id });
            return await rowsAffected > 0;

        }
    }
}
