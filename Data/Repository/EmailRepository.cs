using ChallengeLocaweb.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeLocaweb.Data.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly DatabaseContext databaseContext;
        public EmailRepository(DatabaseContext _databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public IEnumerable<EmailModel> GetAll() => databaseContext.Emails.Include(c => c.Id).ToList();
        public EmailModel GetById(int id) => databaseContext.Emails.Find(id);

        public void Add(EmailModel email)
        {
            databaseContext.Emails.Add(email);
            databaseContext.SaveChanges();
        }

        public void Delete(EmailModel email)
        {
            databaseContext.Emails.Remove(email);
            databaseContext.SaveChanges();
        }

        public void Update(EmailModel email)
        {
            databaseContext.Update(email);
            databaseContext.SaveChanges();
        }
    }
}
