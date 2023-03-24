using Microsoft.AspNetCore.Mvc;
using ModelBindingDemo.Data;
using ModelBindingDemo.Models;
using ModelBindingDemo.Repository;
using ModelBindingDemo.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace ModelBindingDemo.Controllers
{
    public class DeveloperController : Controller
    {
        private readonly IDeveloperRepository _devRepository;

        public DeveloperController(IDeveloperRepository devRepository)
        {
            _devRepository = devRepository;
        }

        public IActionResult Index()
        {
            List<Developer> res = _devRepository.GetAllDevelopers();
            return View(res);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Developer developer = new Developer();
            return View("Create", developer);
        }

        [HttpPost]
        public IActionResult Create(Developer developer)
        {
            if (ModelState.IsValid)
            {
                _devRepository.Insert(developer);
                _devRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Developer data = _devRepository.GetDeveloperById(id);
            return data != null ? View(data) : RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Developer developer)
        {
            //Developer data = _appContext.Developers.FirstOrDefault(x => x.Id == developer.Id);
            //data.Name = developer.Name;
            //data.Gender = developer.Gender;
            //data.Type = developer.Type;
            //_appContext.SaveChanges();
            _devRepository.Update(developer);
            _devRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _devRepository.Delete(id);
            _devRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            Developer dev = _devRepository.GetDeveloperById(id);
            ConfirmDeleteModal model = new ConfirmDeleteModal()
            {
                Id = dev.Id,
                Name = dev.Name
            };
            return PartialView("_ConfirmDeleteModalPartial", model);
        }

        [HttpGet]
        public IActionResult Details(int id) {
            Developer res = _devRepository.GetDeveloperById(id);
            //List<Note> notes = _noteRepository.GetNotesByDevId(res.Id);
            //DeveloperDetailsViewModel model = new DeveloperDetailsViewModel()
            //{
            //    Developer = res,
            //    Note = notes
            //};
            return View(res);
        }
    }
}
