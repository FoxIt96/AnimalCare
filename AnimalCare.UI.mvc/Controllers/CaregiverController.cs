using Microsoft.AspNetCore.Mvc;
using System;
using Model;
using Services;

namespace AnimalCare.UI.mvc.Controllers
{
    public class CaregiverController(CaregiverService caregiverService, AnimalService animalService) : Controller
    {
        public IActionResult Index()
        {
            var people = caregiverService.Find();
            return View(people);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Animals = animalService.Find();
            return AssignmentView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Caregiver person)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Animals = animalService.Find();
                return AssignmentView(person);
            }

            caregiverService.Create(person);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            ViewBag.Animals = animalService.Find();
            var person = caregiverService.Get(id);
            return AssignmentView(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Caregiver person)
        {
            if (!ModelState.IsValid)
            {
                return AssignmentView(person);
            }

            caregiverService.Update(id, person);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            var person = caregiverService.Get(id);
            return View(person);
        }

        [HttpPost("/caregiver/delete/{id:int?}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            caregiverService.Delete(id);

            return RedirectToAction("Index");
        }

        private IActionResult AssignmentView(Caregiver? assignment = null)
        {
            var people = animalService.Find();
            //ViewData["People"] = people;
            ViewBag.People = people;

            if (assignment is null)
            {
                return View();
            }

            return View(assignment);
        }
    }
}