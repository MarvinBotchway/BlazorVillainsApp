using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorVillainsApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillainsController : ControllerBase
    {
        public static List<ComicModel> comics = new List<ComicModel>()
        {
            new ComicModel() {Id = 1, Name = "DC" },
            new ComicModel() {Id = 2, Name = "Marvel" }
        };

        public static List<VillainModel> villains = new List<VillainModel>()
        {
            new VillainModel()
            {
                Id = 1,
                FirstName = "Jack",
                LastName = "Napier",
                VillainName = "Venom",
                Comic =  comics[1],
                ComicId = 2
            },
            new VillainModel()
            {
                Id = 2,
                FirstName = "Eddie",
                LastName = "Brock",
                VillainName = "Joker",
                Comic =  comics[0],
                ComicId = 1
            }
        };


        [HttpGet]
        public async Task<ActionResult<List<VillainModel>>> GetVillains()
        {
            return Ok(villains);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<VillainModel>> GetSingleVillain(int? id)
        {
            var villain = villains.FirstOrDefault<VillainModel>(v => v.Id == id);
            if (villain == null) return BadRequest("No villain Here");
            return Ok(villain);
        }


        [HttpGet]
        [Route("comics")]
        public async Task<ActionResult<List<ComicModel>>> GetComics()
        {
            return Ok(comics);
        }





    }
}
