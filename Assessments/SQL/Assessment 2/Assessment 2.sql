1.	Write a query to display your birthday( day of week)

Code:
use database assignment2;
select datename(weekday, cast('2005-01-05' as date)) as birthday_day;

2.	Write a query to display your age in days

Code:
select datediff(day, cast('2005-01-05' as date), getdate()) as age_in_days;

3.	Write a query to display all employees information those who joined before 5 years in the current month
(Hint : If required update some HireDates in your EMP table of the assignment)

Code:
SELECT empno, ename, doj
FROM Employee
WHERE doj < DATEADD(YEAR, -5, GETDATE())
  AND MONTH(doj) = MONTH(GETDATE());

4.	Create table Employee with empno, ename, sal, doj columns or use your emp table and perform the following operations in a single transaction
	a. First insert 3 rows 
	b. Update the second row sal with 15% increment  
    c. Delete first row.

Code:
a. 
CREATE TABLE Employee (
    empno INT PRIMARY KEY,
    ename VARCHAR(50),
    sal INT,
    doj DATE
);
BEGIN TRANSACTION;
INSERT INTO Employee (empno, ename, sal, doj)
VALUES
(1, 'Athul', 100000, CAST('2025-01-05' AS DATE)),
(2, 'Rocky', 12000, CAST('2024-04-03' AS DATE)),
(3, 'Nithin', 15000, CAST('2018-05-20' AS DATE));

b. 
UPDATE Employee
SET sal = sal * 1.15
WHERE empno = 2;
SAVE TRANSACTION AfterUpdate;
c.
DELETE FROM Employee
WHERE empno = 1;
ROLLBACK TRANSACTION AfterUpdate;
COMMIT;

5.      Create a user defined function calculate Bonus for all employees of a  given dept using following conditions
	a.     For Deptno 10 employees 15% of sal as bonus.
	b.     For Deptno 20 employees  20% of sal as bonus
	c      For Others employees 5%of sal as bonus

Code:
CREATE FUNCTION calculate_bonus
(
    @deptno INT,
    @sal INT
)
RETURNS INT
AS
BEGIN
    DECLARE @bonus INT;

    IF @deptno = 10
        SET @bonus = @sal * 0.15;
    ELSE IF @deptno = 20
        SET @bonus = @sal * 0.20;
    ELSE
        SET @bonus = @sal * 0.05;

    RETURN @bonus;
END;
GO

SELECT empno,
       ename,
       sal,
       dbo.calculate_bonus(sal) AS bonus
FROM Employee;

6. Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)

Code:
CREATE PROCEDURE update_sales_salary
AS
BEGIN
    UPDATE Employee
    SET sal = sal + 500
    WHERE sal < 1500;
END;
GO

EXEC update_sales_salary;
