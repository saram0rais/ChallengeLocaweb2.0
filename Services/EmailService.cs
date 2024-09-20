using ChallengeLocaweb.Models;

namespace ChallengeLocaweb.Services 
{
    public class EmailService: IEmailService
    {
        private readonly List<EmailModel> _bancoDeEmails = new();
        public List<EmailModel> ObterEmails()
        {
            return _bancoDeEmails;
        }

        public EmailModel ObterEmail(int id)
        {
            return _bancoDeEmails.FirstOrDefault(e => e.Id == id);
        }

        public void EnviarEmail(EmailModel email)
        {
            email.Id = _bancoDeEmails.Count + 1; 
            email.DataEnvio = DateTime.Now;  
            _bancoDeEmails.Add(email); 
        }

        public void AgendarEmail(EmailModel email, DateTime dataAgendada)
        {
            email.Id = _bancoDeEmails.Count + 1; 
            email.DataEnvio = dataAgendada;  
            _bancoDeEmails.Add(email);  
        }
    }
}