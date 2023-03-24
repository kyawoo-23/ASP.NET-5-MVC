using Microsoft.AspNetCore.Mvc;
using ModelBindingDemo.Models;
using ModelBindingDemo.Repository;
using ModelBindingDemo.ViewModel;
using System.Collections.Generic;

namespace ModelBindingDemo.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteRepository _noteRepository;
        private readonly IDeveloperRepository _developerRepository;

        public NoteController(INoteRepository noteRepository, IDeveloperRepository devRepository)
        {
            _noteRepository = noteRepository;
            _developerRepository = devRepository;
        }

        public IActionResult Index()
        {
            List<Note> Note = _noteRepository.GetAllNotes();
            //NoteViewModel model = new NoteViewModel() { Note = Note };
            //return View(model);
            return View(Note);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<Developer> developers = _developerRepository.GetAllDevelopers();
            DeveloperNoteViewModel model = new DeveloperNoteViewModel()
            {
                Developer = developers
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(DeveloperNoteViewModel model)
        {
            _noteRepository.Insert(model.Note);
            _noteRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
