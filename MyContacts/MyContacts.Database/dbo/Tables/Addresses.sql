CREATE TABLE [dbo].[Addresses] (
    [Address_key] UNIQUEIDENTIFIER NOT NULL,
    [Address_1]   VARCHAR (100)    NULL,
    [Address_2]   VARCHAR (100)    NULL,
    [City]        VARCHAR (50)     NULL,
    [State]       VARCHAR (30)     NULL,
    [Zip_code]    VARCHAR (10)     NULL,
    [Country]     VARCHAR (50)     NULL,
    PRIMARY KEY CLUSTERED ([Address_key] ASC)
);

