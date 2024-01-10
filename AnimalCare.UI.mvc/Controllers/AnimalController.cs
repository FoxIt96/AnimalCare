using Microsoft.AspNetCore.Mvc;
using System;
using Model;
using Services;

namespace AnimalCare.UI.mvc.Controllers
{
    public class AnimalController(AnimalService animalService, CaregiverService caregiverService) : Controller
    {
        public IActionResult Index()
        {
            var people = animalService.Find();
            return View(people);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Signalmen = caregiverService.Find();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Animal person)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Signalmen = caregiverService.Find();
                return View(person);
            }

            animalService.Create(person);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            ViewBag.Signalmen = caregiverService.Find();
            var person = animalService.Get(id);
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Animal person)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Signalmen = caregiverService.Find();
                return View(person);
            }

            animalService.Update(id, person);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            var person = animalService.Get(id);
            return View(person);
        }

        [HttpPost("/animal/delete/{id:int?}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            animalService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}

