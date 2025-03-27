using Microsoft.AspNetCore.Mvc;
using Novaula.Data;

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
    }
}