using KeukenhofV2.Data;
using KeukenhofV2.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KeukenhofV2.Controllers
{
    public class ParkController : Controller
    {

        private readonly KeukenhofContext _context;

        public ParkController(KeukenhofContext context)
        {
            _context = context;
        }
        [Route("/Park")]
        [Route("/Park/Index")]
        public IActionResult Park()
        {
            var parkContent = from pc in _context.ParkContent select pc;

            var bezigheden = from b in _context.CardContent where b.Page.Equals("Park") && b.Fragment.Equals("bezigheden") select b;
            var evenementen = from e in _context.CardContent where e.Page.Equals("Park") && e.Fragment.Equals("evenementen") select e;
            var bloemenshows = from shows in _context.CardContent where shows.Page.Equals("Park") && shows.Fragment.Equals("bloemenshows") select shows;

            var plattegrond = from p in _context.CTAButtons where p.Page.Equals("Park") && p.Fragment.Equals("plattegrond") select p;
            var tulpomania = from t in _context.CTAButtons where t.Page.Equals("Park") && t.Fragment.Equals("tulpomania") select t;

            ParkViewModel pvm = new ParkViewModel()
            {
                ParkContent = parkContent,
                Bezigheden = bezigheden,
                BezighedenRows = 1,
                BezighedenColumns = 4,
                Plattegrond = plattegrond,
                Tulpomania = tulpomania,
                Evenementen = evenementen,
                EvenementenRows = 1,
                EvenementenColumns = 4,
                Bloemenshows = bloemenshows,
                BloemenshowsRows = 1,
                BloemenshowsColumns = 4,

            };
            return View(pvm);
        }

        [Authorize]
        public async Task<IActionResult> Edit()
        {
            var evenementContent = from pc in _context.EvenementenContent select pc;

            return View("EditPark", await evenementContent.AsNoTracking().ToListAsync());
        }

    }
}