using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api_Filme.Infrastructure.Repository.RepositoryCinema.FuncoesCinema;
using Api_Filme.Infrastructure.Repository.RepositoryCinema.FuncoesCinema.InterfaceFuncoesCinema;

namespace Testes.Testes.TesteFuncaoCinema
{
    public class ValidadorNomeTeste
    {
        public IValidadorNome _validadorNome;

        public ValidadorNomeTeste()
        {
            _validadorNome = new ValidadorNome();
        }

        [Test]
        [TestCase("Jessica Roecker", true)]
        [TestCase("Jessica", true)]
        [TestCase("Jessica Roecker Arns Bolduan", true)]
        public void ValidadorNome_Deve_Retornar_True(string nome, bool resultadoEsperado)
        {
            _validadorNome.ValidadorNomeCinema(nome);
            Assert.IsTrue(resultadoEsperado);
        }

        [Test]
        [TestCase("Je",false)]
        [TestCase(null, false)]
        [TestCase("    ", false)]
        public void ValidadorNome_Deve_Retornar_False(string nome, bool resultadoEsperado)
        {
            _validadorNome.ValidadorNomeCinema(nome);
            Assert.IsFalse(resultadoEsperado);
        }
    }
}
