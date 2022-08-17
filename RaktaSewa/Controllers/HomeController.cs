using Microsoft.AspNetCore.Mvc;
using RaktaSewa.Models.ViewModels;
using System.Diagnostics;
using RaktaSewa.Services;

namespace RaktaSewa.Controllers
{
    public class HomeController : Controller
    {
       // private readonly ILogger<HomeController> _logger;
        //private readonly ICitizenService citizenService;


        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       // [HttpPost]
        //public IActionResult CreateCitizen( CitizenCreateViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var res = citizenService.Create(model);
        //        if (res.Item1)
        //            return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        //public IActionResult Delete(int id)
        //{
        //    var res = citizenService.Delete(id);
        //    if (res.Item1) return RedirectToAction("Index");

        //    return View("Error");
        //}
    }

}