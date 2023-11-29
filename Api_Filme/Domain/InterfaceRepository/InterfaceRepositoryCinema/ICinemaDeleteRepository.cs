namespace Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryCinema
{
    public interface ICinemaDeleteRepository
    {
        Task<bool> DeleteCinema(int id);
    }
}