using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RaktaSewa.Models;
using RaktaSewa.Data;
using RaktaSewa.Services;
using RaktaSewa.Models.ViewModels;
using System.Diagnostics;


namespace RaktaSewa.Controllers
{
    public class BloodController : Controller
    {
        private readonly IBloodService bloodService;
        private readonly ILogger<BloodController> _logger;
        public BloodController(
        ILogger<BloodController> logger,
        IBloodService bloodService
        )
        {
            _logger = logger;
            this.bloodService = bloodService;
        }

        // GET: BloodController
        public IActionResult Index()
        {
            return View(new List<Blood>());
           
        }

        // GET: BloodController/Details/5
        public IActionResult Details(int Id)
        {
            return View();
        }

        // GET: BloodController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BloodController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateBlood(BloodCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var res = bloodService.Create(model);
                if (res.Item1)
                    return RedirectToAction("Index");
            }
            return View();
        }

        // GET: BloodController/Edit/5
        public IActionResult Edit(int Id)
        {
            return View();
        }

        // POST: BloodController/Edit/5
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

        // GET: BloodController/Delete/5
        //public IActionResult Delete(int Id)
        //{
        //    return View();
        //}

        // POST: BloodController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            var res = bloodService.Delete(Id);
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
