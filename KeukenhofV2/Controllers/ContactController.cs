using KeukenhofV2.Data;
using KeukenhofV2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KeukenhofV2.Controllers
{
    public class ContactController : Controller
    {
        private readonly KeukenhofContext _context;

        public ContactController(KeukenhofContext context)
        {
            _context = context;
        }
        [Route("/Contact")]
        [Route("/Contact/Index")]
        public IActionResult Contact()
        {
            var contact = from c in _context.ContactContent select c;
            var feature = from f in _context.FeaturedContent where f.Page.Equals("Contact") select f;
            var faq = from fq in _context.FAQ where fq.Page.Equals("Contact") select fq;

            MiniFaqViewModel miniFaq = new MiniFaqViewModel()
            {
                Image = "/images/P08Contact/FAQImage.png",
                FAQ = faq,
                Theme = "orange"
            };

            ContactViewModel cvm = new ContactViewModel()
            {
                ContactContent = contact,
                FeaturedContent = feature,
                FeatureRows = 1,
                FeatureColumns = 4,
                MiniFAQ = miniFaq
            };
            return View(cvm);
        }

        [Autorize]
        public async Task<IActionResult> Edit()
        {
            var contactContent = from hc in _context.ContactContent select hc;

            return View("EditContact", await contactContent.AsNoTracking().ToListAsync());
        }
    }
}