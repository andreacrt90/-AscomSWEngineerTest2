using AscomSWEngineerTest2.Interfaces;
using AscomSWEngineerTest2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace AscomSWEngineerTest2.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public UserController(ILogger<PatientController> logger, IConfiguration configuration, IUserRepository userRepository)
        {
            _logger = logger;
            _configuration = configuration;
            _userRepository = userRepository;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}