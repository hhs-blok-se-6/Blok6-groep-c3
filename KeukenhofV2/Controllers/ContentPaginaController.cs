using KeukenhofV2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KeukenhofV2.Controllers
{
    public class ContentPaginaController : Controller
    {
        private readonly KeukenhofContext _context;

        public ContentPaginaController(KeukenhofContext context)
        {
            _context = context;
        }

        [Route("/Content")]
        [Route("/Contentpagina")]
        public async Task<IActionResult> Content()
        {
            var contentContent = from hc in _context.ContentContent select hc;

            return View("Contentpagina", await contentContent.AsNoTracking().ToListAsync());
        }

        public async Task<IActionResult> Edit()
        {
            var contentCOntent = from hc in _context.ContentContent select hc;

            return View("EditContentpagina", await contentCOntent.AsNoTracking().ToListAsync());
        }
    }
}