using Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryCinema;
using Api_Filme.Domain.Model;
using Api_Filme.Infrastructure.Data;

namespace Api_Filme.Infrastructure.Repository.RepositoryCinema
{
    public class AdicionarCinemaRepository : IAdicionarCinemaRepository
    {
        private readonly IDatabaseConnection _connection;

        public AdicionarCinemaRepository(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> AdicionarCinema(CinemaModel cinemaModel)
        {
            const string query = "Insert into Cinema (nome,endereco,telefone) Values (@nome,@endereco,@telefone)";
            var rowsAffected = _connection.ExecuteAsync(query, cinemaModel);
            return await rowsAffected > 0;
        }
    }
}
