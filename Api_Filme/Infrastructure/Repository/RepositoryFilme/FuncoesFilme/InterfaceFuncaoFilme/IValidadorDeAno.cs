namespace Api_Filme.Infrastructure.Repository.RepositoryFilme.FuncoesFilme.InterfaceFuncaoFilme
{
    public interface IValidadorDeAno
    {
        DateTime DataAntiga { get; }
        DateTime DataAtual { get; }

        bool ValidadorAno(DateTime dataCadastro);
    }
}