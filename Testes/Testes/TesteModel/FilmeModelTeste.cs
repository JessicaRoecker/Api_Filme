using Api_Filme.Domain.Model;

namespace Api_Filme.Testes.TesteModel
{
    public class FilmeModelTeste
    {
        private FilmeModel filme;

        public FilmeModelTeste()
        {
            filme = new FilmeModel();
        }

        [Test]
        public void FilmeModel_Deve_Retornar_Todas_Propriedades()
        {
            var filme = typeof(FilmeModel);
            var propriedadesEsperadas = new List<string> {"Id", "Titulo", "Ano_Lancamento", "Diretor", "Genero", "Duracao" };
            var propriedades = filme.GetProperties().Select(p => p.Name).ToList();

            Assert.That(propriedades, Is.EquivalentTo(propriedadesEsperadas));
        }

        [Test]
        public void FilmeModel_Deve_Retornar_Id_Inicializando0()
        {
            int id = 0;

            Assert.AreEqual(filme.Id, id);
        }

        [Test]
        public void FilmeModel_Deve_Retornar_Titulo_Inicializando_Null()
        {
            Assert.IsNull(filme.Titulo);
        }

        [Test]
        public void FilmeModel_Deve_Retornar_Ano_Lancamento_Inicializando_DateTimeMIN()
        {
            Assert.AreEqual(DateTime.MinValue, filme.Ano_Lancamento);
        }

        [Test]
        public void FilmeModel_Deve_Retornar_Diretor_Inicializando_Null()
        {
            Assert.Null(filme.Diretor);
        }

        [Test]
        public void FilmeModel_Deve_Retornar_Genero_Inicializando_Null()
        {
            Assert.Null(filme.Genero);
        }

        [Test]
        public void FilmeModel_Deve_Retornar_Duracao_Inicializando0()
        {
            int id = 0;
            Assert.AreEqual(filme.Duracao, id);
        }
    }
}
