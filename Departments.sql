CREATE TABLE [dbo].[Departments] (
    [dep_id]   INT           IDENTITY (1, 1) NOT NULL,
    [dep_name] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([dep_id] ASC),
    UNIQUE NONCLUSTERED ([dep_name] ASC)
);
