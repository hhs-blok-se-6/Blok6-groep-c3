using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KeukenhofV2.Controllers
{
    public class ZoekresultatenController : Controller
    {
        [Route("/Zoekresultaten")]
        public IActionResult Zoekresultaten(string searchValue)
        {
            ViewData["Search"] = searchValue; 
            return View();
        }


    }
}