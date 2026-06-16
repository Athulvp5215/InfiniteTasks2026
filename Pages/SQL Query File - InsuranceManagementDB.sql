CREATE DATABASE InsuranceManagementDB;
 
 
USE InsuranceManagementDB;
 
 
--------------------------------------------------

-- USERS

--------------------------------------------------
 
CREATE TABLE Users

(

    UserId INT PRIMARY KEY IDENTITY(1,1),
 
    FullName NVARCHAR(100) NOT NULL,
 
    Email NVARCHAR(100) UNIQUE NOT NULL,
 
    Password NVARCHAR(100) NOT NULL,
 
    PhoneNumber NVARCHAR(15),
 
    Role NVARCHAR(20) DEFAULT 'Customer',
 
    Address NVARCHAR(250),
 
    CreatedDate DATETIME DEFAULT GETDATE(),
 
    Status NVARCHAR(20) DEFAULT 'Pending'

);
 
--------------------------------------------------

-- INSURANCE PLANS

--------------------------------------------------
 
CREATE TABLE InsurancePlans

(

    PlanId INT PRIMARY KEY IDENTITY(1,1),
 
    PlanName NVARCHAR(100) NOT NULL,
 
    BasePremium DECIMAL(10,2) NOT NULL,
 
    Description NVARCHAR(500)

);
 
--------------------------------------------------

-- VEHICLES

--------------------------------------------------
 
CREATE TABLE Vehicles

(

    VehicleId INT PRIMARY KEY IDENTITY(1,1),
 
    UserId INT NOT NULL,
 
    VehicleNumber NVARCHAR(50) UNIQUE NOT NULL,
 
    VehicleType NVARCHAR(20) NOT NULL,
 
    VehicleModel NVARCHAR(100),
 
    Manufacturer NVARCHAR(100),
 
    ManufactureYear INT,
 
    EngineNumber NVARCHAR(100) UNIQUE,
 
    ChassisNumber NVARCHAR(100) UNIQUE,
 
    FOREIGN KEY(UserId)

    REFERENCES Users(UserId)

);
 
--------------------------------------------------

-- POLICIES

--------------------------------------------------
 
CREATE TABLE Policies

(

    PolicyId INT PRIMARY KEY IDENTITY(1,1),
 
    PolicyNumber NVARCHAR(50) UNIQUE NOT NULL,
 
    UserId INT NOT NULL,
 
    PlanId INT NOT NULL,
 
    VehicleId INT NULL,
 
    PremiumAmount DECIMAL(10,2) NOT NULL,
 
    StartDate DATE,
 
    EndDate DATE,
 
    PolicyStatus NVARCHAR(20) DEFAULT 'Pending',
 
    PolicyType NVARCHAR(50),
 
    FOREIGN KEY(UserId)

    REFERENCES Users(UserId),
 
    FOREIGN KEY(PlanId)

    REFERENCES InsurancePlans(PlanId),
 
    FOREIGN KEY(VehicleId)

    REFERENCES Vehicles(VehicleId)

);
 
--------------------------------------------------

-- PAYMENTS

--------------------------------------------------
 
CREATE TABLE Payments

(

    PaymentId INT PRIMARY KEY IDENTITY(1,1),
 
    PolicyId INT NOT NULL,
 
    Amount DECIMAL(10,2) NOT NULL,
 
    PaymentStatus NVARCHAR(20) DEFAULT 'Success',
 
    PaymentDate DATETIME DEFAULT GETDATE(),
 
    FOREIGN KEY(PolicyId)

    REFERENCES Policies(PolicyId)

);
 
--------------------------------------------------

-- CLAIMS

--------------------------------------------------
 
CREATE TABLE Claims

(

    ClaimId INT PRIMARY KEY IDENTITY(1,1),
 
    PolicyId INT NOT NULL,
 
    ClaimAmount DECIMAL(10,2) NOT NULL,
 
    ClaimReason NVARCHAR(500),
 
    ClaimStatus NVARCHAR(20) DEFAULT 'Pending',
 
    ClaimDate DATETIME DEFAULT GETDATE(),
 
    ApprovedAmount DECIMAL(10,2) NULL,
 
    ApprovedBy INT NULL,
 
    Remarks NVARCHAR(500),
 
    FOREIGN KEY(PolicyId)

    REFERENCES Policies(PolicyId)

);
 
--------------------------------------------------

-- RENEWALS

--------------------------------------------------
 
CREATE TABLE Renewals

(

    RenewalId INT PRIMARY KEY IDENTITY(1,1),
 
    PolicyId INT NOT NULL,
 
    RenewalDate DATETIME DEFAULT GETDATE(),
 
    NewEndDate DATE NOT NULL,
 
    RenewalAmount DECIMAL(10,2) NOT NULL,
 
    FOREIGN KEY(PolicyId)

    REFERENCES Policies(PolicyId)

);


CREATE TABLE Admin

(

    AdminId INT PRIMARY KEY IDENTITY(1,1),
 
    AdminName NVARCHAR(100) NOT NULL,
 
    Email NVARCHAR(100) UNIQUE NOT NULL,
 
    Password NVARCHAR(100) NOT NULL

);

INSERT INTO Admin
(
    AdminName,
    Email,
    Password
)
VALUES
(
    'System Administrator',
    'admin@gmail.com',
    'Admin@123'
);


select * from Users
select * from Admin
SELECT * FROM InsurancePlans

INSERT INTO InsurancePlans (PlanName, BasePremium)
VALUES 
('Basic Plan', 5000),
('Standard Plan', 8000),
('Premium Plan', 12000);


CREATE USER [INFICS\athulv] FOR LOGIN [INFICS\athulv];
ALTER ROLE db_owner ADD MEMBER [INFICS\athulv];
