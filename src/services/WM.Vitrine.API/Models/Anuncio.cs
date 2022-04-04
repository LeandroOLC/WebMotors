using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WM.Vitrine.API.Models
{
    public class Anuncio
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Version { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string Note { get; set; }
    }
}