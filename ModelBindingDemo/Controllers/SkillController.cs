using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dev.Entities.Models;
using ModelBindingDemo.Repository;
using ModelBindingDemo.ViewModel;
using System.Collections.Generic;
using Dev.Business.Services;
using ModelBindingDemo.Models;

namespace ModelBindingDemo.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;
        private readonly IDeveloperSkillService _devSkillService;

        public SkillController(ISkillService skillService, IDeveloperSkillService devSkillService)
        {
            _skillService = skillService;
            _devSkillService = devSkillService;
        }

        //private readonly ISkillRepository _skillRepository;
        //private readonly IDeveloperSkillRepository _devSkillRepository;

        //public SkillController(ISkillRepository skillRepository, IDeveloperSkillRepository devSkillRepository)
        //{
        //    _skillRepository = skillRepository;
        //    _devSkillRepository = devSkillRepository;
        //}

        public IActionResult Index()
        {
            List<Skill> skills = _skillService.GetAllSkills();
            return View(skills);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            List<DeveloperSkill> devSkill = _devSkillService.GetSkillLevelBySkillId(id);
            return View(devSkill);
        }

        [HttpPost]
        public IActionResult Create(Skill skill)
        {
            if (_skillService.IsSkillNameDuplicate(skill.SkillName))
            {
                ModelState.AddModelError(nameof(skill.SkillName), "The skill name already exists!");
            }
            if (ModelState.IsValid)
            {
                _skillService.Insert(skill);
                //_skillRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            List<Skill> allSkills = _skillService.GetAllSkills();
            return View("Index", allSkills);
        }

        public IActionResult Delete(int id)
        {
            _skillService.Delete(id);
            //_skillRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            Skill skill = _skillService.GetSkillById(id);
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
            if (_skillService.IsSkillNameDuplicate(skill.SkillName))
            {
                ModelState.AddModelError(nameof(skill.SkillName), "The skill name already exists!");
            }
            if (ModelState.IsValid)
            {
                _skillService.Update(skill);
                //_skillRepository.Save();

                TempData["SuccessMessage"] = "Skill name updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            List<Skill> allSkills = _skillService.GetAllSkills();
            //ModelState.Clear();
            return View("Index", allSkills);
            //return RedirectToAction("Index");
        }
    }
}
