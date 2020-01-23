using KeukenhofV2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;



namespace KeukenhofV2.Controllers
{
    public class PrivacyController : Controller
    {

        private readonly KeukenhofContext _context;

        public PrivacyController(KeukenhofContext context)
        {
            _context = context;
        }

        [Route("/Privacy")]
        [Route("/Privacy/Index")]
        public async Task<IActionResult> Privacy()
        {
            var privacyContent = from pc in _context.PrivacyContent select pc;

            return View("Privacy", await privacyContent.AsNoTracking().ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> Edit()
        {
            var privacyContent = from pc in _context.PrivacyContent select pc;

            return View("EditPrivacy", await privacyContent.AsNoTracking().ToListAsync());
        }
    }
}