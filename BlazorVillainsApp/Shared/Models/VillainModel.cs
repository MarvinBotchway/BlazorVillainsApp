using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorVillainsApp.Shared.Models
{
    public class VillainModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string VillainName { get; set; } = string.Empty;
        public ComicModel Comic { get; set; } = new ComicModel();
        public int ComicId { get; set; }
    }
}
