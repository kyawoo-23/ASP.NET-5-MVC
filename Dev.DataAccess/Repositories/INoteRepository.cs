using Dev.DataAccess.Repositories;
using Dev.Entities.Models;
using System.Collections.Generic;

namespace ModelBindingDemo.Repository
{
    public interface INoteRepository : IBaseRepository<Note>
    {
        List<Note> GetAllNotes();
        Note GetNoteById(int id);
        void Update(Note note);
    }
}
