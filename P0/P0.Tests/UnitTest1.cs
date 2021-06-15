using System;
using Xunit;
using P0;
using Businesss;
using Model;
using P0Context;

namespace P0.Tests
{
    public class UnitTest1
    {

        /*So I was doing most of my testing in my console as I built the project.
         * Origally I plan to write Xunit test after i finifhed and tested all my functionalities
         * But I realize alot of my methods contain ReadLines which Xunit doesn't like
         * So all my tests here are limited to methods without ReadLines.
         * Trust me I did spend hours testing my project so these tests dont really reflect it 
         */
        [Fact]
        public void checkNameValidInput()
        {
            //Arange
            LoginContext loginC = new LoginContext();
            string[] nameArr = {"Alain", "Duplan" };

            //Act
            bool check = loginC.checkInput(nameArr);

            //Assert
            Assert.Equal(true, check);

        }
        [Fact]
        public void testCheckIdLoginContext()
        {
            //Arange
            LoginContext loginC = new LoginContext();
            int id = 1003;

            //Act
            User check = loginC.checkId(id);

            //Assert
            Assert.Equal((new User(new ShopperContext(), id)).fname, check.fname);

        }

        [Fact]
        public void testDisplayUserInfo()
        {
            //Arange
            UserInfo ui = new UserInfo();
            Model.User u = new Model.User(new ShopperContext(), 1001);
            

            //Act
            string check = ui.displayInfo(u);

            //Assert
            Assert.True(check.Contains("Carl"));

        }
        [Fact]
        public void testOrderHistory()
        {
            //Arange
            UserInfo ui = new UserInfo();
            Model.User u = new Model.User(new ShopperContext(), 1007);
            

            //Act
            string check = ui.getOrderHistory(u);

            //Assert
            Assert.Equal(check, "Ooops, looks like you made no orders yet!");

        }

        [Fact]
        public void testGetInventory()
        {
            //Arange
            StoreInfo si = new StoreInfo();
            Model.Store s = new Model.Store("", "", 1004);
            


            //Act
            string check = si.getInventory(s);

            //Assert
            Assert.True(check.Contains("Milk(ID: 1001)"));

        }
        [Fact]
        public void testStoreGetInventory()
        {
            //Arange
            StoreInfo si = new StoreInfo();
            Model.Store s = new Model.Store("", "", 1004);



            //Act
            string check = si.getInventory(s);

            //Assert
            Assert.True(check.Contains("ID: 1006"));

        }
    }
}
