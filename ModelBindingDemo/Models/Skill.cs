using System.Collections.Generic;

namespace ModelBindingDemo.Models
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public List<Developer> Developers { get; set; }
    }
}
