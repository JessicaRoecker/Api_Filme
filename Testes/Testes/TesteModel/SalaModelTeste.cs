using Api_Filme.Domain.Model;

namespace Api_Filme.Testes.TesteModel
{
    public class SalaModelTeste
    {
        private SalaModel sala;

        public SalaModelTeste()
        {
            sala = new SalaModel();
        }

        [Test]
        public void SalaModel_Deve_Retornar_Todas_Propriedades()
        {
            //Act
            var sala = typeof(SalaModel);

            var propriedadesEsperadas = new List<string>() { "Id", "IdCinema", "Lugar" };
            var propriedades = sala.GetProperties().Select(p => p.Name).ToList();

            //Assert
            Assert.That(propriedades, Is.EquivalentTo(propriedadesEsperadas));

        }

        [Test]
        public void SalaModel_Deve_Retornar_Id_Inicializando0()
        {
            int id = 0;

            Assert.AreEqual(sala.Id, id);
        }

        [Test]
        public void SalaModel_Deve_Retornar_IdCinema_Inicializando0()
        {
            int id = 0;

            Assert.AreEqual(sala.IdCinema, id);
        }

        [Test]
        public void SalaModel_Deve_Retornar_Lugar_Inicializando0()
        {
            int id = 0;

            Assert.AreEqual(sala.Lugar, id);
        }
    }
}
