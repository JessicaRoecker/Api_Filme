namespace Api_Filme.Infrastructure.Repository.RepositoryFilme.FuncoesFilme.InterfaceFuncaoFilme
{
    public interface IValidadorCampoFilmeNaoNulo
    {
        bool ValidarCamposFilmeNaoNull(string genero, string diretor, string titulo);
    }
}