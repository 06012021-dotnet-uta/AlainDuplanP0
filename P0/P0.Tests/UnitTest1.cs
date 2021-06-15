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
        public void checkNameValidInput()//checks if searching names functionality
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
        public void testCheckIdLoginContext()//checks if we can successfully create a user object on login
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
        public void testDisplayUserInfo()//checks if we can display accurate user info
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
        public void testOrderHistory()// checks we can display whether if a user made no order
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
        public void testGetInventory()// checks if we can get the invetory of a store
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
        public void testStoreGetInventory()//checks if we can get the invetory of a store
        {
            //Arange
            StoreInfo si = new StoreInfo();
            Model.Store s = new Model.Store("", "", 1004);



            //Act
            string check = si.getInventory(s);

            //Assert
            Assert.True(check.Contains("ID: 1006"));

        }
        [Fact]
        public void testUserGetInventory() // check if we can get accurate order info
        {
            //Arange
            OrderInfo oi = new OrderInfo();
            Model.Order o = new Model.Order();
            o.id = 1009;

            //Act
            string check = oi.getInventory(o);

            //Assert
            Assert.True(check.Contains("Eggs(ID: 1000), Quantity held: 4,"));

        }

        [Fact]
        public void testAddItem() //check if we can successfully add an item
        {
            //Arange
            Model.Order o = new Model.Order();
            Model.Inventory i = new Model.Inventory(1004, 3, 40.0);



            //Act
            o.addItem(i);

            //Assert
            Assert.True(o.getOrder().Count > 0);

        }

        [Fact]
        public void testGetTotal()//checks if we can get an accurate total
        {
            //Arange
            Model.Order o = new Model.Order();
            Model.Inventory i = new Model.Inventory(1004, 3, 40.0);



            //Act
            o.addItem(i);

            //Assert
            Assert.True(o.getTotal() == 120);

        }

        [Fact]
        public void testAddMultiple()// test if our order can handle multiple items
        {
            //Arange
            Model.Order o = new Model.Order();
            Model.Inventory i1 = new Model.Inventory(1004, 3, 40.0);
            Model.Inventory i2 = new Model.Inventory(1005, 5, 60.0);
            Model.Inventory i3 = new Model.Inventory(1006, 5, 30.0);



            //Act
            o.addItem(i1);
            o.addItem(i3);
            o.addItem(i2);

            //Assert
            Assert.True(o.getOrder().Count == 3);
            Assert.True(o.getTotal() == 570);

        }
    } //class
}//namespace
