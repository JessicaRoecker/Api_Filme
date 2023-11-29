using Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySala;
using Api_Filme.Domain.Model;
using Api_Filme.Infrastructure.Data;

namespace Api_Filme.Infrastructure.Repository.RepositorySala
{
    public class SalaBuscarRepository : ISalaBuscarRepository
    {
        private readonly IDatabaseConnection _connection;

        public SalaBuscarRepository(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<SalaModel>> BuscarSala()
        {
            const string query = "Select * from sala";
            return await _connection.QueryAsync<SalaModel>(query, null);
        }
    }
}
