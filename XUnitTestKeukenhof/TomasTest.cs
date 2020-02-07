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
            var result = await controller.Index();

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
            var result = await controller.Index();

            //Assert
            var redirectToActionResult = Assert.IsType<ViewResult>(result);
            Assert.Null(redirectToActionResult.Model);
            Assert.Equal("Index", redirectToActionResult.ViewName);
        }
    }
}
