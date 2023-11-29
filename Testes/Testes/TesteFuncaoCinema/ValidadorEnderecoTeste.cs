using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api_Filme.Infrastructure.Repository.RepositoryCinema.FuncoesCinema;
using Api_Filme.Infrastructure.Repository.RepositoryCinema.FuncoesCinema.InterfaceFuncoesCinema;

namespace Testes.Testes.TesteFuncaoCinema
{
    public class ValidadorEnderecoTeste
    {
        public IValidadorEndereco _validadorEndereco;

        public ValidadorEnderecoTeste()
        {
            _validadorEndereco = new ValidadorEndereco();
        }

        [Test]
        [TestCase("Rua Alfredo Maya, 157", true)]
        [TestCase("Jabuticabeira", true)]
        public void ValidadorEndereco_Deve_Retornar_True(string endereco, bool resultadoEsperado)
        {
            _validadorEndereco.ValidadarEndereco(endereco);

            Assert.IsTrue(resultadoEsperado);
        }

        [Test]
        [TestCase(null, false)]
        [TestCase("Rua Opa", false)]
        public void ValidadorEndereco_Deve_Retornar_False(string endereço, bool resultadoEsperado)
        {
            _validadorEndereco.ValidadarEndereco(endereço);
            Assert.IsFalse(resultadoEsperado);
        }
    }
}
