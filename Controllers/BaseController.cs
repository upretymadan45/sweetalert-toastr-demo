using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using sweetalert.Models;

namespace sweetalert.Controllers
{
    public class BaseController : Controller
    {

        public void Notify(string message, string title="Sweet Alert Toastr Demo", 
                                    NotificationType notificationType=NotificationType.success)
        {
            var msg = new { 
                message = message, 
                title = title, 
                icon = notificationType.ToString(), 
                type = notificationType.ToString(),
                provider = GetProvider()
            };

            TempData["Message"] = JsonConvert.SerializeObject(msg);
        }

        private string GetProvider()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            var value = configuration["NotificationProvider"];

            return value;
        }
    }
}