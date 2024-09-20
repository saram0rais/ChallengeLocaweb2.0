using Microsoft.AspNetCore.Mvc;
using ChallengeLocaweb.Models;
using ChallengeLocaweb.Services; 

namespace ChallengeLocaweb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserPreferencesController : ControllerBase
    {
        private readonly IPreferenciaService _preferenciasService;

        public UserPreferencesController(IPreferenciaService preferenciasService)
        {
            _preferenciasService = preferenciasService;
        }

        // GET: api/PreferenciasUsuario/{userId}
        [HttpGet("{userId}")]
        public async Task<ActionResult<PreferenciaModel>> GetPreferences(int userId)
        {
            var preferences = await _preferenciasService.ObterPreferenciaPorId(userId);

            if (preferences == null)
            {
                return NotFound();
            }

            return Ok(preferences);
        }

        // POST: api/PreferenciasUsuario
        [HttpPost]
        public async Task<ActionResult<PreferenciaModel>> PostPreferences(PreferenciaModel preference)
        {
            var savedPreference = await _preferenciasService.SalvarPreferencia(preference);

            return CreatedAtAction(nameof(GetPreferences), new { userId = savedPreference.UsuarioID }, savedPreference);
        }

        // PUT: api/PreferenciasUsuario/{userId}
        [HttpPut("{userId}")]
        public async Task<IActionResult> PutPreferences(int userId, PreferenciaModel preference)
        {
            if (userId != preference.UsuarioID)
            {
                return BadRequest();
            }

            try
            {
                await _preferenciasService.AtualizarPreferencia(userId, preference);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // DELETE: api/PreferenciasUsuario/{userId}
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeletePreferences(int userId)
        {
            try
            {
                await _preferenciasService.ExcluirPreferencia(userId);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
