using Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySessao;
using Api_Filme.Domain.Model;
using Api_Filme.Infrastructure.Data;

namespace Api_Filme.Infrastructure.Repository.RepositorySessao
{
    public class SessaoBuscarIdRepository : ISessaoBuscarIdRepository
    {
        private readonly IDatabaseConnection _connection;

        public SessaoBuscarIdRepository(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public async Task<SessoesModel> BuscarSessoesId(int id)
        {
            const string query = "Select * from Sessoes where Id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<SessoesModel>(query, new { Id = id });
        }
    }
}
