using Api_Filme.Domain.Model;

namespace Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryCinema
{
    public interface ICinemaBuscarRepository
    {
        Task<IEnumerable<CinemaModel>> BuscarCinema();
    }
}