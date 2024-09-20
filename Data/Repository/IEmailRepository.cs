using ChallengeLocaweb.Models;

namespace ChallengeLocaweb.Data.Repository
{
    public interface IEmailRepository
    {
        IEnumerable<EmailModel> GetAll();
        EmailModel GetById(int id);
        void Add(EmailModel email);
        void Update(EmailModel email);
        void Delete(EmailModel email);
    }
}
