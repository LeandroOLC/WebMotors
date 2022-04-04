using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WM.WebApp.MVC.Models.DTO
{
    public class AnunciosDTO
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Version { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string Note { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int VersionId { get; set; }
    }
}
