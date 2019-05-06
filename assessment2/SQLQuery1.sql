Create Table Products (
ID Int Not Null Identity,
Name NVarchar(30) Not Null,
Price Decimal(5,2) Not Null,
Constraint PK_Products Primary Key(ID)
);

Create Table Customers (
ID Int Not Null Identity,
Firstname NVarchar(30) Not Null,
Lastname Nvarchar(30) Not Null,
Cardnumber Varchar(19) Not Null,
Constraint CK_Customers Check (Len(Cardnumber) > 15),
Constraint PK_Customers Primary Key(ID)
)


Create Table Orders (
ID Int Not Null Identity,
ProductID Int Not Null,
CustomerID Int Not Null,
Constraint PK_Orders Primary Key(ID),
Constraint FK_Orders1 Foreign Key(ProductID)
	References Products (ID)
	On Delete Cascade,
Constraint FK_Orders2 Foreign Key(CustomerID)
	References Customers (ID)
	On Delete Cascade
);



Insert Into Customers (Firstname, Lastname, Cardnumber) Values
('Tina', 'Smith', 1212333444556666),
('Rufio', 'Murfreesboro', 3939393939393939),
('Walter', 'Sobchak', 99999999999999999)

Insert Into Products (Name, Price) Values 
('IPhone', 200.00),
('A Human Soul', 199.99),
('The Mystery Box', 999.99),
('Gun', 6.99)

Insert INto Orders (CustomerID, ProductID) Values
	((Select ID From Customers Where Firstname = 'Tina' and Lastname = 'Smith'),
	(Select ID From Products Where Name = 'IPhone')),
	((Select ID From Customers Where Firstname = 'Walter' and Lastname = 'Sobchak'),
	(Select ID From Products Where Name = 'Gun')),
	((Select ID From Customers Where Firstname = 'Tina' and Lastname = 'Smith'),
	(Select ID From Products Where Name = 'A Human Soul')),
	((Select ID From Customers Where Firstname = 'Rufio' and Lastname = 'Murfreesboro'),
	(Select ID From Products Where Name = 'IPhone'));

Select * From Orders Inner Join Customers on Orders.CustomerID = Customers.ID Where (Firstname = 'Tina' AND LastName = 'Smith');

Select Sum(Products.Price) as 'Total Revenue' From Orders Inner Join Products on Orders.ProductID = Products.ID Where (Name = 'IPhone');


Update Products 
Set Price = 250.00
Where Name = 'Iphone';