using Api_Filme.Infrastructure.Repository.RepositoryFilme.FuncoesFilme.InterfaceFuncaoFilme;

namespace Api_Filme.Infrastructure.Repository.RepositoryFilme.FuncoesFilme
{
    public class ValidadorDeAno : IValidadorDeAno
    {

        public DateTime DataAtual { get; }
        public DateTime DataAntiga { get; }

        public ValidadorDeAno()
        {
            DataAtual = DateTime.Now.Date;  
            DataAntiga = new DateTime(1895, 12, 28).Date; 
        }

        public bool ValidadorAno(DateTime dataCadastro)
        {
            return dataCadastro.Date >= DataAntiga && dataCadastro.Date <= DataAtual;
        }
    }

}

