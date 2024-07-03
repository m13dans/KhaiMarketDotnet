CREATE TABLE [dbo].[ShopOrders] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [AspNetUsersId]      VARCHAR (256) NULL,
    [ShippingAddressId]  INT           NULL,
    [PaymentId]          INT           NULL,
    [OrderDate]          DATETIME      NULL,
    [TotalPrice]         MONEY         NULL,
    [OrderStatus]        VARCHAR (20)  NULL,
    [ShipmentProviderId] INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ShopOrders.Id] FOREIGN KEY ([AspNetUsersId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_ShopOrders.PaymentId] FOREIGN KEY ([PaymentId]) REFERENCES [dbo].[Payments] ([Id]),
    CONSTRAINT [FK_ShopOrders.ShipmentProviderId] FOREIGN KEY ([ShipmentProviderId]) REFERENCES [dbo].[ShipmentProviders] ([Id])
);


GO

