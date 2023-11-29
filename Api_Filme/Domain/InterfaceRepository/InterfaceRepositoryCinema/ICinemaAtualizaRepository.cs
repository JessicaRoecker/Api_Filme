using Api_Filme.Domain.Model;

namespace Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryCinema
{
    public interface ICinemaAtualizaRepository
    {
        Task<bool> AtualizarCinema(CinemaModel cinemaModel, int id);
    }
}