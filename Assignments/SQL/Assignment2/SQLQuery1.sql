CREATE DATABASE Assignment2;
USE Assignment2;

--------------------------------------------------
-- Create Department table
--------------------------------------------------
CREATE TABLE Dept (
    deptno INT PRIMARY KEY,
    dname  VARCHAR(20),
    loc    VARCHAR(20)
);

--------------------------------------------------
-- Create Employee table
--------------------------------------------------
CREATE TABLE Emp (
    empno     INT PRIMARY KEY,
    ename     VARCHAR(20),
    job       VARCHAR(20),
    [mgr-id]  INT,
    hiredate  DATE,
    sal       INT,
    [comm.]   INT,
    deptno    INT,

    FOREIGN KEY (deptno)
        REFERENCES Dept(deptno)
);

--------------------------------------------------
-- Insert data into Dept table
--------------------------------------------------
INSERT INTO Dept (deptno, dname, loc)
VALUES
(10, 'Accounting', 'New York'),
(20, 'Research',   'Dallas'),
(30, 'Sales',      'Chicago'),
(40, 'Operations', 'Boston');

--------------------------------------------------
-- Insert data into Emp table
--------------------------------------------------
INSERT INTO Emp
(empno, ename, job, [mgr-id], hiredate, sal, [comm.], deptno)
VALUES
(7369, 'Smith',  'Clerk',     7902, CONVERT(DATE,'17-12-1980',105),  800,  NULL, 20),
(7499, 'Allen',  'Salesman',  7698, CONVERT(DATE,'20-02-1981',105), 1600,   300, 30),
(7521, 'Ward',   'Salesman',  7698, CONVERT(DATE,'22-02-1981',105), 1250,   500, 30),
(7566, 'Jones',  'Manager',   7839, CONVERT(DATE,'02-04-1981',105), 2975,  NULL, 20),
(7654, 'Martin', 'Salesman',  7698, CONVERT(DATE,'28-09-1981',105), 1250,  1400, 30),
(7698, 'Blake',  'Manager',   7839, CONVERT(DATE,'01-05-1981',105), 2850,  NULL, 30),
(7782, 'Clark',  'Manager',   7839, CONVERT(DATE,'09-06-1981',105), 2450,  NULL, 10),
(7788, 'Scott',  'Analyst',   7566, CONVERT(DATE,'19-04-1987',105), 3000,  NULL, 20),
(7839, 'King',   'President', NULL, CONVERT(DATE,'17-11-1981',105), 5000,  NULL, 10),
(7844, 'Turner', 'Salesman',  7698, CONVERT(DATE,'08-09-1981',105), 1500,     0, 30),
(7876, 'Adams',  'Clerk',     7788, CONVERT(DATE,'23-05-1987',105), 1100,  NULL, 20),
(7900, 'James',  'Clerk',     7698, CONVERT(DATE,'03-12-1981',105),  950,  NULL, 30),
(7902, 'Ford',   'Analyst',   7566, CONVERT(DATE,'03-12-1981',105), 3000,  NULL, 20),
(7934, 'Miller', 'Clerk',     7782, CONVERT(DATE,'23-01-1982',105), 1300,  NULL, 10);

--------------------------------------------------
-- Queries
--------------------------------------------------

-- 1. List all employees whose name begins with 'A'
SELECT *
FROM Emp
WHERE ename LIKE 'A%';

-- 2. Select employees who don't have a manager
SELECT *
FROM Emp
WHERE [mgr-id] IS NULL;

-- 3. Employees earning between 1200 and 1400
SELECT ename, empno, sal
FROM Emp
WHERE sal BETWEEN 1200 AND 1400;

-- 4. Give Research department employees a 10% salary hike
-- Before update
SELECT e.*
FROM Emp e
JOIN Dept d ON e.deptno = d.deptno
WHERE d.dname = 'Research';

-- After update
UPDATE Emp
SET sal = sal * 1.10
WHERE deptno = (
    SELECT deptno
    FROM Dept
    WHERE dname = 'Research'
);

-- 5. Number of Clerks
SELECT COUNT(*) AS Number_of_Clerks
FROM Emp
WHERE job = 'Clerk';

-- 6. Average salary and employee count per job
SELECT
    job,
    AVG(sal)   AS Average_Salary,
    COUNT(*)  AS Employee_Count
FROM Emp
GROUP BY job;

-- 7. Employees with lowest and highest salary
SELECT *
FROM Emp
WHERE sal = (SELECT MIN(sal) FROM Emp)
   OR sal = (SELECT MAX(sal) FROM Emp);

-- 8. Departments without employees
SELECT d.*
FROM Dept d
LEFT JOIN Emp e ON d.deptno = e.deptno
WHERE e.empno IS NULL;

-- 9. Analysts earning more than 1200 in department 20
SELECT ename, sal
FROM Emp
WHERE job = 'Analyst'
  AND sal > 1200
  AND deptno = 20
ORDER BY ename ASC;

-- 10. Total salary per department
SELECT
    d.deptno,
    d.dname,
    SUM(e.sal) AS Total_Salary
FROM Dept d
LEFT JOIN Emp e ON d.deptno = e.deptno
GROUP BY d.deptno, d.dname;

-- 11. Salary of Miller and Smith
SELECT ename, sal
FROM Emp
WHERE ename IN ('Miller', 'Smith');

-- 12. Employees whose names start with A or M
SELECT ename
FROM Emp
WHERE ename LIKE 'A%'
   OR ename LIKE 'M%';

-- 13. Yearly salary of Smith
SELECT ename, sal * 12 AS Yearly_Salary
FROM Emp
WHERE ename = 'Smith';

-- 14. Employees not earning between 1500 and 2850
SELECT ename, sal
FROM Emp
WHERE sal NOT BETWEEN 1500 AND 2850;

-- 15. Managers with more than 2 reportees
SELECT
    m.empno,
    m.ename,
    COUNT(e.empno) AS Number_of_Reportees
FROM Emp m
JOIN Emp e ON m.empno = e.[mgr-id]
GROUP BY m.empno, m.ename
HAVING COUNT(e.empno) > 2;