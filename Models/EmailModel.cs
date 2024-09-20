namespace ChallengeLocaweb.Models
{
    public class EmailModel
    {
        public int Id { get; set; }
        public string Remetente { get; set; }
        public string Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Texto { get; set; }
        public DateTime DataEnvio { get; set; }
        public bool VerificadorSpam { get; set; }
    }
}

