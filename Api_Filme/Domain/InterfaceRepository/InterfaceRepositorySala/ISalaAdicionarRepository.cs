using Api_Filme.Domain.Model;

namespace Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySala
{
    public interface ISalaAdicionarRepository
    {
        Task<bool> AdicionarSala(SalaModel salaModel);
    }
}