using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api_Filme.Infrastructure.Repository.RepositoryFilme.FuncoesFilme;
using NUnit;

namespace Testes.Testes.TesteFuncaoFilme
{
    public class ValidadorDeAnoTeste
    {
        private ValidadorDeAno _valiadorAno;

        [SetUp]
        public void Setup()
        {
            _valiadorAno = new ValidadorDeAno();
        }

        [Test]
        public void ValidadorDeAno_Deve_Retornar_True() 
        {
            var dataAntiga = new DateTime(1985, 12, 25);
            bool resultado = _valiadorAno.ValidadorAno(dataAntiga);

           Assert.IsTrue(resultado);
        }

        [Test]
        public void ValidadorDeAno_Deve_Retornar_True_Com_Data_Atual()
        {
            var dataAtua = DateTime.Now;
            bool resultado = _valiadorAno.ValidadorAno(dataAtua);
            
            Assert.IsTrue(resultado);
        }

        [Test]
        public void ValidadorDeAno_Deve_Retornar_False_Data_Maior_Que_Data_Atual()
        {
            var data = new DateTime(2023, 11, 28);
            bool resultado = _valiadorAno.ValidadorAno(data);

            Assert.IsFalse(resultado);
        }

        [Test]
        public void ValidadorDeAno_Deve_Retornar_False_Data_Menor_Que_Data_Minima()
        {
            var data = new DateTime(1895, 12, 24);
            bool resultado = _valiadorAno.ValidadorAno(data);

            Assert.IsFalse(resultado);
        }
    }
}
