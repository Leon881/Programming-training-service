using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalPortal.Controllers
{
    //[Route("api/[controller]")]
    public class HomeController : Controller
    {
        //[Route("index")]
        //[HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}

