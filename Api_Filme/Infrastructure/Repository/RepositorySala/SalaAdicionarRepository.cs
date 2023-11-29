using Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySala;
using Api_Filme.Domain.Model;
using Api_Filme.Infrastructure.Data;

namespace Api_Filme.Infrastructure.Repository.RepositorySala
{
    public class SalaAdicionarRepository : ISalaAdicionarRepository
    {
        private readonly IDatabaseConnection _connection;

        public SalaAdicionarRepository(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> AdicionarSala(SalaModel salaModel)
        {
            const string query = "Insert into Sala (lugar, id_cinema) values (@Lugar,@IdCinema)";
            var rowsAffected = _connection.ExecuteAsync(query, salaModel);
            return await rowsAffected > 0;
        }
    }
}
