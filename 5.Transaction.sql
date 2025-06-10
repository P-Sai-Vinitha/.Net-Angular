CREATE DATABASE TransactionDb
go

use TransactionDb
go

--1.Table Creation
CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName VARCHAR(100),
    OrderDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE OrderItems (
    OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    ProductName VARCHAR(100),
    Quantity INT,
    UnitPrice DECIMAL(10,2)
);

--2. Use Transaction to Insert Data in Both Tables
BEGIN TRY
    BEGIN TRANSACTION;

    -- Insert into Orders table
    INSERT INTO Orders (CustomerName)
    VALUES ('Vinitha');

    -- Get the last inserted OrderID
    DECLARE @OrderID INT = SCOPE_IDENTITY();

    -- Insert items into OrderItems
    INSERT INTO OrderItems (OrderID, ProductName, Quantity, UnitPrice)
    VALUES 
        (@OrderID, 'Keyboard', 2, 850.00),
        (@OrderID, 'Mouse', 1, 450.00),
        (@OrderID, 'Monitor', 1, 6500.00);

    -- Commit the transaction
    COMMIT TRANSACTION;
    PRINT 'Transaction committed successfully.';
END TRY
BEGIN CATCH
    -- Rollback if any error occurs
    ROLLBACK TRANSACTION;

    PRINT 'Transaction failed. Rolled back.';
    PRINT ERROR_MESSAGE();
END CATCH;

--3.Test the Transaction
BEGIN TRY
    BEGIN TRANSACTION;

    INSERT INTO Orders (CustomerName)
    VALUES ('Tom');

    DECLARE @OrderID INT = SCOPE_IDENTITY();

    -- One of the rows will fail due to invalid Quantity
    INSERT INTO OrderItems (OrderID, ProductName, Quantity, UnitPrice)
    VALUES 
        (@OrderID, 'Printer', 1, 5000.00),
        (@OrderID, 'Scanner', 'two', 3000.00);  -- Error here

    COMMIT TRANSACTION;
    PRINT 'Transaction committed successfully.';
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT 'Transaction failed. Rolled back.';
    PRINT ERROR_MESSAGE();
END CATCH;

--4.Check Orders and OrderItems
SELECT * FROM Orders;
SELECT * FROM OrderItems;

