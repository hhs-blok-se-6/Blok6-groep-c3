using Xunit;
using KeukenhofV2.Models;
using KeukenhofV2.Data;
using KeukenhofV2.Controllers;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace XUnitTestKeukenhof
{
    //Door Tomas
    public class TomasTest
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
            context.SaveChanges();
            return context;
        }

        [Fact]
        public async Task ModelState_Invalid()
        {
            //Arrange
            var context = GetInMemoryDBMetData();
            var controller = new HomeContentController(context);

            //Act
            var result = await controller.Edit(1);

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public async Task ModelState_Valid()
        {
            //Arrange
            var context = GetInMemoryDBMetData();
            var controller = new HomeContentController(context);

            //Act
            var result = await controller.Edit(1);

            //Assert
            var redirectToActionResult = Assert.IsType<ViewResult>(result);
            //Assert.Null(redirectToActionResult.Model);
            Assert.Equal("Edit", redirectToActionResult.ViewName);
        }

        [Fact]
        public async System.Threading.Tasks.Task CorrectID() //Checken of alle ID's wel kloppen en niks is overgeslagen
        {
            var context = GetInMemoryDBMetData();
            var controller = new HomeContentController(context);

            var result = await controller.Edit(1) as ViewResult;
            var model = Assert.IsAssignableFrom<HomeContent>(result.Model);

            var content = model.Id;

            //Loop om te kijken of alle ID's er in staan
            for (int i = 1; i < 3 /* dit nummer is de grootte van de database */; i++)
            {
                Assert.Equal(i.ToString(), content.ToString());
                content += i;
            }
        }
    }
}
