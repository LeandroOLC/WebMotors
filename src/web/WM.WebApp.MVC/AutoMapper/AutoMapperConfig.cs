using AutoMapper;
using System.Collections.Generic;
using WM.WebApp.MVC.Models;
using WM.WebApp.MVC.Models.DTO;

namespace WM.WebApp.MVC.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AnunciosDTO, AnunciosViewModel>().ReverseMap();

            //CreateMap<List<AnunciosDTO>, List<AnunciosViewModel>>().ReverseMap();
        }
    }
}
