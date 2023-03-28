﻿using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Delete(int id, int refDevId)
        {
            _noteRepository.Delete(id);
            _noteRepository.Save();
            return RedirectToAction("Details", "Developer", new { id= refDevId });
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id, int devId)
        {
            Note note = _noteRepository.GetNoteById(id);
            ConfirmDeleteModal model = new ConfirmDeleteModal()
            {
                Id = note.Id,
                Name = note.Title,
                refDevId = devId
            };
            return PartialView("_ConfirmDeleteModalPartial", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Note note = _noteRepository.GetNoteById(id);
            return View(note);
        }

        [HttpPost]
        public IActionResult Edit(Note note)
        {
            _noteRepository.Update(note);
            _noteRepository.Save();
            return RedirectToAction("Details", "Developer", new { id = note.DeveloperId });
        }
    }
}
