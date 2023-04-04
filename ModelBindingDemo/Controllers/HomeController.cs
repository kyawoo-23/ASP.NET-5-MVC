﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dev.Entities.Models;
using ModelBindingDemo.Repository;
using ModelBindingDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dev.Business.Services;
using ModelBindingDemo.Models;

namespace ModelBindingDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly INoteService _noteService;

        public HomeController(INoteService noteService)
        {
            _noteService = noteService;
        }

        //private readonly INoteRepository _noteRepository;

        //public HomeController(INoteRepository noteRepository)
        //{
        //    _noteRepository = noteRepository;
        //}

        [HttpGet]
        public IActionResult Index([FromQuery] string filterDate)
        {
            List<Note> notes = _noteService.GetAllNotes().OrderByDescending(n => n.CreatedAt).ToList();
            if (string.IsNullOrEmpty(filterDate))
            {
                return View("Index", notes);
            }
            else
            {
                List<Note> res = notes.Where(n => n.CreatedAt.ToString("yyyy-MM-dd") == filterDate).ToList();
                return View("Index", res);
            }
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
