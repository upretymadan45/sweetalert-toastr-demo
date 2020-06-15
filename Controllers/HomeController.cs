using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sweetalert.Models;

namespace sweetalert.Controllers
{
    public class HomeController : BaseController
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


        public IActionResult Save()
        {
            try
            {
                //try save data into database
                Notify("Data saved successfully");
            }
            catch (Exception)
            {
                
            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete()
        {
            try
            {
                throw new UnauthorizedAccessException();
            }
            catch (Exception)
            {
                Notify("Could not delete data!", notificationType:NotificationType.error);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
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
