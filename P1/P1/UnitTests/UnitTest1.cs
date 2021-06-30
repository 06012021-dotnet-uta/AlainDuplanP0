using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Busy;
using ModelsDefault;
using System.Collections;
using System.Collections.Generic;


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
            Assert.True(!Fcheck);

        }

        [Fact]
        public void TestGetIdMax()
        {

            //Arrange
            ISignUP signUP = new SignUp();
            int id;

            //Act
            id = signUP.getID();

            //Assert
            Assert.True(id >= 1024);


        }

        [Fact]
        public void TestGetUser()
        {

            //Arrange
            ISignUP signUP = new SignUp();
            int id = 1023;
            ModelsDefault.User user = new ModelsDefault.User();
            user.id = id;

            //Act
            ModelsDefault.User check = signUP.getUser(user);

            //Assert
            Assert.Equal("Test", user.fname);
            Assert.Equal("Test", user.lname);
            Assert.Equal(1000, user.storeId);
            Assert.Equal(0, user.auth);

        }

        [Fact]
        public void TestCheckStore()
        {

            //Arrange
            INewOrder newOrder = new NewOrder();
            int Tid = 1023;
            int Fid = 9999;

            //Act
            bool Tcheck = newOrder.checkStore(Tid);
            bool Fcheck = newOrder.checkStore(Fid);

            //Assert
            Assert.True(!Tcheck);
            Assert.True(Fcheck);

        }

        [Fact]
        public void TestCheckItem()
        {

            //Arrange
            INewOrder newOrder = new NewOrder();
            int itemId1 = 1003;
            int itemId2 = 1006;
            int itemId3 = 1007;
            int itemId4 = 1004;
            int storeId = 1000;
            int storeId2 = 1999;

            //Act
            bool check1 = newOrder.checkItem(storeId, itemId1);
            bool check2 = newOrder.checkItem(storeId, itemId2);
            bool check3 = newOrder.checkItem(storeId, itemId3);
            bool check4 = newOrder.checkItem(storeId, itemId4);
            bool check5 = newOrder.checkItem(storeId2, itemId1);

            //Assert
            Assert.True(!check1);
            Assert.True(!check2);
            Assert.True(!check3);
            Assert.True(check4);
            Assert.True(check5);

        }
        [Fact]
        public void TestCheckQuantity()
        {

            //Arrange
            INewOrder newOrder = new NewOrder();
            int itemId1 = 1003;
            int itemId2 = 1006;
            int itemId3 = 1007;
            //int itemId4 = 1004;
            int storeId = 1000;
            //int storeId2 = 1999;
            int goodQuan = 10;
            int badQuan = 1000;

            //Act
            bool check1 = newOrder.checkQuantity(storeId, itemId1, goodQuan);
            bool check2 = newOrder.checkQuantity(storeId, itemId2, goodQuan);
            bool check3 = newOrder.checkQuantity(storeId, itemId3, goodQuan);
            //bool check4 = newOrder.checkQuantity(storeId2, itemId1, goodQuan);
            //bool check5 = newOrder.checkQuantity(storeId, itemId4, goodQuan);
            bool check6 = newOrder.checkQuantity(storeId, itemId1, badQuan);
            bool check7 = newOrder.checkQuantity(storeId, itemId2, badQuan);
            bool check8 = newOrder.checkQuantity(storeId, itemId3, badQuan);
            //bool check9 = newOrder.checkQuantity(storeId2, itemId1, badQuan);
            //bool check9 = newOrder.checkQuantity(storeId, itemId4, badQuan);

            //Assert
            Assert.True(!check1);
            Assert.True(!check2);
            Assert.True(!check3);
            Assert.True(check6);
            Assert.True(check7);
            Assert.True(check8);

        }

        [Fact]
        public void TestBuildOrder()
        {
            //Act
            ModelsDefault.Order order;
            INewOrder newOrder = new NewOrder();
            DateTime now = DateTime.Now;

            //Arrange
            order = newOrder.buildOrder();

            //Assert
            Assert.True(order != null);
            Assert.True(1000 <= order.custId);
            Assert.True(1000 <= order.store);
            Assert.True(1000 <= order.id);
            Assert.True(now > order.time);
        }


        [Fact]
        public void TestListStore()
        {
            //Act
            ModelsDefault.User user1 = new ModelsDefault.User();
            ModelsDefault.User user2 = new ModelsDefault.User();
            ModelsDefault.User user3 = new ModelsDefault.User();
            user1.findStore = "a";
            user2.findStore = "Walmart";
            user3.findStore = "jnbdjnbsdjbnjsdn";
            IStoreSearch storeSearch = new StoreSearch();

            //Arrange
            ArrayList list1 = storeSearch.listsStores(user1);
            ArrayList list2 = storeSearch.listsStores(user2);
            ArrayList list3 = storeSearch.listsStores(user3);            

            //Assert
            Assert.True(list3.Count == 0);
            Assert.True(list2.Count == 1);
            Assert.True(list1.Count > 5);
            
        }

        [Fact]
        public void TestGetOrders()
        {
            //Act
            ModelsDefault.Store store1 = new ModelsDefault.Store() {id = 1000 }; // over 10
            ModelsDefault.Store store2 = new ModelsDefault.Store() { id = 1043 }; //error
            ModelsDefault.Store store3 = new ModelsDefault.Store() { id = 1019 }; //0
            IStoreSearch storeSearch = new StoreSearch();

            //Arrange
            ArrayList list1 = storeSearch.getOrders(store1);
            ArrayList list2 = storeSearch.getOrders(store2);
            ArrayList list3 = storeSearch.getOrders(store3);

            //Assert
            Assert.True(list3.Count == 0);
            Assert.True(list2.Count == 0);
            Assert.True(list1.Count > 10);

        }
        [Fact]
        public void TestGetStore2()
        {
            //Act
            int id1 = 1000;
            IStoreSearch storeSearch = new StoreSearch();

            //Arrange
            ModelsDefault.Store store = storeSearch.getStore2(id1);
            
            //Assert
            Assert.Equal(1000, store.id);
            Assert.Equal("Walmart", store.name);
            Assert.Equal("No Location Data Available", store.location);
            Assert.True(10 > store.numOrders);     
        }

        [Fact]
        public void TestGetInventory()
        {
            //Act
            ModelsDefault.Store store1 = new ModelsDefault.Store() { id = 1000 }; // 9
            ModelsDefault.Store store2 = new ModelsDefault.Store() { id = 1043 }; //error
            ModelsDefault.Store store3 = new ModelsDefault.Store() { id = 1019 }; //0
            IStoreSearch storeSearch = new StoreSearch();

            //Arrange
            ArrayList list1 = storeSearch.getInventory(store1);
            ArrayList list2 = storeSearch.getInventory(store2);
            ArrayList list3 = storeSearch.getInventory(store3);
            //Assert
            Assert.True(list3.Count == 0);
            Assert.True(list2.Count == 0);
            Assert.True(list1.Count == 9);

        }

        [Fact]
        public void TestGetInventoryByID()
        {
            //Act
            int  id1 = 1000; // 9
            int id2 = 1043; //error
            int id3 = 1019; //0
            IStoreSearch storeSearch = new StoreSearch();

            //Arrange
            ArrayList list1 = storeSearch.getInventorybyID(id1);
            ArrayList list2 = storeSearch.getInventorybyID(id2);
            ArrayList list3 = storeSearch.getInventorybyID(id3);
            //Assert
            Assert.True(list3.Count == 0);
            Assert.True(list2.Count == 0);
            Assert.True(list1.Count == 9);

        }
        [Fact]
        public void TestGetUserOrders()
        {
            //Act
            ModelsDefault.User user1 = new ModelsDefault.User() { id = 1000 };
            ModelsDefault.User user2 = new ModelsDefault.User() { id = 1013 };
            ModelsDefault.User user3 = new ModelsDefault.User() { id = 1019 };
            IUserOrders userOrder = new UserOrders();

            //Arrange
            ArrayList list1 = userOrder.getOrders(user1);
            ArrayList list2 = userOrder.getOrders(user2);
            ArrayList list3 = userOrder.getOrders(user3);

            //Assert
            Assert.True(list3.Count == 0);
            Assert.True(list2.Count == 2);
            Assert.True(list1.Count == 4);

        }
        [Fact]
        public void TestGetOrdersItems()
        {
            //Act
            ModelsDefault.Order order1 = new ModelsDefault.Order() { id = 1009 };
            ModelsDefault.Order order2 = new ModelsDefault.Order() { id = 1014 };                       
            IUserOrders userOrder = new UserOrders();

            //Arrange
            ArrayList list1 = userOrder.getOrderItems(order1);
            ArrayList list2 = userOrder.getOrderItems(order2);          

            //Assert
            Assert.True(list2.Count == 0);
            Assert.True(list1.Count == 2);

        }
        [Fact]
        public void TestListUser()
        {
            //Act
            ModelsDefault.User user1 = new ModelsDefault.User() { findF = "a" };
            ModelsDefault.User user2 = new ModelsDefault.User() { findL = "Test" };
            ModelsDefault.User user3 = new ModelsDefault.User() { findF = "Carl", findL = "Herisca" };
            IUserSearch userSearch = new UserSearch();

            //Arrange
            ArrayList list1 = userSearch.listUsers(user1);
            ArrayList list2 = userSearch.listUsers(user2);
            ArrayList list3 = userSearch.listUsers(user3);


            //Assert
            Assert.True(list1.Count > 5);
            Assert.True(list2.Count >= 1);
            Assert.True(list3.Count == 2);


        }
    }

    
}

