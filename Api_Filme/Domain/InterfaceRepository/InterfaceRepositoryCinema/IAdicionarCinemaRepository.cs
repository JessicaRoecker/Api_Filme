using Api_Filme.Domain.Model;

namespace Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryCinema
{
    public interface IAdicionarCinemaRepository
    {
        Task<bool> AdicionarCinema(CinemaModel cinemaModel);
    }
}