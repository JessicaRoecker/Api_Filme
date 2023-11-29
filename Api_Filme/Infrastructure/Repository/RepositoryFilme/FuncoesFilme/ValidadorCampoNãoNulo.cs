using Api_Filme.Domain.Model;
using Api_Filme.Infrastructure.Repository.RepositoryFilme.FuncoesFilme.InterfaceFuncaoFilme;

namespace Api_Filme.Infrastructure.Repository.RepositoryFilme.FuncoesFilme
{
    public class ValidadorCampoFilmeNaoNulo : IValidadorCampoFilmeNaoNulo
    {
        public bool ValidarCamposFilmeNaoNull(string genero, string diretor, string titulo)
        {

            return genero != null && diretor != null && titulo != null;
        }
    }

}
