using Api_Filme.Domain.Model;

namespace Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryFilme
{
    public interface IFilmeBuscarRepository
    {
        Task<IEnumerable<FilmeModel>> BuscarTodosFilmesAsync();
    }
}