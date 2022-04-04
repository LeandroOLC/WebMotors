using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WM.Vitrine.API.Models;
using WM.Vitrine.API.Services;
using WM.WebAPI.Core.Controllers;


namespace WM.Vitrine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleInformationController : MainController
    {
        public readonly ICarsService _carsService;

        public VehicleInformationController(ICarsService carsService)
        {
            _carsService = carsService;
        }

        [HttpGet("makes")]
        public async Task<IActionResult> GetMakes()
        {
            var make = await _carsService.GetMake();
       
            if (make == null || !make.Any())
            {
                AdicionarErroProcessamento("Produtos não encontrados.");
                return CustomResponse();
            }

            return CustomResponse(make);
        }

        [HttpGet("models/{id}")]
        public async Task<IActionResult> GetModels(int id)
        {
            var models = await _carsService.GetModels(id);

            if (models == null || !models.Any())
            {
                AdicionarErroProcessamento("Modelos não encontrados.");
                return CustomResponse();
            }

            return CustomResponse(models);
        }

        [HttpGet("vehicles/{id}")]
        public async Task<IActionResult> GetVehicles(int id)
        {
            var vehicles = await _carsService.GetVehicles(id);

            if (vehicles == null || !vehicles.Any())
            {
                AdicionarErroProcessamento("Veículos não encontrados.");
                return CustomResponse();
            }

            return CustomResponse(vehicles);
        }

        [HttpGet("versions/{id}")]
        public async Task<IActionResult> GetVersion(int id)
        {
            var vehicles = await _carsService.GetVersion(id);

            if (vehicles == null || !vehicles.Any())
            {
                AdicionarErroProcessamento("Versões não encontrados.");
                return CustomResponse();
            }

            return CustomResponse(vehicles);
        }
    }
}
