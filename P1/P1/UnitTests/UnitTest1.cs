using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Busy;
using ModelsDefault;
using System.Collections;

namespace UnitTests
{
       public class UnitTest1
    {
         /*DbContextOptions<ShopperContext.ShopperContext> options = new DbContextOptionsBuilder<ShopperContext.ShopperContext>()
    .UseInMemoryDatabase(databaseName: "TestingDb")
    .Options; */
        [Fact]
        public void TestCheckID()
        {

            //Arrange
            
            ISignUP signUP = new SignUp();
            int Tid = 1023;
            int Fid = 9999;

            //Act
            bool Tcheck = signUP.checkID(Tid);
            bool Fcheck = signUP.checkID(Fid);

            //Assert
            Assert.True(Tcheck);
            Assert.True(Fcheck);

        }
    }
}
