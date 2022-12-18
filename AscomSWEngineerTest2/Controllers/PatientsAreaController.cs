using AscomSWEngineerTest2.Helpers;
using AscomSWEngineerTest2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SQLitePCL;
using System.Diagnostics;

namespace AscomSWEngineerTest2.Controllers
{
    public class PatientsAreaController : Controller
    {
        private readonly ILogger<PatientsAreaController> _logger;
        private readonly IConfiguration _configuration;

        public PatientsAreaController(ILogger<PatientsAreaController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public ActionResult PatientsList()
        {

            var context = new DataContext(_configuration);
                
            //Get the existing calculations from the db
            var users = context.Users.ToList();

            ////Create a new Calculation
            //var calculation = new Calculation
            //{
            //    //Increment the Id
            //    Id = intialCalculations.Count() == 0 ? 1 : intialCalculations.Max(x => x.Id) + 1,
            //};

            ////Give a name to our new Calculation
            //calculation.Name = $"calculation {calculation.Id}";

            ////Add the new Calculation to the context
            //context.Calculations.Add(calculation);

            ////And save it to the db
            //context.SaveChanges();

            ////Get all the calculations again from the db (our new Calculation should be there)
            //var allCalculations = context.Calculations.ToList();

            return Json(users);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}