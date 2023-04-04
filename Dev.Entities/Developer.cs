using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dev.Entities.Models
{
    public class Developer
    {
        public int DeveloperId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Type { get; set; }
        public List<Note> Notes { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
