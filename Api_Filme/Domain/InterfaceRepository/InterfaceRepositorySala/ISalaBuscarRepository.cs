using Api_Filme.Domain.Model;

namespace Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySala
{
    public interface ISalaBuscarRepository
    {
        Task<IEnumerable<SalaModel>> BuscarSala();
    }
}