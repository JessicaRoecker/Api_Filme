using Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySessao;
using Api_Filme.Domain.Model;
using Api_Filme.Infrastructure.Data;

namespace Api_Filme.Infrastructure.Repository.RepositorySessao
{
    public class SessaoAdicionarRepository : ISessaoAdicionarRepository
    {
        private readonly IDatabaseConnection _connection;

        public SessaoAdicionarRepository(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> AdicionarSessao(SessoesModel sessoesModel)
        {
            const string query = "Insert into Sessoes (id_filme, id_sala, horrario, assento) Values (@IdFilme, @IdSala, @Horario,@assento)";
            var parameters = new
            {
                sessoesModel.Assento,
                sessoesModel.IdFilme,
                sessoesModel.IdSala,
                sessoesModel.Horario
            };

            var rowsAffected = _connection.ExecuteAsync(query, parameters);

            return await rowsAffected > 0;
        }
    }
}
