CREATE TABLE [dbo].[ProductsInCart] (
    [Id]                 INT IDENTITY (1, 1) NOT NULL,
    [ProductId]          INT NULL,
    [UserShoppingCartId] INT NULL,
    [ProductQty]         INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProductsInCart_UserShoppingCarts] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[UserShoppingCarts] ([Id]),
    CONSTRAINT [FK_ProductsInCart.ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id])
);


GO

