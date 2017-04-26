using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Flicker.Models;

namespace Flicker.Tests
{
    public class ImageTest
    {
        [Fact]
        public void GetDescriptionTest()
        {
            //Arrange
            var image = new Image();
            image.Description = ("test description");

            //Act
            var result = image.Description;

            //Assert
            Assert.Equal("test description", result);
        }
    }
}
