CREATE DATABASE TriggerDb
go

use TriggerDb
go

--1.Create Main Table - Employees
CREATE TABLE Employees (
    EmpID INT PRIMARY KEY,
    EmpName VARCHAR(100),
    Department VARCHAR(50),
    Salary DECIMAL(10, 2)
);

--2. Create Audit Table - EmployeeAuditLog
CREATE TABLE EmployeeAuditLog (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    EmpID INT,
    EmpName VARCHAR(100),
    Department VARCHAR(50),
    Salary DECIMAL(10,2),
    ActionType VARCHAR(10),
    ActionDate DATETIME DEFAULT GETDATE()
);

--3.Create INSERT Trigger
CREATE TRIGGER trg_AfterInsert_Employees
ON Employees
AFTER INSERT
AS
BEGIN
    INSERT INTO EmployeeAuditLog (EmpID, EmpName, Department, Salary, ActionType)
    SELECT EmpID, EmpName, Department, Salary, 'INSERT'
    FROM INSERTED;
END;

--4.Create DELETE Trigger
CREATE TRIGGER trg_AfterDelete_Employees
ON Employees
AFTER DELETE
AS
BEGIN
    INSERT INTO EmployeeAuditLog (EmpID, EmpName, Department, Salary, ActionType)
    SELECT EmpID, EmpName, Department, Salary, 'DELETE'
    FROM DELETED;
END;

--5. Test the Triggers
--Insert New Record
INSERT INTO Employees (EmpID, EmpName, Department, Salary)
VALUES 
(1, 'Tom', 'Tech', 50000),
(2, 'Jerry', 'Analyst', 70000);

--Delete a Record
DELETE FROM Employees WHERE EmpID = 1;

--6. Check the Audit Log
SELECT * FROM EmployeeAuditLog;








