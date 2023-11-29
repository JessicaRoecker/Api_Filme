using Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySala;
using Api_Filme.Domain.Model;
using Api_Filme.Infrastructure.Data;

namespace Api_Filme.Infrastructure.Repository.RepositorySala
{
    public class SalaBuscarIdRepository : ISalaBuscarIdRepository
    {
        private readonly IDatabaseConnection _connection;

        public SalaBuscarIdRepository(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public async Task<SalaModel> BuscarSalaId(int id)
        {
            const string query = "Select * from sala where id = @id";
            return await _connection.QueryFirstOrDefaultAsync<SalaModel>(query, id);
        }
    }
}
