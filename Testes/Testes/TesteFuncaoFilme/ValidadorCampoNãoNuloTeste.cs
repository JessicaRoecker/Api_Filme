using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api_Filme.Infrastructure.Repository.RepositoryFilme.FuncoesFilme;

namespace Testes.Testes.TesteFuncaoFilme
{
    public class ValidadorCampoNãoNuloTeste
    {
        private ValidadorCampoFilmeNaoNulo _validador;

        [SetUp]
        public void Setup()
        {
            _validador = new ValidadorCampoFilmeNaoNulo();
        }

        [Test]
        public void ValidadorCampoNãoNulo_Deve_Retornar_Nao_Nulo()
        {
            
           bool resultado = _validador.ValidarCamposFilmeNaoNull("Genero", "Titulo", "Diretor");

            Assert.IsNotNull(resultado);
        }

        [Test]
        public void Deve_Retornar_False_Quando_Um_Campo_Nao_E_Nulo()
        {

            bool resultado = _validador.ValidarCamposFilmeNaoNull("Ação", null, null);

            Assert.IsFalse(resultado);
        }

        [Test]
        public void Deve_Retornar_False_Quando_Todos_Os_Campos_Sao_Nulos()
        {
            bool resultado = _validador.ValidarCamposFilmeNaoNull(null, null, null);

            Assert.IsFalse(resultado);
        }


    }
}
