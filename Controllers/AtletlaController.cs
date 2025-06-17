using ConexionDGII;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCAppCRUDRazorCodeFirst.Data;
using MVCAppCRUDRazorCodeFirst.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MVCAppCRUDRazorCodeFirst.Controllers
{
    public class AtletlaController : Controller
    {
        // private readonly AppDBContext _appDBContext = new AppDBContext();

        // USANDO INYECCION DE INDEPENDENCIAS EN VEZ DE HACER INSTANCIAS
        private readonly AppDBContext _appDBContext;

        public AtletlaController (AppDBContext appDBContext) 
        {
            _appDBContext = appDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> obtenerAtletlas()
        {
            List<Atletlas> obtenerAtletlas = await _appDBContext.Atletlas.ToListAsync();
            return View(obtenerAtletlas);
        }

        [HttpGet]
        public IActionResult nuevoAtletla()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> nuevoAtletla(Atletlas atletlas)
        {
            await _appDBContext.Atletlas.AddAsync(atletlas);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(obtenerAtletlas));
        }

        [HttpGet]
        public async Task<IActionResult> editarAtletla(int Id)
        {
            Atletlas editarAtletlas = await _appDBContext.Atletlas.FirstAsync(e => e.IdAtleta == Id);
            return View(editarAtletlas);
        }

        [HttpPost]
        public async Task<IActionResult> editarAtletla(Atletlas atletlas)
        {
            _appDBContext.Atletlas.Update(atletlas);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(obtenerAtletlas));
        }

        [HttpGet]
        public async Task<IActionResult> eliminarAtletla(int Id)
        {
            Atletlas eliminarAtletlas = await _appDBContext.Atletlas.FirstAsync(e => e.IdAtleta == Id);
            return View(eliminarAtletlas);
        }

        [HttpPost]
        public async Task<IActionResult> eliminarAtletla(Atletlas atletlas)
        {
            _appDBContext.Atletlas.Remove(atletlas);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(obtenerAtletlas));
        }

        [HttpGet]
        public async Task<IActionResult> eliminarAtletlaQuick(int Id)
        {
            Atletlas eliminarAtletlas = await _appDBContext.Atletlas.FirstAsync(e => e.IdAtleta == Id);

            _appDBContext.Atletlas.Remove(eliminarAtletlas);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(obtenerAtletlas));
        }

    }
}
