using Microsoft.AspNetCore.Mvc;
using Dev.Business.Services;
using Dev.Entities.Models;
using ModelBindingDemo.Repository;
using ModelBindingDemo.ViewModel;
using System.Collections.Generic;
using ModelBindingDemo.Models;
using AutoMapper;

namespace ModelBindingDemo.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;
        private readonly IDeveloperService _devService;
        private readonly IMapper _mapper;

        public NoteController(INoteService noteService, IDeveloperService devService, IMapper mapper)
        {
            _noteService = noteService;
            _devService = devService;
            _mapper = mapper;
        }
        //private readonly INoteRepository _noteRepository;
        //private readonly IDeveloperRepository _developerRepository;

        //public NoteController(INoteRepository noteRepository, IDeveloperRepository devRepository)
        //{
        //    _noteRepository = noteRepository;
        //    _developerRepository = devRepository;
        //}

        public IActionResult Index()
        {
            List<Note> Note = _noteService.GetAllNotes();
            return View(Note);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<Developer> developers = _devService.GetAllDevelopers();
            DeveloperNoteViewModel model = _mapper.Map<List<Developer>, DeveloperNoteViewModel>(developers);
            //DeveloperNoteViewModel model = new DeveloperNoteViewModel()
            //{
            //    Developer = developers
            //};
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(DeveloperNoteViewModel model)
        {
            _noteService.Insert(model.Note);
            //_noteRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id, int refDevId)
        {
            _noteService.Delete(id);
            //_noteRepository.Save();
            return RedirectToAction("Details", "Developer", new { id = refDevId });
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id, int devId)
        {
            Note note = _noteService.GetNoteById(id);
            ConfirmDeleteModal model = _mapper.Map<Note, ConfirmDeleteModal>(note);
            //ConfirmDeleteModal model = new ConfirmDeleteModal()
            //{
            //    Id = note.Id,
            //    Name = note.Title,
            //    refDevId = devId
            //};
            return PartialView("_ConfirmDeleteModalPartial", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Note note = _noteService.GetNoteById(id);
            return View(note);
        }

        [HttpPost]
        public IActionResult Edit(Note note)
        {
            _noteService.Update(note);
            //_noteRepository.Save();
            return RedirectToAction("Details", "Developer", new { id = note.DeveloperId });
        }
    }
}
