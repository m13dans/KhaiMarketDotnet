CREATE TABLE [dbo].[OrderLines] (
    [Id]                 INT   IDENTITY (1, 1) NOT NULL,
    [UserShoppingCartId] INT   NULL,
    [ShopOrderId]        INT   NULL,
    [TotalProuct]        MONEY NULL,
    [TotalDiscount]      MONEY NULL,
    [TotalPrice]         INT   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderLines.ShopOrderId] FOREIGN KEY ([ShopOrderId]) REFERENCES [dbo].[ShopOrders] ([Id])
);


GO

