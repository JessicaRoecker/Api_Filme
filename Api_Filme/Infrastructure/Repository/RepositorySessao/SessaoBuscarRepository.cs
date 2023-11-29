using Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySessao;
using Api_Filme.Domain.Model;
using Api_Filme.Infrastructure.Data;

namespace Api_Filme.Infrastructure.Repository.RepositorySessao
{
    public class SessaoBuscarRepository : ISessaoBuscarRepository
    {
        private readonly IDatabaseConnection _connection;

        public SessaoBuscarRepository(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<SessoesModel>> BuscarTodasAsSessoes()
        {
            const string query = "Select * from sessoes";
            return await _connection.QueryAsync<SessoesModel>(query, null);

        }
    }
}
