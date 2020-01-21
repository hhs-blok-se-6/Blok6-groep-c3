using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KeukenhofV2.Controllers
{
    public class ParkController : Controller
    {

        [Route("/Park")]
        public IActionResult Park()
        {
            return View();
        }
    }
}