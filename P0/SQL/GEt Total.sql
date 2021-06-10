--create database Shopper

--select * from OrderInventory;

 select Orders.OrdersId, SUM(OrderInventory.Quantity * Item.ItemPrice) AS Total
 from Orders, Item, OrderInventory
 Where OrderInventory.OrdersId = Orders.OrdersId AND OrderInventory.ItemId = Item.ItemId 
 GROUP BY Orders.OrdersId
