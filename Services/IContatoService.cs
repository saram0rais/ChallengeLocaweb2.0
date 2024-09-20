using ChallengeLocaweb.Models;
using System.Collections.Generic;

namespace ChallengeLocaweb.Services
{
    public interface IContatoService
    {
        IEnumerable<ContatoModel> ListarContatos();
        ContatoModel ObterContatoPorId(int id);
        void CriarContato(ContatoModel cliente);
        void AtualizarContato(ContatoModel cliente);
        void DeletarContato(int id);
    }
}
