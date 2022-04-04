using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WM.Vitrine.API.Data.Repository;
using WM.Vitrine.API.Models;
using WM.Vitrine.API.Models.Models.Exceptions;
using WM.WebAPI.Core.Controllers;

namespace WM.Vitrine.API.Controllers
{
    [Route("api/anuncio")]
    [ApiController]
    public class AnuncioController : MainController
    {
        private readonly IAnuncioRepository _anuncioRepository;

        public AnuncioController(IAnuncioRepository anuncioRepository)
        {
            _anuncioRepository = anuncioRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Anuncio anuncio)
        {
            try
            {
                _anuncioRepository.AddAsync(anuncio);

                await _anuncioRepository.UnitOfWork.Commit();
                
                return CustomResponse();
            }
            catch (CarException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var cars = await _anuncioRepository.GetAsync();

                return CustomResponse(cars);
            }
            catch (CarException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var anuncio = await _anuncioRepository.GetByIdAsync(id);

                return CustomResponse(anuncio);
            }
            catch (CarException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Anuncio anuncio)
        {
            var retorno = await _anuncioRepository.GetByIdAsync(anuncio.Id);

            if (retorno == null)
            {
                AdicionarErroProcessamento("Anúncio não encontrado");
                return CustomResponse();
            }

            _anuncioRepository.UpdateAsync(anuncio);

            await _anuncioRepository.UnitOfWork.Commit();

            return CustomResponse();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var anuncio = await _anuncioRepository.GetByIdAsync(id);

            if (anuncio == null)
            {
                AdicionarErroProcessamento("Anúncio não encontrado");
                return CustomResponse();
            }

            _anuncioRepository.DeleteAsync(anuncio);

            await _anuncioRepository.UnitOfWork.Commit();

            return CustomResponse();
        }
    }
}
