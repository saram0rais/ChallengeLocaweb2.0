using ChallengeLocaweb.Models;

namespace ChallengeLocaweb.Data.Repository
{
    public interface IUsuarioRepository
    {
        IEnumerable<UsuarioModel> GetAll();
        UsuarioModel GetById(int id);
        void Add(UsuarioModel usuario);
        void Update(UsuarioModel usuario);
        void Delete(UsuarioModel usuario);
    }
}
