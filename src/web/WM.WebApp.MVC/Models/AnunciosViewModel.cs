using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WM.WebApp.MVC.Models
{
    public class AnunciosViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Marca")]
        public string Make { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Modelo")]
        public string Model { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Versão")]
        public string Version { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Ano do veículo")]
        public int Year { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Quilometragem do veículo")]
        public int Mileage { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Descrição")]
        public string Note { get; set; }


        [NotMapped]
        public IEnumerable<MakeViewModel> Makes { get; set; }

        [NotMapped]
        public IEnumerable<ModelViewModel> Models { get; set; }

        [NotMapped]
        public IEnumerable<VersionsViewModel> Versions { get; set; }


        public AnunciosViewModel()
        {
            Models = new List<ModelViewModel>();
            Makes = new List<MakeViewModel>();
            Versions = new List<VersionsViewModel>();
        }
    }
}