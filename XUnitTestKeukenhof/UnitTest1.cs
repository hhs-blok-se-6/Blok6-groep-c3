using KeukenhofV2.Controllers;
using KeukenhofV2.Data;
using KeukenhofV2.Models;
using KeukenhofV2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace XUnitTestKeukenhof
{
    public class UnitTest1
    {

        public KeukenhofContext GetContext()
        {
            var options = new DbContextOptionsBuilder<KeukenhofContext>()
                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                      .Options;
            return new KeukenhofContext(options);
        }

        public KeukenhofContext GetInMemoryDBMetData()
        {
            var context = GetContext();
            context.Add(new HomeContent { Id = 1, Type = "h1", Content = "Het mooiste lentepark ter wereld!" });
            context.Add(new HomeContent { Id = 2, Type = "h4", Content = "Open 21 Maart - 10 Mei" });
            context.Add(new HomeContent { Id = 3, Type = "label", Content = "ontdek het park" });
            context.Add(new FeaturedContent { Id = 1, Page = "Home", Link = "Bereikbaarheid", Image = "/images/P01Home/featured-1.png", Text = "Bereikbaarheid", Theme = "orange" });
            context.Add(new FeaturedContent { Id = 2, Page = "Home", Link = "Evenementen", Image = "/images/P01Home/featured-2.jpg", Text = "Evenementen", Theme = "orange" });
            context.Add(new FeaturedContent { Id = 3, Page = "Home", Link = "Evenementen/Bloemenshow", Image = "/images/P01Home/featured-4.svg", Text = "Bloemenshow", Theme = "orange" });
            context.SaveChanges();
            return context;
        }

        [Fact]
        public void LoadHomeContent() // test of de content correct uit de db gehaald wordt
        {
            var context = GetInMemoryDBMetData();
            var controller = new HomeController(context);

            var view = controller.Home();
            var viewResult = Assert.IsType<ViewResult>(view);

            // wordt de view correct meegegeven
            Assert.IsAssignableFrom<IActionResult>(view);
            Assert.IsType<ViewResult>(view);
            Assert.True(string.IsNullOrEmpty(viewResult.ViewName) || viewResult.ViewName == "Home" || viewResult.ViewName == "Home/Index");

            // wordt de HomeViewModel correct meegegeven
            var model = Assert.IsAssignableFrom<HomeViewModel>(viewResult.Model); // is het HomeViewModel
            var homeContent = model.HomeContent.ToList();
            Assert.Equal(3, homeContent.Count);
            Assert.Equal("ontdek het park", homeContent[2].Content);
        }

        public bool IsImage(string path) // checkt of de extension van het path een image is
        {
            string[] imgPath = path.Split(".");
            string extension = imgPath[imgPath.Length - 1];
            if (extension == "png" || extension == "jpg" || extension == "gif" || extension == "svg")
                return true;

            return false;
        }

        [Fact]
        public void ValidateFeaturedContent() // test of de feature items goed worden geladen
        {
            var controller = new HomeController(GetInMemoryDBMetData());
            var view = controller.Home() as ViewResult;

            var model = Assert.IsAssignableFrom<HomeViewModel>(view.Model);
            var featured = model.FeaturedContent.ToList();
            Assert.Equal(3, featured.Count());

            for (int i = 0; i < featured.Count(); i++) // alle items moeten correcte content hebben
            {
                Assert.NotNull(featured[i].Page);
                Assert.NotNull(featured[i].Link);
                Assert.NotNull(featured[i].Text);
                Assert.True(IsImage(featured[i].Image));
            }

        }
    }
}
