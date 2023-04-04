using Dev.Business.Services;
using Microsoft.EntityFrameworkCore;
using ModelBindingDemo.Data;
using Dev.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelBindingDemo.Repository
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteContext;
        public NoteService(INoteRepository appContext)
        {
            _noteContext = appContext;
        }
        public void Delete(int id)
        {
            _noteContext.Delete(id);
        }

        public List<Note> GetAllNotes()
        {
            return _noteContext.GetAllNotes();
        }

        public Note GetNoteById(int id)
        {
            return _noteContext.GetNoteById(id);
        }

        public void Insert(Note entity)
        {
            _noteContext.Insert(entity);
        }

        public void Update(Note note)
        {
            _noteContext.Update(note);
        }
    }
}
