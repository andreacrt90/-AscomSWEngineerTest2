using AscomSWEngineerTest2.Helpers;
using AscomSWEngineerTest2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace AscomSWEngineerTest2.Controllers
{
    public class PatientController : Controller
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IConfiguration _configuration;

        public PatientController(ILogger<PatientController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [Authorize]
        public ActionResult Patient(int id)
        {

            var context = new DataContext(_configuration);

            Patient patient = context.Patients.Where(x => x.Id == id).First();

            patient.LastSelectedDate = DateTime.Now;
            context.SaveChanges();

            return View(patient);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}