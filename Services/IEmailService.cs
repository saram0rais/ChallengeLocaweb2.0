using ChallengeLocaweb.Models;

namespace ChallengeLocaweb.Services
{
    public interface IEmailService
    {
            List<EmailModel> ObterEmails();
            EmailModel ObterEmail(int id);
            void EnviarEmail(EmailModel email);
            void AgendarEmail(EmailModel email, DateTime dataAgendada);
        }

}
