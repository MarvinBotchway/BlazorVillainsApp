namespace BlazorVillainsApp.Client.Services.VillainServices
{
    public interface IVillainService
    {
        public List<ComicModel> Comics { get; set; }
        public List<VillainModel> Villains { get; set; }

        Task GetComics();
        Task GetVillains();
        Task<VillainModel> GetSingleVillain(int? id);
    }
}
