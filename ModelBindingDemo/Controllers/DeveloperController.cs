using Microsoft.AspNetCore.Mvc;
using ModelBindingDemo.Data;
using ModelBindingDemo.Models;
using ModelBindingDemo.Repository;
using ModelBindingDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace ModelBindingDemo.Controllers
{
    public class DeveloperController : Controller
    {
        private readonly IDeveloperRepository _devRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IDeveloperSkillRepository _devSkillRepository;

        public DeveloperController(IDeveloperRepository devRepository, ISkillRepository skillRepository, IDeveloperSkillRepository devSkillRepository)
        {
            _devRepository = devRepository;
            _skillRepository = skillRepository;
            _devSkillRepository = devSkillRepository;
        }

        public IActionResult Index()
        {
            List<Developer> res = _devRepository.GetAllDevelopers();
            return View(res);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Developer developer)
        {
            if (ModelState.IsValid)
            {
                _devRepository.Insert(developer);
                _devRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Developer data = _devRepository.GetDeveloperById(id);
            return data != null ? View(data) : RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Developer developer)
        {
            _devRepository.Update(developer);
            _devRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _devRepository.Delete(id);
            _devRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            Developer dev = _devRepository.GetDeveloperById(id);
            ConfirmDeleteModal model = new ConfirmDeleteModal()
            {
                Id = dev.DeveloperId,
                Name = dev.Name,
            };
            return PartialView("_ConfirmDeleteModalPartial", model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Developer developer = _devRepository.GetDeveloperById(id);
            List<DeveloperSkill> devSkills = _devSkillRepository.GetSkillLevelByDevId(id);
            DeveloperEditSkillsViewModel model = new DeveloperEditSkillsViewModel()
            {
                Developer = developer,
                DeveloperSkills = devSkills
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult EditSkills(int id)
        {
            Developer developer = _devRepository.GetDeveloperById(id);
            List<Skill> skills = _skillRepository.GetAllSkills();
            List<DeveloperSkill> devSkills = _devSkillRepository.GetSkillLevelByDevId(id);
            DeveloperEditSkillsViewModel model = new DeveloperEditSkillsViewModel()
            {
                Developer = developer,
                Skills = skills,
                DeveloperSkills = devSkills
            };
            return View(model);
        }

        //[HttpPost]
        //public IActionResult EditSkills(DeveloperSkill model, int devId)
        //{
        //    DeveloperSkill devSkill = new DeveloperSkill() {
        //        DeveloperId = devId,
        //        SkillId = model.SkillId,
        //        SkillLevel = model.SkillLevel,
        //    };
        //    _devSkillRepository.Insert(devSkill);
        //    _devSkillRepository.Save();
        //    return RedirectToAction("Details", new { id = model.DeveloperId });
        //}        

        [HttpPost]
        public IActionResult EditSkills(int devId, int[] devSkills, int[] devSkillsLevel)
        {
            try
            {
                for (int i = 0; i < devSkills.Length; i++)
                {
                    DeveloperSkill devSkill = new DeveloperSkill()
                    {
                        DeveloperId = devId,
                        SkillId = devSkills[i],
                        SkillLevel = devSkillsLevel[i],
                    };
                    _devSkillRepository.Insert(devSkill);
                }
                _devSkillRepository.Save();
                return Json(new
                {
                    success = true,
                    error = false,
                    redirectToUrl = Url.Action("Details", "Developer", new { id = devId })
                });
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult GetSkillSelectorPartialView()
        {
            List<Skill> skills = _skillRepository.GetAllSkills();
            SkillSelectorPartialViewModel model = new SkillSelectorPartialViewModel()
            {
                Skills = skills
            };
            return PartialView("_SkillSelectorPartialView", model);
        }
    }
}
