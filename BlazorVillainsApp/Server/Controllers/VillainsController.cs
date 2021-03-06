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


        [HttpPost]
        
        public async Task<ActionResult<List<VillainModel>>> CreateVillain(VillainModel villain)
        {
            villain.Comic = null;
            _context.Villains.Add(villain);
            await _context.SaveChangesAsync();

            return Ok(await GetDbVillains());
        }

       

        [HttpPut("{id}")]
        public async Task<ActionResult<List<VillainModel>>> UpdateVillain(VillainModel villain, int id)
        {
            var dbVillain = await _context.Villains
                .Include(v => v.Comic)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (dbVillain == null)
            {
                return NotFound("Sorry Villain Not FOund");
            }

            dbVillain.FirstName = villain.FirstName;
            dbVillain.LastName = villain.LastName;
            dbVillain.VillainName = villain.VillainName;
            dbVillain.ComicId = villain.ComicId;

            await _context.SaveChangesAsync();

            return Ok(await GetDbVillains());
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<VillainModel>>> DeleteVillain(int id)
        {
            var dbVillain = await _context.Villains
                .Include(v => v.Comic)
                .FirstOrDefaultAsync(v => v.Id == id);
            if(dbVillain == null)
            {
                return NotFound("Sorry Villain Not Found");

            }

            _context.Villains.Remove(dbVillain);
            await _context.SaveChangesAsync();

            return Ok(await GetDbVillains());
        }


        private async Task<List<VillainModel>> GetDbVillains()
        {
            return await _context.Villains.Include(v => v.Comic).ToListAsync();

        }

    }
}
