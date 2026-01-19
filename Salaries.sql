CREATE TABLE [dbo].[Salaries] (
    [sal_emp_id] INT NOT NULL,
    [sal_m_curr] INT NOT NULL,
    [sal_m_lm]   INT NOT NULL,
    [sal_m_2m]   INT NOT NULL,
    FOREIGN KEY ([sal_emp_id]) REFERENCES [dbo].[Employees] ([emp_id])
);
