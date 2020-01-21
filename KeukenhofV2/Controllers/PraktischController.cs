using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KeukenhofV2.Controllers
{
    public class PraktischController : Controller
    {
        [Route("/Praktisch")]
        public IActionResult Praktisch()
        {
            return View();
        }
    }
}