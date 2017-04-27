using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Flicker.Controllers;
using Flicker.Models;
using Xunit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Flicker.Tests.ControllerTests
{
    public class ImagesControllerTest
    {
        private readonly UserManager<ApplicationUser> _userManager;
        [Fact]
        public void Get_ViewResult_Index_Test()
        {
            var contextOptions = new DbContextOptionsBuilder()
          .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=_Flicker;integrated security=True")
          .Options;
            var _db = new ApplicationDbContext(contextOptions);
            //Arrange
           var controller = new FlickerController(_userManager, _db);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Get_ModelList_Index_Test()
        {
            var contextOptions = new DbContextOptionsBuilder()
         .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=_Flicker;integrated security=True")
         .Options;
            var _db = new ApplicationDbContext(contextOptions);
            //Arrange
            FlickerController controller = new FlickerController(_userManager, _db);
            IActionResult actionResult = controller.Index();
            ViewResult indexView = controller.Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsType<List<Image>>(result);
        }
    }
}
