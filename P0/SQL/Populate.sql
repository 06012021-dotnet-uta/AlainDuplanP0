--se shopper;

INSERT INTO Customer(CustomerFName, CustomerLName)
VALUES('Alain', 'Duplan');

INSERT INTO Customer(CustomerFName, CustomerLName)
VALUES('Carl', 'Herisca');

INSERT INTO Customer(CustomerFName, CustomerLName)
VALUES('Mark', 'Moore');

INSERT INTO Customer(CustomerFName, CustomerLName)
VALUES('Max', 'Mind');

INSERT INTO Customer(CustomerFName, CustomerLName)
VALUES('John', 'Smith');

---INSERT INTO Customer(CustomerFName, CustomerLName, CustomerTop)
--VALUES('Jack', 'Doe', 1003);

--elect * FROM Customer; */

--Select * FROM Customer; 

 INSERT INTO Item(ItemName, ItemPrice)
VALUES('Eggs', 1.99);

INSERT INTO Item(ItemName, ItemPrice)
VALUES('Milk', 2.99);

INSERT INTO Item(ItemName, ItemPrice)
VALUES('Steak', 17.99);

INSERT INTO Item(ItemName, ItemPrice)
VALUES('Soy Sauce', 3.99);

INSERT INTO Item(ItemName, ItemPrice)
VALUES('Cheese', 4.99);

--Select * from Item; */

INSERT INTO Item(ItemName, ItemPrice, ItemDescription)
VALUES('Wagyu', 4.99, 'The Finest of All Steaks');

--Select * from Item;

INSERT INTO Store(StoreName)
VALUES('Walmart');

INSERT INTO Store(StoreName)
VALUES('Shaws');

INSERT INTO Store(StoreName)
VALUES('Target');

INSERT INTO Store(StoreName)
VALUES('Stop & Shop');

INSERT INTO Store(StoreName)
VALUES('Dollar Tree');

INSERT INTO Store(StoreName, StoreLocation)
VALUES('5 Below', '1 Merry Road Boston, MA 02021');

insert into Customer(CustomerFName, CustomerLName, CustomerTop)
Values('John', 'Does', 1003)
--SELECT * FROM Store;


--Select * from Item;
--SELECT * from Store;

INSERT Into StoreInventory(ItemId, StoreId, Quantity)
VALUES(1002, 1000, 4);
INSERT Into StoreInventory(ItemId, StoreId, Quantity)
VALUES(1001, 1000, 2);
INSERT Into StoreInventory(ItemId, StoreId, Quantity)
VALUES(1003, 1000, 40);
INSERT Into StoreInventory(ItemId, StoreId, Quantity)
VALUES(1001, 1001, 10);
INSERT Into StoreInventory(ItemId, StoreId, Quantity)
VALUES(1004, 1001, 4);
INSERT Into StoreInventory(ItemId, StoreId, Quantity)
VALUES(1005, 1001, 6);
INSERT Into StoreInventory(ItemId, StoreId, Quantity)
VALUES(1000, 1001, 5);
INSERT Into StoreInventory(ItemId, StoreId, Quantity)
VALUES(1002, 1002, 3);
INSERT Into StoreInventory(ItemId, StoreId, Quantity)
VALUES(1003, 1002, 1);
INSERT Into StoreInventory(ItemId, StoreId, Quantity)
VALUES(1000, 1003, 8);
INSERT Into StoreInventory(ItemId, StoreId, Quantity)
VALUES(1001, 1004, 10);
INSERT Into StoreInventory(ItemId, StoreId, Quantity)
VALUES(1004, 1004, 9);
INSERT Into StoreInventory(ItemId, StoreId, Quantity)
VALUES(1005, 1004, 5);
INSERT Into StoreInventory(ItemId, StoreId, Quantity)
VALUES(1002, 1005, 4);
INSERT Into StoreInventory(ItemId, StoreId, Quantity)
VALUES(1000, 1005, 47);

--Select * from StoreInventory;


INSERT into Orders(StoreId, CustomerId)
VALUES(1000, 1005);
INSERT into Orders(StoreId, CustomerId)
VALUES(1000, 1002);
INSERT into Orders(StoreId, CustomerId)
VALUES(1000, 1003);
INSERT into Orders(StoreId, CustomerId)
VALUES(1000, 1000);
INSERT into Orders(StoreId, CustomerId)
VALUES(1001, 1001);
INSERT into Orders(StoreId, CustomerId)
VALUES(1001, 1005);
INSERT into Orders(StoreId, CustomerId)
VALUES(1001, 1003);
INSERT into Orders(StoreId, CustomerId)
VALUES(1001, 1000);
INSERT into Orders(StoreId, CustomerId)
VALUES(1002, 1002);
INSERT into Orders(StoreId, CustomerId)
VALUES(1002, 1004);
INSERT into Orders(StoreId, CustomerId)
VALUES(1003, 1001);
INSERT into Orders(StoreId, CustomerId)
VALUES(1003, 1005);
INSERT into Orders(StoreId, CustomerId)
VALUES(1004, 1001);
INSERT into Orders(StoreId, CustomerId)
VALUES(1005, 1000);


INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1000, 1000, 5)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1001, 1000, 1)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1002, 1000, 6)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1003, 1000, 8)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1004, 1000, 7)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1005, 1000, 8)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1006, 1000, 9)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1007, 1000, 10)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1008, 1000, 11)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1009, 1000, 4)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1010, 1000, 3)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1011, 1000, 2)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1012, 1000, 1)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1013, 1000, 5)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1014, 1000, 4)

INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1000, 1003, 5)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1001, 1004, 1)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1002, 1005, 6)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1003, 1006, 8)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1004, 1001, 7)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1005, 1002, 8)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1006, 1003, 9)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1007, 1004, 10)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1008, 1005, 11)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1009, 1006, 4)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1010, 1001, 3)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1011, 1002, 2)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1012, 1003, 1)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1013, 1004, 5)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1014, 1005, 4)


INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1000, 1002, 5)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1001, 1003, 1)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1002, 1004, 6)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1003, 1005, 8)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1004, 1006, 7)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1005, 1001, 8)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1006, 1002, 9)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1007, 1003, 10)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1008, 1004, 11)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1009, 1005, 4)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1010, 1006, 3)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1011, 1001, 2)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1012, 1002, 1)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1013, 1003, 5)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1014, 1004, 4)

INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1000, 1001, 5)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1001, 1002, 1)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1002, 1003, 6)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1003, 1005, 8)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1004, 1006, 7)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1005, 1001, 8)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1006, 1002, 9)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1007, 1003, 10)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1008, 1004, 11)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1009, 1005, 4)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1010, 1006, 3)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1011, 1001, 2)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1012, 1002, 1)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1013, 1003, 5)
INSERT into OrderInventory(OrdersId, ItemId, Quantity)
VALUES(1014, 1004, 4) 

--Select * from OrderInventory;


