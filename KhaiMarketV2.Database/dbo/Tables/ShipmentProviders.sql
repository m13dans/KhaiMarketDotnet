CREATE TABLE [dbo].[ShipmentProviders] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Name]          VARCHAR (256) NULL,
    [ShipmentPrice] MONEY         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO

