using ModelBindingDemo.Models;
using System.Collections.Generic;

namespace ModelBindingDemo.ViewModel
{
    public class DeveloperEditSkillsViewModel
    {
        public Developer Developer { get; set; }
        public List<Skill> Skills { get; set; }
        public List<DeveloperSkill> DeveloperSkills { get; set; }
    }
}
