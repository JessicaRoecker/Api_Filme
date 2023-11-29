using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api_Filme.Infrastructure.Repository.RepositoryCinema.FuncoesCinema;
using Api_Filme.Infrastructure.Repository.RepositoryCinema.FuncoesCinema.InterfaceFuncoesCinema;

namespace Testes.Testes.TesteFuncaoCinema
{
    public class ValidadorTelefoneTeste
    {
        public IValidadorTelefone _validadorTelefone;

        public ValidadorTelefoneTeste()
        {
            _validadorTelefone = new ValidadorTelefone();
        }

        [Test]
        [TestCase("47991825709", true)]
        [TestCase("4734325986", true)]
        public void ValidadorTelefoneTeste_Deve_Retornar_True(string telefone, bool resultadoEsperado)
        {
            _validadorTelefone.ValidadorFone(telefone);
            
            Assert.IsTrue(resultadoEsperado);
        }

        [Test]
        [TestCase("47815936248", false)]
        [TestCase("34325986", false)]
        [TestCase("4799182570", false)]
        public void ValidadorTelefoneTeste_Deve_Retornar_False(string telefone, bool resultadoEsperado)
        {
            _validadorTelefone.ValidadorFone(telefone);

            Assert.IsFalse(resultadoEsperado);
        }

        [Test]
        [TestCase("47-991855706", true)]
        [TestCase("(47)991825709", true)]
        public void ValidadorTelefoneTeste_Deve_Retornar_True_Sem_CaracteresNaoNumericos(string telefone, bool resultadoEsperado)
        {
            _validadorTelefone.ValidadorFone(telefone);

            Assert.IsTrue(resultadoEsperado);
        }

    }
}
