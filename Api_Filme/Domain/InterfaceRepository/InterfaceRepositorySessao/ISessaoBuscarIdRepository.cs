using Api_Filme.Domain.Model;

namespace Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySessao
{
    public interface ISessaoBuscarIdRepository
    {
        Task<SessoesModel> BuscarSessoesId(int id);
    }
}