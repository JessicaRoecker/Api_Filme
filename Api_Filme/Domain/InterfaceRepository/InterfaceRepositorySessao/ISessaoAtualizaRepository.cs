using Api_Filme.Domain.Model;

namespace Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySessao
{
    public interface ISessaoAtualizaRepository
    {
        Task<bool> AtualizarSessao(SessoesModel sessoesModel, int id);
    }
}