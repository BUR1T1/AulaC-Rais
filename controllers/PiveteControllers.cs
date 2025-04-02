using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Novaula.Data;
using Novaula.models;

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
        public async Task<IActionResult> Addpivete(Novaula.models.Pivete pivete){

            if (pivete == null)
            {
                return BadRequest("Não deu boa...");
            }

            _appDbContext.pivetes.Add(pivete);
            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, pivete);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pivetecontrollers>>> GetPivete()
        {

            var Pivete = await _appDbContext.pivetes.ToListAsync();

            return Ok(Pivete);

        }

    }
}