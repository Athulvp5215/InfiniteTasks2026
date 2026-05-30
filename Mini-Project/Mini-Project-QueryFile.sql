
CREATE DATABASE TrainDB;
GO

USE TrainDB;

CREATE TABLE TrainDetails
(
    TrainNo INT PRIMARY KEY,
    Name VARCHAR(50),
    FromStation VARCHAR(50),
    ToStation VARCHAR(50),
    SleeperAvail INT,
    AC2Avail INT,
    AC3Avail INT,
    SleeperCharge DECIMAL(10,2),
    AC2Charge DECIMAL(10,2),
    AC3Charge DECIMAL(10,2),
    TrainTime TIME,
    IsDeleted BIT,
    Status VARCHAR(10) DEFAULT 'Active',
);



-- Booking Details
CREATE TABLE BookingDetails(
    BookingId INT IDENTITY PRIMARY KEY,
    BookDate DATE DEFAULT GETDATE(),
    TravelDate DATE,

    TrainNo INT,
    TravelClass VARCHAR(10),

    Passengers INT CHECK (Passengers <= 3),
    Amount DECIMAL(10,2),

    FOREIGN KEY (TrainNo) REFERENCES TrainDetails(TrainNo)
);

-- Cancellation
CREATE TABLE Cancellation(
    CId INT IDENTITY PRIMARY KEY,
    BookingId INT,

    NoTickets INT DEFAULT 1,

    RefundAmt DECIMAL(10,2),  

    CancelDate DATE DEFAULT GETDATE(),

    FOREIGN KEY (BookingId) REFERENCES BookingDetails(BookingId)
);

CREATE TABLE Users(
    Username VARCHAR(50) PRIMARY KEY,
    Password VARCHAR(50)
);


CREATE TABLE PassengerDetails
(
    PassengerId INT IDENTITY(1,1) PRIMARY KEY,
    BookingId INT,
    PassengerName VARCHAR(100),
    Gender VARCHAR(10),
    Age INT
);



select * from TrainDetails;
select * from BookingDetails;
select * from Cancellation;
select * from Users;
select * from PassengerDetails;



    drop TABLE TrainDetails;
    drop TABLE BookingDetails;
    drop TABLE Cancellation;
SELECT name FROM sys.databases;

USE TrainDB;

CREATE USER [INFICS\athulv] FOR LOGIN [INFICS\athulv];
ALTER ROLE db_owner ADD MEMBER [INFICS\athulv];


SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'TrainDetails';

DELETE FROM TrainDetails WHERE TrainNo = 102;
