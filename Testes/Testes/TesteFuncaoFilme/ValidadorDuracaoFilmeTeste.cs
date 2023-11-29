using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api_Filme.Infrastructure.Repository.RepositoryFilme.FuncoesFilme;

namespace Testes.Testes.TesteFuncaoFilme
{
    public class ValidadorDuracaoFilmeTeste
    {
        private ValidadorDuracaoFilme _validadorDuracao;

        [SetUp]
        public void Setup()
        {
            _validadorDuracao = new ValidadorDuracaoFilme();
        }

        [Test]
        public void ValidadorDuracaoFilme_Duracao_Minima_permitida()
        {
            int duracaoMinima = 40;
            bool resultado = _validadorDuracao.ValidadorDuracaoFilmes(duracaoMinima);

            Assert.IsTrue(resultado);
        }

        [Test]
        public void ValidadorDuracaoFilme_Duracao_Maxima_permitida()
        {
            int duracaoMaxima = 300;
            bool resultado = _validadorDuracao.ValidadorDuracaoFilmes(duracaoMaxima);

            Assert.IsTrue(resultado);
        }

        [Test]
        [TestCase(150, true)]
        [TestCase(200, true)]
        [TestCase(45, true)]
        [TestCase(299, true)]
        [TestCase(040, true)]
        public void ValidadorDuracaoFilme_Duracao_Entre_Os_Valores_Permitidos(int duracao, bool resultadoEsperado)
        {
            var resultado = _validadorDuracao.ValidadorDuracaoFilmes(duracao);

            Assert.AreEqual(resultado, resultadoEsperado);
        }

        [Test]
        [TestCase(301, false)]
        [TestCase(39, false)]
        [TestCase(400, false)]
        public void ValidadorDuracaoFilme_Duracao_Fora_dos_Valores_Permitidos(int duracao, bool resultadoEsperado)
        {
            var resultado = _validadorDuracao.ValidadorDuracaoFilmes(duracao);

            Assert.AreEqual(resultado, resultadoEsperado);
        }
    }
}
