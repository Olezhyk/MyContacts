CREATE TABLE [dbo].[Contacts] (
    [Contact_key]   UNIQUEIDENTIFIER NOT NULL,
    [User_key]      UNIQUEIDENTIFIER NOT NULL,
    [Created_by]    UNIQUEIDENTIFIER NULL,
    [Mreated_date]  DATETIME         NULL,
    [Modified_by]   UNIQUEIDENTIFIER NULL,
    [Modified_date] DATETIME         NULL,
    [Company_key]   UNIQUEIDENTIFIER NULL,
    [Full_name]     VARCHAR (100)    NULL,
    [First_name]    VARCHAR (50)     NULL,
    [Last_name]     VARCHAR (50)     NULL,
    [Title]         VARCHAR (100)    NULL,
    [Address_key]   UNIQUEIDENTIFIER NULL,
    [Phone]         VARCHAR (25)     NULL,
    [Fax]           VARCHAR (25)     NULL,
    [Mobile]        VARCHAR (25)     NULL,
    [Home]          VARCHAR (25)     NULL,
    [Email]         VARCHAR (100)    NULL,
    [Web_site]      VARCHAR (100)    NULL,
    PRIMARY KEY CLUSTERED ([Contact_key] ASC)
);

