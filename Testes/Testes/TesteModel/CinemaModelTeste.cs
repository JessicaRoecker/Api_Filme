using Api_Filme.Domain.Model;
using NUnit;

namespace Api_Filme.Testes.TesteModel
{
    public class CinemaModelTeste
    {
        private CinemaModel cinema;

        public CinemaModelTeste()
        {
            cinema = new CinemaModel();
        }

        [Test]
        public void CinemaModel_Deve_Retornar_Todas_Propriedades()
        {
            var cinema = typeof(CinemaModel);
            var propriedadesEsperadas = new List<string> { "Id", "Nome", "Endereco", "Telefone" };
            var propriedades = cinema.GetProperties().Select(p => p.Name).ToList();

           Assert.That(propriedades, Is.EquivalentTo(propriedadesEsperadas));
        }

        [Test]
        public void CinemaModel_Deve_Retornar_Id_Inicializado0()
        {
            int id = 0;

            Assert.AreEqual(cinema.Id, id);
        }

        [Test]
        public void CinemaModel_Deve_Retornar_Nome_Inicializado_Null()
        {
            Assert.Null(cinema.Nome);
        }

        [Test]
        public void CinemaModel_Deve_Retornar_Endereco_Inicializado_Null()
        {
            Assert.Null(cinema.Endereco);

        }

        [Test]
        public void CinemaModel_Deve_Retornar_Telefone_Inicializado0()
        {
            int telefone = 0;

            Assert.AreEqual(cinema.Telefone, telefone);
        }

    }
}
