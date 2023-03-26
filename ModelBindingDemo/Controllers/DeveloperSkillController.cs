using Microsoft.AspNetCore.Mvc;
using ModelBindingDemo.Models;
using ModelBindingDemo.Repository;

namespace ModelBindingDemo.Controllers
{
    public class DeveloperSkillController : Controller
    {
        private readonly IDeveloperSkillRepository _devSkillRepository;
        public DeveloperSkillController(IDeveloperSkillRepository devSkillRepository)
        {
            _devSkillRepository = devSkillRepository;
        }

        public IActionResult Delete(int id, int refDevId)
        {
            _devSkillRepository.Delete(id);
            _devSkillRepository.Save();
            return RedirectToAction("EditSkills", "Developer", new { id = refDevId });
        }


        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            DeveloperSkill devSkill = _devSkillRepository.GetDeveloperSkillById(id);
            ConfirmDeleteModal model = new ConfirmDeleteModal()
            {
                Id = devSkill.DeveloperSkillId,
                Name = devSkill.Skill.SkillName + " from " + devSkill.Developer.Name,
                refDevId = devSkill.DeveloperId
            };
            return PartialView("_ConfirmDeleteModalPartial", model);
        }
    }
}
