using AnimalCare.UI.mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Services;

namespace AnimalCare.UI.mvc.Controllers
{
    public class HomeController(CaregiverService caregiverService, AnimalService animalService) : Controller
    {
        
        public IActionResult Index()
        {
            ViewBag.Caregivers = caregiverService.Find();
            ViewBag.Animals = animalService.Find();
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
    }
}
