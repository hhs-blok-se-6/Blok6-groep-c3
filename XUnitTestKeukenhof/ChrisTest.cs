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
    //Door Christian
    public class ChrisTest
    {
        private string databaseName;

        private KeukenhofContext GetInMemoryDBMetData()
        {
            KeukenhofContext context = GetNewInMemoryDatabase(true);
            context.Add(new ZoekResultaten { Id = 1, Type = "h1", Content = "Testcontent_1"});
            context.Add(new ZoekResultaten { Id = 2, Type = "h1", Content = "Testcontent_2"});
            context.Add(new ZoekResultaten { Id = 3, Type = "h1", Content = "Testcontent_3"});
            context.Add(new ZoekResultaten { Id = 4, Type = "h1", Content = "Testcontent_4"});
            context.Add(new ZoekResultaten { Id = 5, Type = "h1", Content = "Testcontent_5"});
            context.Add(new ZoekResultaten { Id = 6, Type = "h1", Content = "Testcontent_6"});
            context.Add(new ZoekResultaten { Id = 7, Type = "h1", Content = "Testcontent_7"});
            context.Add(new ZoekResultaten { Id = 8, Type = "h1", Content = "Testcontent_8"});
            
            //Zou alleen op pagina 1 zichtbaar mogen zijn!
            context.Add(new ZoekResultaten { Id = 9, Type = "h1", Content = "Testcontent_9"});
            context.Add(new ZoekResultaten { Id = 10, Type = "h1", Content = "Testcontent_10"});
            context.Add(new ZoekResultaten { Id = 11, Type = "h1", Content = "Testcontent_11_flag" });
            

            context.SaveChanges();
            context = GetNewInMemoryDatabase(false);
            return context;
        }

        private KeukenhofContext GetNewInMemoryDatabase(bool NewDb)
        {
            if (NewDb)
            {
                this.databaseName = Guid.NewGuid().ToString();
            }

            var options = new DbContextOptionsBuilder<KeukenhofContext>()
                .UseInMemoryDatabase(this.databaseName)
                .Options;

            return new KeukenhofContext(options);
        }

        [Fact]
        public async Task Test1()
        {
            KeukenhofContext context = GetInMemoryDBMetData();
            var controller = new ZoekResultatenController(context);

            //Testen van eerste pagina:
            var result = await controller.Zoekresultaten("", "", 1);
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<PaginatedList<ZoekResultaten>>(viewResult.ViewData.Model);
            Assert.Equal(8, model.Count); //Maximum van 8 resulaten per pagina
            Assert.Equal("Testcontent_1", model.ElementAt(0).Content);
            Assert.Equal(1, viewResult.ViewData["CurrentPage"]); //pagina = 1
            Assert.Equal("", viewResult.ViewData["CurrentFilter"]); //zoekterm = ""

            /*Testen van pagina 2
             logica: als er meer dan 8 zoekresultaten zijn -> dan komen de overige resultaten op een nieuwe pagina
             -> tot een max van 8 per pagina*/
            var result2 = await controller.Zoekresultaten("", "", 2); //Pagina = 2
            var viewResult2 = Assert.IsType<ViewResult>(result);
            var model2 = Assert.IsAssignableFrom<PaginatedList<ZoekResultaten>>(viewResult2.ViewData.Model);
            Assert.Equal(3, model2.Count); //10 in totaal in de model. 8 Staan er op pagina 1, dus 11 - 8 moet 3 zoekresultaten geven
            Assert.Equal("Testcontent_9", model2.ElementAt(0).Content);
            Assert.Equal(2, viewResult.ViewData["CurrentPage"]);
            Assert.Equal("", viewResult.ViewData["CurrentFilter"]);

            //Moet 10 zijn
            Assert.Equal("11 zoekresultaten", viewResult.ViewData["Counter"]);

            //Zoeken -> op woord 'Test' 
            result = await controller.Zoekresultaten("", "test", 0); 
            viewResult = Assert.IsType<ViewResult>(result);
            model = Assert.IsAssignableFrom<PaginatedList<ZoekResultaten>>(viewResult.ViewData.Model);
            Assert.Equal("test", viewResult.ViewData["CurrentFilter"]);
            Assert.Equal(8, model.Count);
        }
        }
    }
