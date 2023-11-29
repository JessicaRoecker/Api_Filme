namespace Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryFilme
{
    public interface IFilmeDeleteRepository
    {
        Task<bool> DeletarAsync(int id);
    }
}