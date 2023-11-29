using Api_Filme.Domain.Model;

namespace Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySessao
{
    public interface ISessaoBuscarRepository
    {
        Task<IEnumerable<SessoesModel>> BuscarTodasAsSessoes();
    }
}