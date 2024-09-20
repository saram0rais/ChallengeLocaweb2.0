using ChallengeLocaweb.Models;

namespace ChallengeLocaweb.Data.Repository
{
    public interface IContatoRepository
    {
        IEnumerable<ContatoModel> GetAll();
        ContatoModel GetById(int id);
        void Add(ContatoModel contato);
        void Update(ContatoModel contato);
        void Delete(ContatoModel contato);
    }
}
