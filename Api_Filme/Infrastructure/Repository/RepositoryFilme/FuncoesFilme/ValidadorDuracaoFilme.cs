using Api_Filme.Infrastructure.Repository.RepositoryFilme.FuncoesFilme.InterfaceFuncaoFilme;

namespace Api_Filme.Infrastructure.Repository.RepositoryFilme.FuncoesFilme
{
    public class ValidadorDuracaoFilme : IValidadorDuracaoFilme
    {
        public bool ValidadorDuracaoFilmes(int duracao)
        {
            
            return duracao >= 40 && duracao <= 300;
        }
    }
}
