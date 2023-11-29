namespace Api_Filme.Domain.Model
{
    public class FilmeModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime Ano_Lancamento { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
    }
}
