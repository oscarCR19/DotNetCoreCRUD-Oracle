using DotCoreExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.OracleClient;
using System.Data;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Client;

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

           

            string queryString =
        "INSERT INTO Usuarios(USER_ID,USER_USER,PASS) values (50, 'TECHNOLOGY', 'DENVER')";
            using (Oracle.ManagedDataAccess.Client.OracleConnection connection = new OracleConnection("DATA SOURCE=10.204.3.1:1521/PROD;" +
"PERSIST SECURITY INFO=True;USER ID=; password=; Pooling = False;"))
            {
                OracleCommand command = new OracleCommand(queryString);
                command.Connection = connection;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }



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