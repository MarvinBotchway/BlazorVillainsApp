using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorVillainsApp.Client.Services.VillainServices
{
    public class VillainService : IVillainService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public VillainService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }



        public List<ComicModel> Comics { get; set; } = new List<ComicModel>();
        public List<VillainModel> Villains { get; set; } = new List<VillainModel>();

        public async Task CreateVillain(VillainModel villain)
        {
            var result = await _http.PostAsJsonAsync<VillainModel>("api/villains", villain);
            await SetVillains(result);
        }

        public async Task DeleteVillain(int id)
        {
            var result = await _http.DeleteAsync($"api/villains/{id}");
            await SetVillains(result);
        }

        public async Task GetComics()
        {
            var result = await _http.GetFromJsonAsync<List<ComicModel>>("api/villains/comics");
            if (result != null) Comics = result;
        }

        public async Task<VillainModel> GetSingleVillain(int? id)
        {
            var result = await _http.GetFromJsonAsync<VillainModel>($"api/villains/{id}");
            if (result != null) return result;
            throw new Exception("Did not get a Villain Id");
        }

        public async Task GetVillains()
        {
            var result = await _http.GetFromJsonAsync<List<VillainModel>>("api/villains");
            if (result != null) Villains = result;
        }

        public async Task UpdateVillain(VillainModel villain)
        {
            var result = await _http.PutAsJsonAsync<VillainModel>($"api/villains/{villain.Id}", villain);
            await SetVillains(result);
        }


        private async Task SetVillains(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<VillainModel>>();
            if (response != null) Villains = response;
            _navigationManager.NavigateTo("villains");
        }

    }
}
