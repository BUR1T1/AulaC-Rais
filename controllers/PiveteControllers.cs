using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Novaula.Data;
using NovaAula.models;


namespace Pivete.controlles 
{
    [ApiController]
    [Route("api/[controller]")]
    public class Pivetecontrollers : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public Pivetecontrollers(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Addpivete(Paciente paciente)
        {
            if (paciente == null)
            {
                return BadRequest("Não deu boa...");
            }

            _appDbContext.Pacientes.Add(paciente);
            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, paciente);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPivete() 
        {
            var pivetes = await _appDbContext.Pacientes.ToListAsync();

            return Ok(pivetes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pivetecontrollers>> GetPivete(int id)  
        {
            var pivete = await _appDbContext.Pacientes.FindAsync(id);

            if (pivete == null)
            {
                return NotFound("Não tem nada aqui fela");
            }

            return Ok(pivete);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePivete(int id, [FromBody] Pivetecontrollers piveteAtualizado) 
        {
            var piveteVivo = await _appDbContext.Pacientes.FindAsync(id);

            if (piveteVivo == null)
            {
                return NotFound("Não tem sa porra...");
            }

            _appDbContext.Entry(piveteVivo).CurrentValues.SetValues(piveteAtualizado);

            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, piveteVivo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarMLK(int id)
        {
            var pivete = await _appDbContext.Pacientes.FindAsync(id);

            if (pivete == null)
            {
                return NotFound("Não tem esse pivete pra chutar....");
            }

            _appDbContext.Pacientes.Remove(pivete);

            await _appDbContext.SaveChangesAsync();

            return Ok("Pivete chutado com sucesso!!!");
        }
    }
}
