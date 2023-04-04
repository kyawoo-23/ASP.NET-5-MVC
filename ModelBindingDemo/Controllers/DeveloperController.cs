using Dev.Business.Services;
using Microsoft.AspNetCore.Mvc;
using ModelBindingDemo.Data;
using Dev.Entities.Models;
using ModelBindingDemo.Repository;
using ModelBindingDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using ModelBindingDemo.Models;
using AutoMapper;

namespace ModelBindingDemo.Controllers
{
    public class DeveloperController : Controller
    {
        private readonly IDeveloperService _devService;
        private readonly ISkillService _skillService;
        private readonly IDeveloperSkillService _devSkillService;
        private readonly IMapper _mapper;
        //private readonly IDeveloperRepository _devRepository;
        //private readonly ISkillRepository _skillRepository;
        //private readonly IDeveloperSkillRepository _devSkillRepository;

        //public DeveloperController(IDeveloperRepository devRepository, ISkillRepository skillRepository, IDeveloperSkillRepository devSkillRepository)
        //{
        //    _devRepository = devRepository;
        //    _skillRepository = skillRepository;
        //    _devSkillRepository = devSkillRepository;
        //}

        public DeveloperController(IDeveloperService devService, ISkillService skillService, IDeveloperSkillService devSkillService, IMapper mapper)
        {
            _devService = devService;
            _skillService = skillService;
            _devSkillService = devSkillService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<Developer> res = _devService.GetAllDevelopers();
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
                _devService.Insert(developer);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Developer data = _devService.GetDeveloperById(id);
            return data != null ? View(data) : RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Developer developer)
        {
            _devService.Update(developer);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _devService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            Developer dev = _devService.GetDeveloperById(id);
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
            Developer developer = _devService.GetDeveloperById(id);
            List<DeveloperSkill> devSkills = _devSkillService.GetSkillLevelByDevId(id);
            DeveloperEditSkillsViewModel model = _mapper.Map<DeveloperEditSkillsViewModel>((developer, new List<Skill>() , devSkills));
            //DeveloperEditSkillsViewModel model = new DeveloperEditSkillsViewModel()
            //{
            //    Developer = developer,
            //    DeveloperSkills = devSkills
            //};
            return View(model);
        }

        [HttpGet]
        public IActionResult EditSkills(int id)
        {
            Developer developer = _devService.GetDeveloperById(id);
            List<Skill> skills = _skillService.GetAllSkills();
            List<DeveloperSkill> devSkills = _devSkillService.GetSkillLevelByDevId(id);
            DeveloperEditSkillsViewModel model = _mapper.Map<DeveloperEditSkillsViewModel>((developer, skills, devSkills));
            //DeveloperEditSkillsViewModel model = new DeveloperEditSkillsViewModel()
            //{
            //    Developer = developer,
            //    Skills = skills,
            //    DeveloperSkills = devSkills
            //};
            return View(model);
        }

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
                    _devSkillService.Insert(devSkill);
                }
                //_devSkillRepository.Save();
                return Json(new
                {
                    success = true,
                    error = false,
                    redirectToUrl = Url.Action("Details", "Developer", new { id = devId })
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult GetSkillSelectorPartialView()
        {
            List<Skill> skills = _skillService.GetAllSkills();
            SkillSelectorPartialViewModel model = new SkillSelectorPartialViewModel()
            {
                Skills = skills
            };
            return PartialView("_SkillSelectorPartialView", model);
        }
    }
}
