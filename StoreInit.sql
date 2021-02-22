/*******************************************************************************
	Create Tables
********************************************************************************/
CREATE TABLE [Order]
(
	[OrderId] INT IDENTITY NOT NULL,
	[LocationId] INT NOT NULL,
	[CustomerId] INT NOT NULL,
	[OrderTime] DATETIME2 NOT NULL,
	[OrderLineId] INT NOT NULL,
	CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([OrderId])
);
GO
CREATE TABLE [OrderLine]
(
	[OrderLineId] INT IDENTITY NOT NULL,
	[OrderId] INT NOT NULL,
	[ProductId] INT NOT NULL,
	[Amount] INT NOT NULL,
	CONSTRAINT [PK_OrderLine] PRIMARY KEY CLUSTERED ([OrderLineId])
);
GO
CREATE TABLE [Product]
(
	[ProductId] INT IDENTITY NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[Price] FLOAT NOT NULL,
	CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ProductId])
);
GO
CREATE TABLE [Customer]
(
	[CustomerId] INT IDENTITY NOT NULL,
	[FirstName] NVARCHAR(100) NOT NULL,
	[LastName] NVARCHAR(100) NOT NULL,
	[Balance] FLOAT NOT NULL,
	CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([CustomerId])
);
GO
CREATE TABLE [Location]
(
	[LocationId] INT IDENTITY NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED ([LocationId])
);
GO
CREATE TABLE [Inventory]
(
	[InventoryId] INT IDENTITY NOT NULL,
	[ProductId] INT NOT NULL,
	[LocationId] INT NOT NULL,
	[Amount] INT NOT NULL,
	CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED ([InventoryId])
);

/*******************************************************************************
	Create Foreign Keys
********************************************************************************/
ALTER TABLE [Order] ADD CONSTRAINT [FK_Order_LocationId]
	FOREIGN KEY ([LocationId]) REFERENCES [Location] ([LocationId])
GO
ALTER TABLE [Order] ADD CONSTRAINT [FK_Order_CustomerId]
	FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([CustomerId])
GO
ALTER TABLE [Order] ADD CONSTRAINT [FK_Order_OrderLineId]
	FOREIGN KEY ([OrderLineId]) REFERENCES [OrderLine] ([OrderLineId])
GO
ALTER TABLE [OrderLine] ADD CONSTRAINT [FK_OrderLine_OrderId]
	FOREIGN KEY ([OrderId]) REFERENCES [Order] ([OrderId])
GO
ALTER TABLE [OrderLine] ADD CONSTRAINT [FK_OrderLine_ProductId]
	FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId])
GO
ALTER TABLE [Inventory] ADD CONSTRAINT [FK_Inventory_ProductId]
	FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId])
GO
ALTER TABLE [Inventory] ADD CONSTRAINT [FK_Inventory_LocationId]
	FOREIGN KEY ([LocationId]) REFERENCES [Location] ([LocationId])
GO

/*******************************************************************************
	Populate Initial Values
********************************************************************************/
INSERT INTO Customer([FirstName], [LastName], [Balance]) VALUES('Andrew', 'Park', 10000)
INSERT INTO Customer([FirstName], [LastName], [Balance]) VALUES('David', 'Johnson', 1000)
INSERT INTO Customer([FirstName], [LastName], [Balance]) VALUES('Mike', 'Bike', 900)
INSERT INTO Customer([FirstName], [LastName], [Balance]) VALUES('Jennifer', 'Brown', 500)

INSERT INTO Location([Name]) VALUES('CA1')
INSERT INTO Location([Name]) VALUES('CA2')
INSERT INTO Location([Name]) VALUES('TX1')
INSERT INTO Location([Name]) VALUES('WA1')
INSERT INTO Location([Name]) VALUES('WA2')
INSERT INTO Location([Name]) VALUES('CO1')
INSERT INTO Location([Name]) VALUES('MD1')

INSERT INTO Product([Name], [Price]) VALUES('Pizza', 3.99)
INSERT INTO Product([Name], [Price]) VALUES('Burger', 2.99)
INSERT INTO Product([Name], [Price]) VALUES('Pasta', 6.99)
INSERT INTO Product([Name], [Price]) VALUES('Sushi', 9.99)
INSERT INTO Product([Name], [Price]) VALUES('Curry', 9.99)
INSERT INTO Product([Name], [Price]) VALUES('Orange', 1.99)
INSERT INTO Product([Name], [Price]) VALUES('Smoothie', 4.99)
INSERT INTO Product([Name], [Price]) VALUES('Ramen', 7.99)

DECLARE @Product1 INT = (SELECT ProductId FROM Product WHERE Name = 'Pizza');
DECLARE @Product2 INT = (SELECT ProductId FROM Product WHERE Name = 'Burger');
DECLARE @Product3 INT = (SELECT ProductId FROM Product WHERE Name = 'Pasta');
DECLARE @Product4 INT = (SELECT ProductId FROM Product WHERE Name = 'Sushi');
DECLARE @Product5 INT = (SELECT ProductId FROM Product WHERE Name = 'Curry');
DECLARE @Product6 INT = (SELECT ProductId FROM Product WHERE Name = 'Orange');
DECLARE @Product7 INT = (SELECT ProductId FROM Product WHERE Name = 'Smoothie');

DECLARE @Location1 INT = (SELECT LocationId FROM Location WHERE Name = 'CA1');
DECLARE @Location2 INT = (SELECT LocationId FROM Location WHERE Name = 'CA2');
DECLARE @Location3 INT = (SELECT LocationId FROM Location WHERE Name = 'TX1');
DECLARE @Location4 INT = (SELECT LocationId FROM Location WHERE Name = 'WA1');
DECLARE @Location5 INT = (SELECT LocationId FROM Location WHERE Name = 'WA2');
DECLARE @Location6 INT = (SELECT LocationId FROM Location WHERE Name = 'CO1');
DECLARE @Location7 INT = (SELECT LocationId FROM Location WHERE Name = 'MD1');

INSERT INTO Inventory([ProductId], [LocationId], [Amount]) VALUES(@Product1, @Location1, 100)
INSERT INTO Inventory([ProductId], [LocationId], [Amount]) VALUES(@Product1, @Location2, 100)
INSERT INTO Inventory([ProductId], [LocationId], [Amount]) VALUES(@Product1, @Location3, 100)
INSERT INTO Inventory([ProductId], [LocationId], [Amount]) VALUES(@Product2, @Location3, 100)
INSERT INTO Inventory([ProductId], [LocationId], [Amount]) VALUES(@Product2, @Location4, 100)
INSERT INTO Inventory([ProductId], [LocationId], [Amount]) VALUES(@Product2, @Location5, 100)
INSERT INTO Inventory([ProductId], [LocationId], [Amount]) VALUES(@Product3, @Location3, 100)
INSERT INTO Inventory([ProductId], [LocationId], [Amount]) VALUES(@Product3, @Location4, 100)
INSERT INTO Inventory([ProductId], [LocationId], [Amount]) VALUES(@Product3, @Location5, 100)
INSERT INTO Inventory([ProductId], [LocationId], [Amount]) VALUES(@Product4, @Location4, 100)
INSERT INTO Inventory([ProductId], [LocationId], [Amount]) VALUES(@Product5, @Location5, 100)
INSERT INTO Inventory([ProductId], [LocationId], [Amount]) VALUES(@Product6, @Location6, 100)
INSERT INTO Inventory([ProductId], [LocationId], [Amount]) VALUES(@Product7, @Location7, 100)