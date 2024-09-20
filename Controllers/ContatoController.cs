using ChallengeLocaweb.Services;
using ChallengeLocaweb.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocamailApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _servicoDeContato;

        public ContatoController(IContatoService servicoDeContato)
        {
            _servicoDeContato = servicoDeContato;
        }

        // GET: api/contato
        [HttpGet]
        public ActionResult<List<ContatoModel>> ObterContatos()
        {
            var contatos = _servicoDeContato.ListarContatos();
            return Ok(contatos);
        }

        // GET: api/contato/{id}
        [HttpGet("{id}")]
        public ActionResult<ContatoModel> ObterContatoPorId(int id)
        {
            var contato = _servicoDeContato.ObterContatoPorId(id);
            if (contato == null)
            {
                return NotFound();
            }
            return Ok(contato);
        }

        // POST: api/contato
        [HttpPost]
        public ActionResult AdicionarContato([FromBody] ContatoModel contato)
        {
            if (contato == null)
            {
                return BadRequest("Contato não pode ser nulo.");
            }
            _servicoDeContato.CriarContato(contato);
            return CreatedAtAction(nameof(ObterContatoPorId), new { id = contato.IdContato }, contato);
        }

        // PUT: api/contato/{id}
        [HttpPut("{id}")]
        public ActionResult AtualizarContato(int id, [FromBody] ContatoModel contato)
        {
            var contatoExistente = _servicoDeContato.ObterContatoPorId(id);
            if (contatoExistente == null)
            {
                return NotFound();
            }

            // Atualiza os dados do contato
            contato.IdContato = id;  
            _servicoDeContato.AtualizarContato(contato);
            return NoContent();
        }

        // DELETE: api/contato/{id}
        [HttpDelete("{id}")]
        public ActionResult ExcluirContato(int id)
        {
            var contato = _servicoDeContato.ObterContatoPorId(id);
            if (contato == null)
            {
                return NotFound();
            }
            _servicoDeContato.DeletarContato(id);
            return NoContent();
        }
    }
}
