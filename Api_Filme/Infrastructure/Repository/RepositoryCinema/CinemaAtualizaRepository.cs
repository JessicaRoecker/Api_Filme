using Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryCinema;
using Api_Filme.Domain.Model;
using Api_Filme.Infrastructure.Data;
using System.Data.Common;

namespace Api_Filme.Infrastructure.Repository.RepositoryCinema
{
    public class CinemaAtualizaRepository : ICinemaAtualizaRepository
    {
        private readonly IDatabaseConnection _connection;
        public CinemaAtualizaRepository(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> AtualizarCinema(CinemaModel cinemaModel, int id)
        {
            const string query = "Update Cinema set nome = @Nome, endereco = @Endereco, telefone = @telefone";
            var updateModel = new { Id = id, cinemaModel.Nome, cinemaModel.Endereco, cinemaModel.Telefone };
            var rowsAffected = _connection.ExecuteAsync(query, updateModel);
            return await rowsAffected > 0;
        }
    }
}
