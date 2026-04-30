create database assessments;
use assessments;

Create a book table with id as primary key and provide the appropriate data type to other attributes .isbn no should be unique for each book

CREATE TABLE Book (
    Id INT PRIMARY KEY,
    Title VARCHAR(100) NOT NULL,
    Author VARCHAR(100) NOT NULL,
    isbn VARCHAR(20) UNIQUE NOT NULL,
    published_date DATETIME
);

Inserting the values

INSERT INTO Book (id, title, author, isbn, published_date) VALUES
(1, 'My First SQL book', 'Mary Parker', 981483029127, '2012-02-22 12:08:17');

INSERT INTO Book (id, title, author, isbn, published_date) VALUES
(2, 'My Second SQL book', 'John Mayer', 857300923713, '1972-07-03 09:22:45');

INSERT INTO Book (id, title, author, isbn, published_date) VALUES
(3, 'My Third SQL book', 'Cary Flint', 523120967812, '2015-10-18 14:05:44');


1. Write a query to fetch the details of the books written by author whose name ends with er.

Code

SELECT * FROM Book
WHERE Author LIKE '%er';

2. Display the Title ,Author and ReviewerName for all the books from the above table

CREATE TABLE reviews (
    id INT PRIMARY KEY,
    book_id INT,
    reviewer_name VARCHAR(100),
    content VARCHAR(255),
    rating INT,
    published_date DATETIME
);

INSERT INTO reviews (id, book_id, reviewer_name, content, rating, published_date) VALUES
(1, 1, 'John Smith', 'My first review', 4, '2017-12-10 05:50:11');

INSERT INTO reviews (id, book_id, reviewer_name, content, rating, published_date) VALUES
(2, 2, 'John Smith', 'My second review', 5, '2017-10-13 15:05:12');

INSERT INTO reviews (id, book_id, reviewer_name, content, rating, published_date) VALUES
(3, 2, 'Alice Walker', 'Another review', 1, '2017-10-22 23:47:10');


Code

SELECT
    B.Title,
    B.Author,
    R.reviewer_name
FROM Book B
JOIN reviews R
ON B.Id = R.book_id;

3. Display the  reviewer name who reviewed more than one book.

Code

SELECT reviewer_name
FROM reviews
GROUP BY reviewer_name
HAVING COUNT(book_id) > 1;

4. Display the Name for the customer from above customer table  who live in same address which has character o anywhere in address

Creating Customers table

CREATE TABLE Customers (
    ID INT PRIMARY KEY,
    Name VARCHAR(50),
    Age INT,
    Address VARCHAR(100),
    Salary DECIMAL(10,2)
);

Creating Orders table

CREATE TABLE Orders (
    OID INT PRIMARY KEY,
    Date DATETIME,
    Customer_ID INT,
    Amount DECIMAL(10,2)
);

Inserting Customers table

INSERT INTO Customers (ID, Name, Age, Address, Salary) VALUES
(1, 'Ramesh', 32, 'Ahmedabad', 2000.00);

INSERT INTO Customers (ID, Name, Age, Address, Salary) VALUES
(2, 'Khilan', 25, 'Delhi', 1500.00);

INSERT INTO Customers (ID, Name, Age, Address, Salary) VALUES
(3, 'Kaushik', 23, 'Kota', 2000.00);

INSERT INTO Customers (ID, Name, Age, Address, Salary) VALUES
(4, 'Chaitali', 25, 'Mumbai', 6500.00);

INSERT INTO Customers (ID, Name, Age, Address, Salary) VALUES
(5, 'Hardik', 27, 'Bhopal', 8500.00);

INSERT INTO Customers (ID, Name, Age, Address, Salary) VALUES
(6, 'Komal', 22, 'MP', 4500.00);

INSERT INTO Customers (ID, Name, Age, Address, Salary) VALUES
(7, 'Muffy', 24, 'Indore', 10000.00);

Inserting Orders Table

INSERT INTO Orders (OID, Date, Customer_ID, Amount) VALUES
(102, '2009-10-08 00:00:00', 3, 3000);

INSERT INTO Orders (OID, Date, Customer_ID, Amount) VALUES
(100, '2009-10-08 00:00:00', 3, 1500);

INSERT INTO Orders (OID, Date, Customer_ID, Amount) VALUES
(101, '2009-11-20 00:00:00', 2, 1560);

INSERT INTO Orders (OID, Date, Customer_ID, Amount) VALUES
(103, '2008-05-20 00:00:00', 4, 2060);

Code

SELECT Name FROM Customers
WHERE Address LIKE '%o%';

5. Write a query to display the Date,Total no of customer placed order on same Date

Creating Employee table

CREATE TABLE Employee (
    ID INT PRIMARY KEY,
    Name VARCHAR(50),
    Age INT,
    Address VARCHAR(100),
    Salary DECIMAL(10,2)
);

Inserting employee table

INSERT INTO Employee (ID, Name, Age, Address, Salary) VALUES
(1, 'Ramesh', 32, 'Ahmedabad', 2000.00);

INSERT INTO Employee (ID, Name, Age, Address, Salary) VALUES
(2, 'Khilan', 25, 'Delhi', 1500.00);

INSERT INTO Employee (ID, Name, Age, Address, Salary) VALUES
(3, 'Kaushik', 23, 'Kota', 2000.00);

INSERT INTO Employee (ID, Name, Age, Address, Salary) VALUES
(4, 'Chaitali', 25, 'Mumbai', 6500.00);

INSERT INTO Employee (ID, Name, Age, Address, Salary) VALUES
(5, 'Hardik', 27, 'Bhopal', 8500.00);

INSERT INTO Employee (ID, Name, Age, Address, Salary) VALUES
(6, 'Komal', 22, 'MP', NULL);

INSERT INTO Employee (ID, Name, Age, Address, Salary) VALUES
(7, 'Muffy', 24, 'Indore', NULL);

Code

SELECT Date, COUNT(DISTINCT Customer_Id) AS TotalCustomers FROM Orders
GROUP BY Date;

6. Display the Names of the Employee in lower case, whose salary is null

Code

SELECT LOWER(Name) AS EmployeeName FROM Employee
WHERE Salary IS NULL;

7. Write a sql server query to display the Gender,Total no of male and female from the above relation

Creating table studentdetail

CREATE TABLE Studentdetails (
    RegisterNo INT PRIMARY KEY,
    Name VARCHAR(50),
    Age INT,
    Qualification VARCHAR(20),
    MobileNo BIGINT,
    Mail_id VARCHAR(100),
    Location VARCHAR(50),
    Gender CHAR(1)
);

Inserting values 

INSERT INTO Studentdetails (RegisterNo, Name, Age, Qualification, MobileNo, Mail_id, Location, Gender) VALUES
(2, 'Sai', 22, 'B.E', 9952836777, 'Sai@gmail.com', 'Chennai', 'M');

INSERT INTO Studentdetails (RegisterNo, Name, Age, Qualification, MobileNo, Mail_id, Location, Gender) VALUES
(3, 'Kumar', 20, 'BSC', 7890125648, 'Kumar@gmail.com', 'Madurai', 'M');

INSERT INTO Studentdetails (RegisterNo, Name, Age, Qualification, MobileNo, Mail_id, Location, Gender) VALUES
(4, 'Selvi', 22, 'B.Tech', 8904567342, 'selvi@gmail.com', 'Selam', 'F');

INSERT INTO Studentdetails (RegisterNo, Name, Age, Qualification, MobileNo, Mail_id, Location, Gender) VALUES
(5, 'Nisha', 25, 'M.E', 7834672310, 'Nisha@gmail.com', 'Theni', 'F');

INSERT INTO Studentdetails (RegisterNo, Name, Age, Qualification, MobileNo, Mail_id, Location, Gender) VALUES
(6, 'SaiSaran', 21, 'B.A', 7890345678, 'saran@gmail.com', 'Madurai', 'F');

INSERT INTO Studentdetails (RegisterNo, Name, Age, Qualification, MobileNo, Mail_id, Location, Gender) VALUES
(7, 'Tom', 23, 'BCA', 8901234675, 'Tom@gmail.com', 'Pune', 'M');

Code

SELECT
    Gender,
    COUNT(*) AS TotalCount
FROM Studentdetails
GROUP BY Gender;