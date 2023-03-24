using ModelBindingDemo.Models;
using ModelBindingDemo.ViewModel;
using System.Collections.Generic;

namespace ModelBindingDemo.Repository
{
    public interface INoteRepository
    {
        List<Note> GetAllNotes();
        Note GetNoteById(int id);
        void Insert(Note model);
        void Update(Note note);
        void Delete(int id);
        void Save();
    }
}
