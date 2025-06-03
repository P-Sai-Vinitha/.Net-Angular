use AutoAccessDB
go

--1. Customer list by First Name in Descending Order
SELECT * 
FROM Customers 
ORDER BY first_name DESC;

--2. First Name, Last Name, and City sorted by City then First Name
SELECT first_name, last_name, City 
FROM Customers 
ORDER BY City, first_name;

--3. Top Three Most Expensive Products
SELECT TOP 3 * 
FROM Products 
ORDER BY list_price DESC;

--4. Products with List Price > 300 and Model Year = 2018
SELECT * 
FROM Products 
WHERE list_price > 300 AND model_year = 2018;

--5. Products with List Price > 3000 OR Model Year = 2018
SELECT * 
FROM Products 
WHERE list_price > 3000 OR model_year = 2018;

--6. Products with List Price BETWEEN 1899 and 1999.99
SELECT * 
FROM Products 
WHERE list_price BETWEEN 1899 AND 1999.99;

--7. Products with List Price IN (299.99, 466.99, 489.99)
SELECT * 
FROM Products 
WHERE list_price IN (299.99, 466.99, 489.99);

--8. Customers where Last Name starts with A to C
SELECT * 
FROM Customers 
WHERE LEFT(last_name, 1) BETWEEN 'A' AND 'C';

--9. Customers where First Name does NOT start with A
SELECT * 
FROM Customers 
WHERE first_name NOT LIKE 'A%';

--10. Number of Customers grouped by State and City
SELECT State, city, COUNT(*) AS CustomerCount 
FROM customers 
GROUP BY State, city;

--11. Number of Orders by Customer ID and Year
SELECT customer_id, YEAR(order_date) AS OrderYear, COUNT(*) AS OrderCount 
FROM orders 
GROUP BY customer_id, YEAR(order_date);

--12. Max & Min List Price by Category, filtered
SELECT category_id, 
       MAX(list_price) AS MaxPrice, 
       MIN(list_price) AS MinPrice 
FROM products 
GROUP BY category_id 
HAVING MAX(list_price) > 4000 OR MIN(list_price) < 500;
