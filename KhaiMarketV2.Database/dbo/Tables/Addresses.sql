CREATE TABLE [dbo].[Addresses] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [AddressesDetail] VARCHAR (256) NOT NULL,
    [District]        VARCHAR (100) NOT NULL,
    [City]            VARCHAR (100) NOT NULL,
    [Province]        VARCHAR (100) NOT NULL,
    [ZipCode]         VARCHAR (10)  NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO

