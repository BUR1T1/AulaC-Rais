using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Novaula.Data;
using Novaula.models;

namespace Pivete.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PiveteController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PiveteController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        
        [HttpPost]
        public async Task<IActionResult> AddPivete(PiveteModels pivete)
        {
            if (pivete == null)
                return BadRequest("não encontrado.");

            _appDbContext.pivetes.Add(pivete);
            await _appDbContext.SaveChangesAsync();
            return StatusCode(201, pivete);
        }

     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PiveteModels>>> GetPivete()
        {
            var pivetes = await _appDbContext.pivetes.ToListAsync();
            return Ok(pivetes);
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<PiveteModels>> GetPiveteById(int id)
        {
            var pivete = await _appDbContext.pivetes.FindAsync(id);
            if (pivete == null)
                return NotFound();

            return Ok(pivete);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<PiveteModels>>> GetByNome([FromQuery] string nome)
        {
            var resultados = await _appDbContext.pivetes
                .Where(p => p.Nome.Contains(nome))
                .ToListAsync();

            return Ok(resultados);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePivete(int id, PiveteModels piveteAtualizado)
        {
            var pivete = await _appDbContext.pivetes.FindAsync(id);
            if (pivete == null)
                return NotFound();

            pivete.Nome = piveteAtualizado.Nome;
            pivete.Idade = piveteAtualizado.Idade;

            await _appDbContext.SaveChangesAsync();
            return Ok(pivete);
        }

      
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePivete(int id)
        {
            var pivete = await _appDbContext.pivetes.FindAsync(id);
            if (pivete == null)
                return NotFound();

            _appDbContext.pivetes.Remove(pivete);
            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
