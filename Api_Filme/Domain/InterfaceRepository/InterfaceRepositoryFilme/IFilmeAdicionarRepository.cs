using Api_Filme.Domain.Model;

namespace Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryFilme
{
    public interface IFilmeAdicionarRepository
    {
        Task<bool> AdicionarAsync(FilmeModel model);
    }
}