using ChallengeLocaweb.Models;

namespace ChallengeLocaweb.Data.Repository
{
    public interface IPreferenciaRepository
    {
        IEnumerable<PreferenciaModel> GetAll();
        PreferenciaModel GetById(int id);
        void Add(PreferenciaModel preferencia);
        void Update(PreferenciaModel preferencia);
        void Delete(PreferenciaModel preferencia);
    }
}
