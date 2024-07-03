CREATE TABLE [dbo].[ProductsCategories] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [ProductId]  INT NULL,
    [CategoryId] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProductsCategories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id]),
    CONSTRAINT [FK_ProductsCategories_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id])
);


GO

