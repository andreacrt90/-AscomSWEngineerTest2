using AscomSWEngineerTest2.Helpers;
using AscomSWEngineerTest2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Hangfire;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AscomSWEngineerTest2.Controllers
{
    public class PatientsAreaController : Controller
    {
        private readonly ILogger<PatientsAreaController> _logger;
        private readonly IConfiguration _configuration;
        private DataContext context;

        public PatientsAreaController(ILogger<PatientsAreaController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            context = new DataContext(_configuration);
        }

        [Authorize]
        public ActionResult PatientsArea()
        {
            IQueryable<Patient> patientsList = context.Patients;

            RecurringJob.AddOrUpdate("addpatient", () => AddPatient(), "*/30 * * * * *");
            var jobId = BackgroundJob.Schedule(() => RemoveCron(), TimeSpan.FromSeconds(30));

            return View(patientsList);
        }

        [Authorize]
        public PartialViewResult RefreshGrid()
        {
            IQueryable<Patient> patientsList = context.Patients;
            return PartialView("PatientsList", patientsList);
        }

        [Authorize]
        public void AddPatient()
        {
            List<Patient> patientRandomList = new List<Patient>();
            patientRandomList.Add(new Patient("Rossi", "Marco"));
            patientRandomList.Add(new Patient("Verdi", "Paolo"));
            patientRandomList.Add(new Patient("Neri", "Lorenzo"));
            patientRandomList.Add(new Patient("Bianchi", "Mauro"));
            patientRandomList.Add(new Patient("Lunghi", "Antonio"));

            Random randomNum = new Random();
            int randomIndex = randomNum.Next(0, patientRandomList.Count - 1);
            Patient newPatient = patientRandomList[randomIndex];

            context.Patients.Add(newPatient);
            context.SaveChanges();

            RefreshGrid();
        }

        [Authorize]
        public void RemoveCron() {
            RecurringJob.AddOrUpdate("removepatient", () => RemovePatient(), "*/30 * * * * *");
        }

        [Authorize]
        public void RemovePatient()
        {
            Patient? patient = context.Patients.OrderByDescending(u => u.Id).FirstOrDefault();
            if (patient != null)
            {
                context.Patients.Remove(patient);
                context.SaveChanges();

                RefreshGrid();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}