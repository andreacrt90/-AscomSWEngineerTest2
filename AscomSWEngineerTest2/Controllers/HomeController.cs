using AscomSWEngineerTest2.Crypt;
using AscomSWEngineerTest2.Helpers;
using AscomSWEngineerTest2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AscomSWEngineerTest2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login(UserLogin userLogin)
		{
            if (!ModelState.IsValid)
			{
				return View("Index");
			}

            // first auth (BasicAuthenticationHandler block request and return 401)
            DataContext context = new DataContext(_configuration);
            if (context.Users.Where(x => x.Username == userLogin.Username && x.Password == AesCrypter.Encrypt(userLogin.Password)).Count() == 0)
            {
                return View("Index");
            }

			Session.Username = userLogin.Username;
			Session.Password = userLogin.Password;

            return RedirectToAction("PatientsArea", "PatientsArea");
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}