namespace Api_Filme.Domain.Model
{
    public class SessoesModel
    {
        public int Id { get; set; }
        public DateTime Horario { get; set; }
        public string Assento { get; set; }
        public int IdFilme { get; set; }
        public int IdSala { get; set; }
    }
}
