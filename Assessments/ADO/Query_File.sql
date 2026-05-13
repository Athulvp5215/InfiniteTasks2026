1.Question

CREATE DATABASE Employeemanagement;
GO

USE Employeemanagement;

CREATE TABLE Employee_Details (
    Empno INT PRIMARY KEY,
    EmpName VARCHAR(50) NOT NULL,
    Empsal NUMERIC(10,2) CHECK (Empsal >= 25000),
    Emptype CHAR(1) CHECK (Emptype IN ('F','P'))
);

CREATE PROCEDURE sp_AddEmployee
    @EmpName VARCHAR(50),
    @Empsal NUMERIC(10,2),
    @Emptype CHAR(1)
AS
BEGIN
    DECLARE @NewEmpNo INT;

    SELECT @NewEmpNo = ISNULL(MAX(Empno), 0) + 1 FROM Employee_Details;

    INSERT INTO Employee_Details (Empno, EmpName, Empsal, Emptype)
    VALUES (@NewEmpNo, @EmpName, @Empsal, @Emptype);
END;

select * from Employee_Details;

2.Question

CREATE PROCEDURE sp_UpdateSalary
    @Empno INT,
    @UpdatedSalary NUMERIC(10,2) OUTPUT
AS
BEGIN
    UPDATE Employee_Details
    SET Empsal = Empsal + 100
    WHERE Empno = @Empno;

    -- Return updated salary
    SELECT @UpdatedSalary = Empsal
    FROM Employee_Details
    WHERE Empno = @Empno;
END;

select * from Employee_Details;

