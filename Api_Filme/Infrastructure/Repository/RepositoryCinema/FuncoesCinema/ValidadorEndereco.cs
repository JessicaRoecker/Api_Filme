using Api_Filme.Infrastructure.Repository.RepositoryCinema.FuncoesCinema.InterfaceFuncoesCinema;

namespace Api_Filme.Infrastructure.Repository.RepositoryCinema.FuncoesCinema
{
    public class ValidadorEndereco : IValidadorEndereco
    {
        public bool ValidadarEndereco(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                return false;
            if (endereco.Length < 10)
                return false;

            return true;
        }
    }
}
