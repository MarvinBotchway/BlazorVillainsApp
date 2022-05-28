using System.Net.Http.Json;

namespace BlazorVillainsApp.Client.Services.VillainServices
{
    public class VillainService : IVillainService
    {
        private readonly HttpClient _http;

        public VillainService(HttpClient http)
        {
            _http = http;
        }



        public List<ComicModel> Comics { get; set; } = new List<ComicModel>();
        public List<VillainModel> Villains { get; set; } = new List<VillainModel>();

        public Task GetComics()
        {
            throw new NotImplementedException();
        }

        public Task<VillainModel> GetSingleVillain(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task GetVillains()
        {
            var result = await _http.GetFromJsonAsync<List<VillainModel>>("api/villains");
            if (result != null) Villains = result;
        }
    }
}
