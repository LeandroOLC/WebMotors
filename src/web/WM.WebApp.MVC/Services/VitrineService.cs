using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WM.WebAPI.Core.Communication;
using WM.WebApp.MVC.Extensions;
using WM.WebApp.MVC.Models;
using WM.WebApp.MVC.Models.DTO;

namespace WM.WebApp.MVC.Services
{
    public class VitrineService : Service, IVitrineService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        public VitrineService(HttpClient httpClient,
                              IOptions<AppSettings> settings, 
                              IMapper mapper)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.VitrinesUrl);
            _mapper = mapper;
        }

        public async Task<bool> Create(AnunciosDTO anunciosDTO)
        {
            var anunciosContent = ObterConteudo(anunciosDTO);

            var response = await _httpClient.PostAsync($"/api/anuncio", anunciosContent);

            return TratarErrosResponse(response);
        }

        public async Task<bool> Edit(AnunciosDTO anunciosDTO)
        {
            var anunciosContent = ObterConteudo(anunciosDTO);

            var response = await _httpClient.PutAsync($"/api/anuncio", anunciosContent);

            return TratarErrosResponse(response);
        }

        public async Task<List<AnunciosViewModel>> Get()
        {
            var response = await _httpClient.GetAsync($"/api/anuncio");

            if (!TratarErrosResponse(response)) return new List<AnunciosViewModel>();

            var anunciosDTO = await DeserializarObjetoResponse<List<AnunciosDTO>>(response);

            return _mapper.Map<List<AnunciosViewModel>>(anunciosDTO);
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/anuncio/{id}");

            return TratarErrosResponse(response);
        }

        public async Task<AnunciosViewModel> GetId(int id)
        {
            var response = await _httpClient.GetAsync($"/api/anuncio/{id}");

            if (!TratarErrosResponse(response)) return new AnunciosViewModel();

            var anunciosDTO = await DeserializarObjetoResponse<AnunciosDTO>(response);

            return _mapper.Map<AnunciosViewModel>(anunciosDTO);
        }

        public async Task<List<MakeViewModel>> GetMake()
        {
            var response = await _httpClient.GetAsync($"/api/VehicleInformation/makes");

            if (!TratarErrosResponse(response)) return new List<MakeViewModel>();

            return await DeserializarObjetoResponse<List<MakeViewModel>>(response);
        }

        public async Task<List<ModelViewModel>> GetModels(int id)
        {
            var response = await _httpClient.GetAsync($"/api/VehicleInformation/models/{id}");

            if (!TratarErrosResponse(response)) return new List<ModelViewModel>();

            return await DeserializarObjetoResponse<List<ModelViewModel>>(response);
        }

        public async Task<List<VehicleViewModel>> GetVehicles(int id)
        {
            var response = await _httpClient.GetAsync($"/api/VehicleInformation/vehicles/{id}");

            if (!TratarErrosResponse(response)) return new List<VehicleViewModel>();

            return await DeserializarObjetoResponse<List<VehicleViewModel>>(response);
        }

        public async Task<List<VersionsViewModel>> GetVersion(int id)
        {
            var response = await _httpClient.GetAsync($"/api/VehicleInformation/versions/{id}");

            if (!TratarErrosResponse(response)) return new List<VersionsViewModel>();

            return await DeserializarObjetoResponse<List<VersionsViewModel>>(response);
        }
    }
    public interface IVitrineService
    {
        Task<List<MakeViewModel>> GetMake();
        Task<List<ModelViewModel>> GetModels(int id);
        Task<List<VehicleViewModel>> GetVehicles(int id);
        Task<List<VersionsViewModel>> GetVersion(int id);
        Task<bool> Create(AnunciosDTO anunciosDTO);
        Task<bool> Edit(AnunciosDTO anunciosDTO);
        Task<AnunciosViewModel> GetId(int id);
        Task<List<AnunciosViewModel>> Get();
        Task<bool> Delete(int id);
    }
}
