CREATE TABLE [dbo].[Users] (
    [User_key]  UNIQUEIDENTIFIER NOT NULL,
    [User_name] VARCHAR (50)     NOT NULL,
    PRIMARY KEY CLUSTERED ([User_key] ASC)
);

