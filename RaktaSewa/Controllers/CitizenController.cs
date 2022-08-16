using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RaktaSewa.Models;
using RaktaSewa.Data;
using RaktaSewa.Services;
using RaktaSewa.Models.ViewModels;
using System.Diagnostics;

namespace RaktaSewa.Controllers
{
    public class CitizenController : Controller
    {
        private readonly ICitizenService citizenService;
        private readonly ILogger<CitizenController> _logger;
        public CitizenController(
        ILogger<CitizenController> logger,
        ICitizenService citizenService
        )
        {
            _logger = logger;
            this.citizenService = citizenService;
        }

        // GET: CitizenController
        public IActionResult Index()
        {
            return View();
        }

        // GET: CitizenController/Details/5
        public IActionResult Details(int citizen_id)
        {
            return View();
        }

        // GET: CitizenController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CitizenController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCitizen(CitizenCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var res = citizenService.Create(model);
                if (res.Item1)
                    return RedirectToAction("Index");
            }
            return View();
        }

        // GET: CitizenController/Edit/5
        public IActionResult Edit(int citizen_id)
        {
            return View();
        }

        // POST: CitizenController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: CitizenController/Delete/5
        //public IActionResult Delete(int citizen_id)
        //{
        //    return View();
        //}

        // POST: CitizenController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int citizen_id)
        {
            var res = citizenService.Delete(citizen_id);
            if (res.Item1) return RedirectToAction("Index");

            return View("Error");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
