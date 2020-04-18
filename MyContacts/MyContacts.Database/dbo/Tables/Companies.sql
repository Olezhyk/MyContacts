CREATE TABLE [dbo].[Companies] (
    [Company_key]   UNIQUEIDENTIFIER NOT NULL,
    [Company_name]  VARCHAR (100)    NOT NULL,
    [Created_by]    UNIQUEIDENTIFIER NULL,
    [Created_date]  DATETIME         NULL,
    [Modified_by]   UNIQUEIDENTIFIER NULL,
    [Modified_date] DATETIME         NULL,
    [Address_key]   UNIQUEIDENTIFIER NOT NULL,
    [Phone]         VARCHAR (25)     NULL,
    [Fax]           VARCHAR (25)     NULL,
    [Email]         VARCHAR (100)    NULL,
    [Web_site]      VARCHAR (100)    NULL,
    PRIMARY KEY CLUSTERED ([Company_key] ASC)
);

