using ChallengeLocaweb.Models;  
using ChallengeLocaweb.Services; 
using Microsoft.AspNetCore.Mvc;  

namespace ChallengeLocaweb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _servicoDeEmail;

        public EmailController(IEmailService servicoDeEmail)
        {
            _servicoDeEmail = servicoDeEmail;
        }

        [HttpGet]
        public ActionResult<List<EmailModel>> ObterEmails()
        {
            var emails = _servicoDeEmail.ObterEmails();
            return Ok(emails);
        }

        [HttpGet("{id}")]
        public ActionResult<EmailModel> ObterEmail(int id)
        {
            var email = _servicoDeEmail.ObterEmail(id);
            if (email == null)
            {
                return NotFound();
            }
            return Ok(email);
        }

        [HttpPost]
        public ActionResult EnviarEmail([FromBody] EmailModel email)
        {
            if (email == null)
            {
                return BadRequest("E-mail não pode ser nulo.");
            }
            _servicoDeEmail.EnviarEmail(email);
            return CreatedAtAction(nameof(ObterEmail), new { id = email.Id }, email);
        }

        [HttpPost("agendar")]
        public ActionResult AgendarEmail([FromBody] EmailModel email, [FromQuery] DateTime dataAgendada)
        {
            if (email == null)
            {
                return BadRequest("E-mail não pode ser nulo.");
            }
            _servicoDeEmail.AgendarEmail(email, dataAgendada);
            return CreatedAtAction(nameof(ObterEmail), new { id = email.Id }, email);
        }
    }
}
