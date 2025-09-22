using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using send_email.EmailHelper;
using send_email.Models;

namespace send_email.Controllers
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
        public IActionResult SendMail(string to, string subject, string message)
        {
            EmailhelperVM emailHelper = new EmailhelperVM();
            bool res = emailHelper.SendMail(to, subject, message);
            if (res == true)
            {
                TempData["Msg"] = "mail send successfully";
                return RedirectToAction("Index");

            }
            TempData["Msg"] = "unable to send mail";
            return RedirectToAction("/Home/Index");
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
