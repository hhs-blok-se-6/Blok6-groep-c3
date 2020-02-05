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

        private string databaseName;

        public KeukenhofContext GetContext(bool NewDb)
        {
            if (NewDb) databaseName = Guid.NewGuid().ToString();
            var options = new DbContextOptionsBuilder<KeukenhofContext>()
                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                      .Options;
            return new KeukenhofContext(options);
        }

        public KeukenhofContext GetInMemoryDBMetData()
        {
            var context = GetContext(true);
            context.Add(new HomeContent { Id = 1, Type = "h1", Content = "Het mooiste lentepark ter wereld!" });
            context.Add(new HomeContent { Id = 2, Type = "h4", Content = "Open 21 Maart - 10 Mei" });
            context.Add(new HomeContent { Id = 3, Type = "label", Content = "ontdek het park" });
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
    }
}
