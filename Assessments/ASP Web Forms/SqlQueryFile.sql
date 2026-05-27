CREATE DATABASE FoodDB;
USE FoodDB;

CREATE TABLE MenuItems (
    MenuId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Price DECIMAL(10,2),
    Category NVARCHAR(50),
    Description NVARCHAR(200)
);

INSERT INTO MenuItems (Name, Price, Category, Description)
VALUES 
('Pizza', 250, 'Fast Food', 'Cheese Pizza'),
('Burger', 150, 'Fast Food', 'Veg Burger'),
('Biryani', 300, 'Main Course', 'Chicken Biryani');

CREATE USER [INFICS\athulv] FOR LOGIN [INFICS\athulv];
ALTER ROLE db_owner ADD MEMBER [INFICS\athulv];

select * from MenuItems