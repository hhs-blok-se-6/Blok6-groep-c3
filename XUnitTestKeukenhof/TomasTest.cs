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

        //Redirect vanaf de homepage naar de park pagina
        [Fact]
        public void RedirectPark()
        {
            //Arrange
            var context = GetInMemoryDBMetData();
            var controller = new HomeController(context);

            //Act
            var result = controller.Park();

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Park", redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        //Redirect vanaf de homepage naar de praktische info pagina
        [Fact]
        public void RedirectPraktisch()
        {
            //Arrange
            var context = GetInMemoryDBMetData();
            var controller = new HomeController(context);

            //Act
            var result = controller.Praktisch();

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Praktisch", redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        //Is de modelstate in Edit van HomeContent invalid
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

        //Is de modelstate in Edit van HomeContent valid
        [Fact]
        public async Task ModelState_Valid()
        {
            //Arrange
            var context = GetInMemoryDBMetData();
            var controller = new HomeContentController(context);

            //Act
            var result = await controller.Edit(1);

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);

        }

        //Controleren of de detail methode in homecontentcontroller geen null of notFound geeft als je een ID waarde geeft
        [Fact]
        public async Task DetailsNotNull()
        {
            //Arrange
            var context = GetInMemoryDBMetData();
            var controller = new HomeContentController(context);

            //Act
            var result = await controller.Details(1);

            //Assert
            Assert.NotNull(controller.Details(1));
        }
    }
}
