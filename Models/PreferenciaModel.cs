namespace ChallengeLocaweb.Models
{
    public class PreferenciaModel
    {
        public int Id { get; set; }
        public string Tema { get; set; }
        public string Cor { get; set; }
        public List<string> Categoria { get; set; }
        public List<string> Etiqueta { get; set; }

        public UsuarioModel? Usuario { get; set; }
        public int UsuarioID { get; set; }
    }
}
