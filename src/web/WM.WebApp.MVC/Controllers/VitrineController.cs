using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WM.WebApp.MVC.Models;
using WM.WebApp.MVC.Services;

namespace WM.WebApp.MVC.Controllers
{
    public class VitrineController : Controller
    {
        private readonly IVitrineService _vitrineService;

        public VitrineController(IVitrineService vitrineService)
        {
            _vitrineService = vitrineService;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _vitrineService.GetVehicles(1));
        }

        public async Task<ActionResult> VitrineDetalhe()
        {
            return View(await _vitrineService.GetVehicles(1));
        }
    }
}
