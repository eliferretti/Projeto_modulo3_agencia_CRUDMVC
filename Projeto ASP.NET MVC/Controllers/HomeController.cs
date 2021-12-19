using CRUDMVC.Data;
using CRUDMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDMVC.Controllers
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

        [HttpGet]
        public IActionResult Destinos()
        {
            var dbcontext = new Contexto();

            ViewData["destinos"] = dbcontext.Destinos.Where(p => p.Id > 0).ToList();
         
            return View();
        }


        [HttpGet]
        public IActionResult Promocoes()
        {
            var dbcontext = new Contexto();

            ViewData["promocoes"] = dbcontext.Destinos.Where(p => p.Promo.Equals("Sim") && p.Id > 0).ToList();
          
            return View();
        }



        public IActionResult Contato() 
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
