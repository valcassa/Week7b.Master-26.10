using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7b.Master.Core.BusinessLayer;
using Week7b.Master.MVC.Helper;
using Week7b.Master.MVC.Models;

namespace Week7b.Master.MVC.Controllers
{
    public class DocenteController : Controller
    {
        private readonly IBusinessLayer BL;

        public DocenteController(IBusinessLayer bl)
        {
            BL = bl;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var docenti = BL.GetAllDocenti();

            List<DocenteViewModel> docenteViewModels = new List<DocenteViewModel>();

            foreach (var item in docenti)
            {
                StudenteViewModel.Add(item.toDocenteViewModel());
            }

            return View(docenteViewModels);
        }

        [HttpPost]
        public IActionResult Create(DocenteViewModel docenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var docente = docenteViewModel.ToDocente();
                BL.InserisciNuovoDocente(docente);
                return RedirectToAction(nameof(Index));
            }
            return View(docenteViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var docente = BL.GetAllDocenti().FirstOrDefault(d => d.ID == id);
            var docenteViewModel = docente.toDocenteViewModel();
            return View(docenteViewModel);
        }

        [HttpPost]
        public IActionResult Edit(DocenteViewModel docenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var docente = docenteViewModel.ToDocente();
                BL.ModificaDocente(docente.ID, docente.Nome, docente.Cognome, docente.Email, docente.Telefono);
                return RedirectToAction(nameof(Index));
            }
            return View(docenteViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var docente = BL.GetAllDocenti().FirstOrDefault(d => d.ID == id);
            var docenteViewModel = docente.toDocenteViewModel();
            return View(docenteViewModel);
        }

        [HttpPost]
        public IActionResult Delete(DocenteViewModel docenteViewModel)
        {
            if (ModelState.IsValid)
            {

                var docente = docenteViewModel.ToDocente();
                BL.EliminaDocente(docente.ID);
                return RedirectToAction(nameof(Index));

            }
            return View(docenteViewModel);
        }

    }
}
