using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SuperMed.Auth;
using SuperMed.DAL.Repositories;
using SuperMed.Models.ViewModels;

namespace SuperMed.Controllers
{
    [Authorize(Roles = "Patient")]
    public class PatientsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPatientsRepository _patientsRepository;
        private readonly IDoctorsRepository _doctorsRepository;
        private readonly ISpecializationsRepository _specializationsRepository;

        public PatientsController(
            UserManager<ApplicationUser> userManager, 
            IPatientsRepository patientsRepository,
            IDoctorsRepository doctorsRepository,
            ISpecializationsRepository specializationsRepository)
        {
            _userManager = userManager;
            _patientsRepository = patientsRepository;
            _doctorsRepository = doctorsRepository;
            _specializationsRepository = specializationsRepository;
        }

        public async Task<IActionResult> Index()
        {
            var user = _userManager.GetUserName(User);

            var getUserInfo = await _patientsRepository.GetByName(user);

            return View(getUserInfo);
        }

        public async Task<IActionResult> CreateVisit()
        {
            var allDoctors = await _doctorsRepository.GetAll();

            var selectList = new List<SelectListItem>();

            foreach (var doctor in allDoctors)
            {
                var specname = await _specializationsRepository.Get(doctor.SpecializationId);
                selectList.Add(new SelectListItem
                {
                    Value = doctor.Name,
                    Text = $"{specname.Name} - {doctor.FirstName} {doctor.LastName}"
                });
            }

            var visitModel = new CreateVisitViewModel
            {
                Doctors = selectList.OrderBy(p => p.Text)
            };

            return View(visitModel);
        }
    }
}