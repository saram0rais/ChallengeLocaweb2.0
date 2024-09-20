using ChallengeLocaweb.Controllers;

namespace ChallengeLocaweb.Models
{
    public class UsuarioModel
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }

        public PreferenciaModel? Preferencia { get; set; }
        public int PreferenciaId { get; set; }
    }
}
