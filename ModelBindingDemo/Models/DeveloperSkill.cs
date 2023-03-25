using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelBindingDemo.Models
{
    public class DeveloperSkill
    {
        public int DeveloperSkillId { get; set; }

        [ForeignKey("DeveloperId")]
        public int DeveloperId { get; set; }
        [ForeignKey("SkillId")]
        public int SkillId { get; set; }

        public Developer Developer { get; set; }
        public Skill Skill { get; set; }

        public int SkillLevel { get; set; }
    }
}
