using Microsoft.AspNetCore.Mvc;
using Dev.Entities.Models;
using ModelBindingDemo.Repository;
using Dev.Business.Services;
using ModelBindingDemo.Models;
using AutoMapper;

namespace ModelBindingDemo.Controllers
{
    public class DeveloperSkillController : Controller
    {
        private readonly IDeveloperSkillService _devSkillService;
        private readonly IMapper _mapper;
        public DeveloperSkillController(IDeveloperSkillService devSkillService, IMapper mapper)
        {
            _devSkillService = devSkillService;
            _mapper = mapper;
        }
        //private readonly IDeveloperSkillRepository _devSkillRepository;
        //public DeveloperSkillController(IDeveloperSkillRepository devSkillRepository)
        //{
        //    _devSkillRepository = devSkillRepository;
        //}

        public IActionResult Delete(int id, int refDevId)
        {
            _devSkillService.Delete(id);
            //_devSkillRepository.Save();
            return RedirectToAction("EditSkills", "Developer", new { id = refDevId });
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            DeveloperSkill devSkill = _devSkillService.GetDeveloperSkillById(id);
            ConfirmDeleteModal model = _mapper.Map<DeveloperSkill, ConfirmDeleteModal>(devSkill);
            //ConfirmDeleteModal model = new ConfirmDeleteModal()
            //{
            //    Id = devSkill.DeveloperSkillId,
            //    Name = devSkill.Skill.SkillName + " from " + devSkill.Developer.Name,
            //    refDevId = devSkill.DeveloperId
            //};
            return PartialView("_ConfirmDeleteModalPartial", model);
        }
    }
}
