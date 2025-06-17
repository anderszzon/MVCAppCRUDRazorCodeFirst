using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCAppCRUDRazorCodeFirst.Data;
using MVCAppCRUDRazorCodeFirst.Models;

namespace MVCAppCRUDRazorCodeFirst.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtletaAPIController : ControllerBase
    {
        private readonly AppDBContext _context;

        public AtletaAPIController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ObtenerAtletlas")]
        public async Task<ActionResult<List<Atletlas>>> GetAll()
        {
            return await _context.Atletlas.ToListAsync();
        }
    }

}

