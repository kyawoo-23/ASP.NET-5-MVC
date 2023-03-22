using Microsoft.AspNetCore.Mvc;
using ModelBindingDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModelBindingDemo.Controllers
{
    public class DeveloperController : Controller
    {
        private readonly static List<Developer> _developers = new()
        {
            new Developer {
                Id = 1,
                Name = "John",
                Gender = "Male",
                Type = "Frontend developer"
            },
            new Developer {
                Id = 2,
                Name = "Eric",
                Gender = "Male",
                Type = "Backend developer"
            },
        };

        public IActionResult Index()
        {
            return View(_developers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Developer developer)
        {
            developer.Id = _developers.Count + 1;
            _developers.Add(developer);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Developer data = _developers.FirstOrDefault(x => x.Id == id);
            return data != null ? View(data) : RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Developer developer)
        {
            Developer data = _developers.FirstOrDefault(x => x.Id == developer.Id);
            data.Name = developer.Name;
            data.Gender = developer.Gender;
            data.Type = developer.Type;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Developer data = _developers.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                _developers.Remove(data);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
            
        }
    }
}
