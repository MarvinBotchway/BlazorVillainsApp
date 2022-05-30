using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorVillainsApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillainsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public VillainsController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<VillainModel>>> GetVillains()
        {
            var villains = await _context.Villains
                .Include(v => v.Comic)
                .ToListAsync();
            return Ok(villains);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<VillainModel>> GetSingleVillain(int? id)
        {
            var villain = await _context.Villains
                .Include(v => v.Comic)
                .FirstOrDefaultAsync<VillainModel>(v => v.Id == id);

            if (villain == null) 
            { 
                return BadRequest("No villain Here"); 
            }

            return Ok(villain);
        }


        [HttpGet]
        [Route("comics")]
        public async Task<ActionResult<List<ComicModel>>> GetComics()
        {
            var comics = await _context.Comics
                .ToListAsync();

            return Ok(comics);
        }





    }
}
