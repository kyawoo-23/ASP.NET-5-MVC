using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelBindingDemo.Models
{
    public class Developer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Type { get; set; }
        public List<Note> Notes { get; set; }
    }
}
