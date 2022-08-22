using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RaktaSewa.Models;
using RaktaSewa.Data;
using RaktaSewa.Services;
using RaktaSewa.Models.ViewModels;
using System.Diagnostics;


namespace RaktaSewa.Controllers
{
    public class HospitalController : Controller
    {
        private readonly IHospitalService hospitalService;
        private readonly ILogger<HospitalController> _logger;
        public HospitalController(
        ILogger<HospitalController> logger,
        IHospitalService HospitalService
        )
        {
            _logger = logger;
            this.hospitalService = HospitalService;
        }

        // GET: HospitalController
        public IActionResult Index()
        {
            return View(new List<Hospital>());
           
        }

        // GET: HospitalController/Details/5
        public IActionResult Details(int Hospital_id)
        {
            return View();
        }

        // GET: HospitalController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HospitalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HospitalCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var res = hospitalService.Create(model);
                if (res.Item1)
                    return RedirectToAction("Index");
            }
            return View();
        }

        // GET: HospitalController/Edit/5
        public IActionResult Edit(int Id)
        {
            return View();
        }

        // POST: HospitalController/Edit/5
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

        // GET: HospitalController/Delete/5
        //public IActionResult Delete(int Hospital_id)
        //{
        //    return View();
        //}

        // POST: HospitalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            var res = hospitalService.Delete(Id);
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
