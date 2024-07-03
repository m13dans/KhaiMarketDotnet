CREATE TABLE [dbo].[Products] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Name]          VARCHAR (256) NULL,
    [Description]   VARCHAR (500) NULL,
    [ProductStock]  INT           NULL,
    [Price]         MONEY         NULL,
    [ImageUrl]      VARCHAR (256) NULL,
    [DiscountPrice] MONEY         NULL,
    [CategoryId]    INT           NULL,
    [BrandId]       INT           NULL,
    [SKU]           VARCHAR (256) NULL,
    [CreatedAt]     DATETIME      NULL,
    [LastModifieAt] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Products.BrandId] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([Id])
);


GO

