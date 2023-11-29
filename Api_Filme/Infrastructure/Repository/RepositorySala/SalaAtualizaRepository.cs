using Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySala;
using Api_Filme.Domain.Model;
using Api_Filme.Infrastructure.Data;

namespace Api_Filme.Infrastructure.Repository.RepositorySala
{
    public class SalaAtualizaRepository : ISalaAtualizaRepository
    {
        private readonly IDatabaseConnection _connection;

        public SalaAtualizaRepository(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> AtualizaSala(SalaModel salaModel, int id)
        {
            const string query = "Update sala set lugar = @lugar, id_cinema = @IdCinema where id = @Id";
            var updateModel = new { Id = id, salaModel.Lugar, salaModel.IdCinema };
            var rowsAffected = _connection.ExecuteAsync(query, updateModel);
            return await rowsAffected > 0;
        }
    }
}
