using Api_Filme.Domain.Model;

namespace Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryFilme
{
    public interface IFilmeAtualizarRepository
    {
        Task<bool> AtualizarAsync(FilmeModel model, int id);
    }
}