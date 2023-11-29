using Api_Filme.Infrastructure.Repository.RepositoryCinema.FuncoesCinema.InterfaceFuncoesCinema;

namespace Api_Filme.Infrastructure.Repository.RepositoryCinema.FuncoesCinema
{
    public class ValidadorNome : IValidadorNome
    {
        public bool ValidadorNomeCinema(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return false;
            }
            nome = nome.Trim();

            if (nome.Length < 4)
            {
                return false;
            }
            return true;
        }
    }
}
