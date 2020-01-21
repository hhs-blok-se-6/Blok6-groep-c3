using KeukenhofV2.Data;
using Microsoft.AspNetCore.Mvc;

namespace KeukenhofV2.Controllers
{
    public class ContactController : Controller
    {
        private readonly KeukenhofContext _context;

        public ContactController(KeukenhofContext context)
        {
            this._context = context;

        }

        [Route("/Contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}