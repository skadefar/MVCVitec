using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCVitec.Models;
using MVCVitec.Data;
using Microsoft.AspNetCore.Authorization;

namespace MVCVitec.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger logger;
        private readonly ProductConnection connect = new ProductConnection();

        public HomeController(ILogger<HomeController> logger)
        {
            List<Product> products = connect.GetData();

            this.logger = logger;
        }
        public IActionResult Index()
        {
           string Message = $"Vist  {DateTime.Now.ToLocalTime()}";
            logger.LogWarning($"Message {Message} ");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
