using Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySessao;
using Api_Filme.Domain.Model;
using Api_Filme.Infrastructure.Data;

namespace Api_Filme.Infrastructure.Repository.RepositorySessao
{
    public class SessaoAtualizaRepository : ISessaoAtualizaRepository
    {
        private readonly IDatabaseConnection _connection;

        public SessaoAtualizaRepository(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> AtualizarSessao(SessoesModel sessoesModel, int id)
        {
            const string query = "Update sessoes set id_filme = @IdFilme, id_sala = @IdSala, horario = @Horario";
            var updateModel = new { Id = id, sessoesModel.IdFilme, sessoesModel.IdSala, sessoesModel.Horario, sessoesModel.Assento};
            var rowsAffected = _connection.ExecuteAsync(query, updateModel);
            return await rowsAffected > 0;
        }
    }
}
