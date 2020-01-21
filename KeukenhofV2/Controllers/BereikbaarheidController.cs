using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KeukenhofV2.Controllers
{
    public class BereikbaarheidController : Controller
    {
        [Route("/Bereikbaarheid")]
        public IActionResult Bereikbaarheid()
        {
            return View();
        }
    }
}