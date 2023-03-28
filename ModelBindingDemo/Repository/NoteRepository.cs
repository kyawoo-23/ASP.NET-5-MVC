using Microsoft.EntityFrameworkCore;
using ModelBindingDemo.Data;
using ModelBindingDemo.Models;
using ModelBindingDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelBindingDemo.Repository
{
    public class NoteRepository : INoteRepository
    {
        public readonly AppDbContext _appContext;
        public NoteRepository(AppDbContext appContext)
        {
            _appContext = appContext;   
        }

        public void Delete(int id)
        {
            Note data = _appContext.Notes.FirstOrDefault(x => x.Id == id);
            _appContext.Notes.Remove(data);
        }

        public List<Note> GetAllNotes()
        {
            return _appContext.Notes.Include(n => n.Developer).ToList();
        }

        public Note GetNoteById(int id)
        {
            return _appContext.Notes.Include(d => d.Developer).FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Note model)
        {
            _appContext.Notes.Add(model);
        }

        public void Save()
        {
            _appContext.SaveChanges();
        }

        public void Update(Note note)
        {
            _appContext.Entry(note).State = EntityState.Modified;
        }
    }
}
