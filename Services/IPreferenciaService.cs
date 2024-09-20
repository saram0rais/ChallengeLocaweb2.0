using ChallengeLocaweb.Models;

namespace ChallengeLocaweb.Services
{
    public interface IPreferenciaService
    {
        Task <PreferenciaModel> ObterPreferenciaPorId(int usuarioId);
        Task <PreferenciaModel> SalvarPreferencia(PreferenciaModel preferencia);
        Task AtualizarPreferencia(int usuarioId, PreferenciaModel preferencia);
        Task ExcluirPreferencia(int usuarioId);

    }
}
