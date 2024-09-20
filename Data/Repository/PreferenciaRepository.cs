using ChallengeLocaweb.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeLocaweb.Data.Repository
{
    public class PreferenciaRepository : IPreferenciaRepository
    {
        private readonly DatabaseContext databaseContext;
        public PreferenciaRepository(DatabaseContext _databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<PreferenciaModel> GetAll() => databaseContext.Preferencias.Include(c => c.Id).ToList();
        public PreferenciaModel GetById(int id) => databaseContext.Preferencias.Find(id);

        public void Add(PreferenciaModel preferencia)
        {
            databaseContext.Preferencias.Add(preferencia);
            databaseContext.SaveChanges();
        }

        public void Delete(PreferenciaModel preferencia)
        {
            databaseContext.Preferencias.Remove(preferencia);
            databaseContext.SaveChanges();
        }

        public void Update(PreferenciaModel preferencia)
        {
            databaseContext.Update(preferencia);
            databaseContext.SaveChanges();
        }
    }
}
