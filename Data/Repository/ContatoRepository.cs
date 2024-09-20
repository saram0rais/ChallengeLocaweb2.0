using ChallengeLocaweb.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeLocaweb.Data.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ContatoRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<ContatoModel> GetAll() => _databaseContext.Contatos.Include(c => c.IdContato).ToList();
        public ContatoModel GetById(int id) => _databaseContext.Contatos.Find(id);

        public void Add(ContatoModel contato)
        {
            _databaseContext.Contatos.Add(contato);
            _databaseContext.SaveChanges();
        }

        public void Delete(ContatoModel contato)
        {
            _databaseContext.Contatos.Remove(contato);
            _databaseContext.SaveChanges();
        }
        
        public void Update(ContatoModel contato)
        {
            _databaseContext.Update(contato);
            _databaseContext.SaveChanges();
        }
    }
}
