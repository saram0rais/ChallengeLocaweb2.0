using ChallengeLocaweb.Models;
using System.Net.Mail;

namespace ChallengeLocaweb.Services
{
    public interface IDetectorSpamService
    {
            bool EhSpam(EmailModel email);
            void AddCaixaSpam(string email);
            void RemoverCaixaSpam(string email);
            List<string> GetCaixaSpam();

    }
}
