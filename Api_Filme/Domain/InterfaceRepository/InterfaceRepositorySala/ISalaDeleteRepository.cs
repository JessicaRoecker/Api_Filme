namespace Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySala
{
    public interface ISalaDeleteRepository
    {
        Task<bool> DeleteSala(int id);
    }
}