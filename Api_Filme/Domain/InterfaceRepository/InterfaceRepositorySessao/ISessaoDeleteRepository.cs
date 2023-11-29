namespace Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySessao
{
    public interface ISessaoDeleteRepository
    {
        Task<bool> DeleteSessao(int id);
    }
}