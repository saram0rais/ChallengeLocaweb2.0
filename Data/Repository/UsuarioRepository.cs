using ChallengeLocaweb.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeLocaweb.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UsuarioRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<UsuarioModel> GetAll() => _databaseContext.Usuarios.Include(c => c.UsuarioId).ToList();
        public UsuarioModel GetById(int id) => _databaseContext.Usuarios.Find(id);

        public void Add(UsuarioModel usuario)
        {
            _databaseContext.Usuarios.Add(usuario);
            _databaseContext.SaveChanges();
        }

        public void Delete(UsuarioModel usuario)
        {
            _databaseContext.Usuarios.Remove(usuario);
            _databaseContext.SaveChanges();
        }

        public void Update(UsuarioModel usuario)
        {
            _databaseContext.Usuarios.Update(usuario);
            _databaseContext.SaveChanges();
        }
    }
}
