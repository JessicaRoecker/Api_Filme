using Api_Filme.Domain.Model;

namespace Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryFilme
{
    public interface IFilmeBuscarIdRepository
    {
        Task<FilmeModel> BuscarFilmesIdAsync(int id);
    }
}