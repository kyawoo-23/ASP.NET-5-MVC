using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBindingDemo.Models;
using ModelBindingDemo.Repository;
using System.Collections.Generic;

namespace ModelBindingDemo.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillRepository _skillRepository;

        public SkillController(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public ActionResult Index()
        {
            List<Skill> skills = _skillRepository.GetAllSkills();
            return View(skills);
        }

        [HttpPost]
        public IActionResult Create(Skill skill)
        {
            _skillRepository.Insert(skill);
            _skillRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _skillRepository.Delete(id);
            _skillRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            Skill skill = _skillRepository.GetSkillById(id);
            ConfirmDeleteModal model = new ConfirmDeleteModal()
            {
                Id = skill.SkillId,
                Name = skill.SkillName
            };
            return PartialView("_ConfirmDeleteModalPartial", model);
        }
    }
}
