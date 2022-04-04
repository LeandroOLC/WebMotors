using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WM.WebApp.MVC;
using WM.WebApp.MVC.Models;
using WM.WebApp.MVC.Models.DTO;
using WM.WebApp.MVC.Services;

namespace WM.WebApp.MVC.Controllers
{
    public class AnunciosController : Controller
    {
        private readonly IVitrineService _vitrineService;
        private readonly IMapper _mapper;
        public AnunciosController(IVitrineService vitrineService,
                                  IMapper mapper)
        {
            _vitrineService = vitrineService;
            _mapper = mapper;
        }

        // GET: Anuncios
        public async Task<IActionResult> Index()
        {
            return View(await _vitrineService.Get());
        }

        // GET: Anuncios/Create
        public async Task<IActionResult> Create()
        {
            var anunciosViewModel = new AnunciosViewModel
            {
                Makes = await _vitrineService.GetMake()
            };

            return View(anunciosViewModel);
        }

        // POST: Anuncios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Make,Model,Version,Year,Mileage,Note")] AnunciosViewModel anunciosViewModel)
        {
            if (ModelState.IsValid)
            {
                var anuncios = _mapper.Map<AnunciosDTO>(anunciosViewModel);

                await _vitrineService.Create(anuncios);

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Anuncios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anunciosViewModel = await _vitrineService.GetId(id ?? 0);
            if (anunciosViewModel == null)
            {
                return NotFound();
            }

            return View(anunciosViewModel);
        }

        // POST: Anuncios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Make,Model,Version,Year,Mileage,Note")] AnunciosViewModel anunciosViewModel)
        {
            if (id != anunciosViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(anunciosViewModel);

            try
            {
                if (ModelState.IsValid)
                {
                    var anuncio = _mapper.Map<AnunciosDTO>(anunciosViewModel);

                    await _vitrineService.Edit(anuncio);

                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Anuncios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anunciosViewModel = await _vitrineService.GetId(id ?? 0);

            if (anunciosViewModel == null)
            {
                return NotFound();
            }

            return View(anunciosViewModel);
        }

        // POST: Anuncios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _vitrineService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetModels(int id)
        {
            return Json(await _vitrineService.GetModels(id));
        }

        public async Task<IActionResult> GetVehicles(int id)
        {
            return Json(await _vitrineService.GetVehicles(id));
        }

        public async Task<IActionResult> GetVersion(int id)
        {
            return Json(await _vitrineService.GetVersion(id));
        }
    }
}
