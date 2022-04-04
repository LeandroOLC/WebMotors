using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WM.Vitrine.API.Extensions;
using WM.Vitrine.API.Models;
using WM.Vitrine.API.Models.Models.Exceptions;
using WM.WebAPI.Core.Communication;

namespace WM.Vitrine.API.Services
{
    public class CarsService : Service, ICarsService
    {
        private readonly HttpClient _httpClient;

        public CarsService(HttpClient httpClient,
                           IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.WebMotorsUrl);
        }

        public async Task<List<Make>> GetMake()
        {
            var response = await _httpClient.GetAsync($"/api/OnlineChallenge/Make");

            if (!TratarErrosResponse(response)) throw new CarException($"Não foi possível buscar os carros. {response.RequestMessage.Content}");

            return await DeserializarObjetoResponse<List<Make>>(response);
        }

        public async Task<List<Model>> GetModels(int id)
        {
            var response = await _httpClient.GetAsync($"/api/OnlineChallenge/Model?MakeID={id}");

            if (!TratarErrosResponse(response)) throw new CarException($"Não foi possível buscar os modelos. {response.RequestMessage.Content}");

            return await DeserializarObjetoResponse<List<Model>>(response);
        }

        public async Task<List<Vehicle>> GetVehicles(int page)
        {
            var response = await _httpClient.GetAsync($"/api/OnlineChallenge/Vehicles?Page={page}");

            if (!TratarErrosResponse(response)) throw new CarException($"Não foi possível buscar os veículos. {response.RequestMessage.Content}");

            var vehicles = await DeserializarObjetoResponse<List<Vehicle>>(response);

            vehicles.ForEach(v => v.Image = v.Image.Replace("http", "https"));

            return vehicles;
        }

        public async Task<List<Versions>> GetVersion(int id)
        {
            var response = await _httpClient.GetAsync($"/api/OnlineChallenge/Version?ModelID={id}");

            if (!TratarErrosResponse(response)) throw new CarException($"Não foi possível buscar as versões. {response.RequestMessage.Content}");

            return await DeserializarObjetoResponse<List<Versions>>(response);
        }
    }
}
