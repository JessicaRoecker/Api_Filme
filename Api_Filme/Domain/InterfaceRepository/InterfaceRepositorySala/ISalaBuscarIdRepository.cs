using Api_Filme.Domain.Model;

namespace Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySala
{
    public interface ISalaBuscarIdRepository
    {
        Task<SalaModel> BuscarSalaId(int id);
    }
}