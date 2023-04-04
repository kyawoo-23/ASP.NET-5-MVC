using Dev.Entities.Models;
using System.Collections.Generic;

namespace ModelBindingDemo.ViewModel
{
    public class DeveloperNoteViewModel
    {
        public List<Developer> Developer { get; set; }
        public Note Note { get; set; }
    }
}
