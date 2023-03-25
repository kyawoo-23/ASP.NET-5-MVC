using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelBindingDemo.Models
{
    public class SkillSelectorPartialViewModel
    {
        public Developer Developer { get; set; }
        public List<Skill> Skills { get; set; }
        public int SkillId { get; set; }

        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int SkillLevel { get; set; }
    }
}
