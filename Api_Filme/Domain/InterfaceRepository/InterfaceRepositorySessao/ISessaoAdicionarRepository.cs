using Api_Filme.Domain.Model;

namespace Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySessao
{
    public interface ISessaoAdicionarRepository
    {
        Task<bool> AdicionarSessao(SessoesModel sessoesModel);
    }
}