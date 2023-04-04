using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dev.Entities.Models
{
    [Index(nameof(SkillName), IsUnique = true)]
    public class Skill
    {
        public int SkillId { get; set; }

        [Required]
        public string SkillName { get; set; }
        public List<Developer> Developers { get; set; }
    }
}
