using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBindingDemo.Models;
using ModelBindingDemo.Repository;
using ModelBindingDemo.ViewModel;
using System.Collections.Generic;

namespace ModelBindingDemo.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IDeveloperSkillRepository _devSkillRepository;

        public SkillController(ISkillRepository skillRepository, IDeveloperSkillRepository devSkillRepository)
        {
            _skillRepository = skillRepository;
            _devSkillRepository = devSkillRepository;
        }

        public IActionResult Index()
        {
            List<Skill> skills = _skillRepository.GetAllSkills();
            return View(skills);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            List<DeveloperSkill> devSkill = _devSkillRepository.GetSkillLevelBySkillId(id);
            return View(devSkill);
        }

        [HttpPost]
        public IActionResult Create(Skill skill)
        {
            if (_skillRepository.IsSkillNameDuplicate(skill.SkillName))
            {
                ModelState.AddModelError(nameof(skill.SkillName), "The skill name already exists!");
            }
            if (ModelState.IsValid)
            {
                _skillRepository.Insert(skill);
                _skillRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            List<Skill> allSkills = _skillRepository.GetAllSkills();
            return View("Index", allSkills);
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

        [HttpPost]
        public IActionResult Update(Skill skill)
        {
            if (_skillRepository.IsSkillNameDuplicate(skill.SkillName))
            {
                ModelState.AddModelError(nameof(skill.SkillName), "The skill name already exists!");
            }
            if (ModelState.IsValid)
            {
                _skillRepository.Update(skill);
                _skillRepository.Save();

                TempData["SuccessMessage"] = "Skill name updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            List<Skill> allSkills = _skillRepository.GetAllSkills();
            //ModelState.Clear();
            return View("Index", allSkills);
            //return RedirectToAction("Index");
        }
    }
}
