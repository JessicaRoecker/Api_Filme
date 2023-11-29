using Api_Filme.Domain.Model;

namespace Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryCinema
{
    public interface ICinemaBuscarIdRepository
    {
        Task<CinemaModel> BuscarCinemaId(int id);
    }
}