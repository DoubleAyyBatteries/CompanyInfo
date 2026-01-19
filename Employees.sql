CREATE TABLE [dbo].[Employees] (
    [emp_id]         INT           IDENTITY (1, 1) NOT NULL,
    [emp_first_name] VARCHAR (255) NOT NULL,
    [emp_last_name]  VARCHAR (255) NOT NULL,
    [emp_dep_id]     INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([emp_id] ASC),
    FOREIGN KEY ([emp_dep_id]) REFERENCES [dbo].[Departments] ([dep_id])
);
