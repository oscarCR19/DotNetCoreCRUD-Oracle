using DotCoreExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.OracleClient;
using System.Data;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Client;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DotCoreExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {





           



          

            return View();
         }

        

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}