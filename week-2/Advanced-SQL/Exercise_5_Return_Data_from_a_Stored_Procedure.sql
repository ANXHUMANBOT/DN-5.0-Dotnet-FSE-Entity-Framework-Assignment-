-- --- CREATING THE STORED PROCEDURE WITH OUTPUT PARAMETER ---
CREATE PROCEDURE GetDepartmentMetrics
    @DeptName VARCHAR(50),
    @TotalSalaryBudget DECIMAL(10,2) OUTPUT, -- Output Parameter 1
    @EmployeeCount INT OUTPUT                 -- Output Parameter 2
AS
BEGIN
    SET NOCOUNT ON;

    -- Calculate metrics and assign directly to the output variables
    SELECT 
        @TotalSalaryBudget = ISNULL(SUM(Salary), 0),
        @EmployeeCount = COUNT(*)
    FROM Employees
    WHERE Department = @DeptName;
END;
GO

-- --- HOW TO TEST AND RETURN THE DATA ---
DECLARE @BudgetOut DECIMAL(10,2);
DECLARE @CountOut INT;

-- Execute and catch the output values inside local variables
EXEC GetDepartmentMetrics 
    @DeptName = 'Finance', 
    @TotalSalaryBudget = @BudgetOut OUTPUT, 
    @EmployeeCount = @CountOut OUTPUT;

-- Print the captured results
SELECT 
    'Finance' AS DepartmentName,
    @BudgetOut AS TotalAllocatedBudget,
    @CountOut AS TotalActiveResources;
GO