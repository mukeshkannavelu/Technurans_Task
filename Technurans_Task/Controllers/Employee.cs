using Microsoft.AspNetCore.Mvc;
using Technurans_Task.Models.Domain;
using System;

namespace Technurans_Task.Controllers
{
    public class Employee : Controller
    {
        private readonly DatabaseContext _ctx;
        public Employee(DatabaseContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            ViewBag.say = "\'This is Mukesh\'";
            ViewData["hi"] = "TechNurans ASP.Net Core Application Task";
            TempData["a"] = "I hope you  taht is good. ";
            return View();
        }
        public IActionResult AddPerson()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPerson(Models.Domain.Task person)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.Employee_Details.Add(person);
                _ctx.SaveChanges();
                TempData["msg"] = "Added successfully";
                return RedirectToAction("AddPerson");

            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not added!!!" + ex.Message;
                return View();
            }

        }
        public IActionResult DisplayPersons()
        {
            var persons = _ctx.Employee_Details.ToList();
            return View(persons);
        }
        public IActionResult DeletePerson(int id)
        {
            try
            {
                var person = _ctx.Employee_Details.Find(id);
                if (person != null)
                {
                    _ctx.Employee_Details.Remove(person);
                    _ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
            return RedirectToAction("DisplayPersons");
        }
        public IActionResult EditPerson(int id)
        {
            var person = _ctx.Employee_Details.Find(id);

            return View(person);
        }
        [HttpPost]
        public IActionResult EditPerson(Models.Domain.Task person)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.Employee_Details.Update(person);
                _ctx.SaveChanges();
                return RedirectToAction("DisplayPersons");

            }
            catch (Exception e)
            {
                TempData["msg"] = "Could not added !!" + e.Message;
                return View();
            }

        }
    }
}
