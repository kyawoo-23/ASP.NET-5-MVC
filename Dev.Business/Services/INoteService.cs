using Dev.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Business.Services
{
    public interface INoteService : IBaseService<Note>
    {
        List<Note> GetAllNotes();
        Note GetNoteById(int id);
        void Update(Note note);
    }
}
