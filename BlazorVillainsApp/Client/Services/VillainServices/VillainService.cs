﻿using System.Net.Http.Json;

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
    }
}
