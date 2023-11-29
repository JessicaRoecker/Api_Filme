using Api_Filme.Infrastructure.Repository.RepositoryCinema.FuncoesCinema.InterfaceFuncoesCinema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Api_Filme.Infrastructure.Repository.RepositoryCinema.FuncoesCinema
{
    public class ValidadorTelefone : IValidadorTelefone
    {
        public bool ValidadorFone(decimal numero)
        {
            string numeroLimpo = new string(numero.ToString().Where(char.IsDigit).ToArray());

            if (numeroLimpo.Length == 11)
                if (numeroLimpo[2] == 9)
                    return true;
                else if (numeroLimpo.Length == 10)
                    return true;

            return false;

        }
    }
}
