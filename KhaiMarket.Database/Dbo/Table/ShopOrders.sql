USE [KhaiMarketV2App]
GO

/****** Object:  Table [dbo].[ShopOrders]    Script Date: 03/07/2024 11:13:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ShopOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AspNetUsersId] [varchar](256) NULL,
	[ShippingAddressId] [int] NULL,
	[PaymentId] [int] NULL,
	[OrderDate] [datetime] NULL,
	[TotalPrice] [money] NULL,
	[OrderStatus] [varchar](20) NULL,
	[ShipmentProviderId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ShopOrders]  WITH CHECK ADD  CONSTRAINT [FK_ShopOrders.Id] FOREIGN KEY([AspNetUsersId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO

ALTER TABLE [dbo].[ShopOrders] CHECK CONSTRAINT [FK_ShopOrders.Id]
GO

ALTER TABLE [dbo].[ShopOrders]  WITH CHECK ADD  CONSTRAINT [FK_ShopOrders.PaymentId] FOREIGN KEY([PaymentId])
REFERENCES [dbo].[Payment] ([Id])
GO

ALTER TABLE [dbo].[ShopOrders] CHECK CONSTRAINT [FK_ShopOrders.PaymentId]
GO

ALTER TABLE [dbo].[ShopOrders]  WITH CHECK ADD  CONSTRAINT [FK_ShopOrders.ShipmentProviderId] FOREIGN KEY([ShipmentProviderId])
REFERENCES [dbo].[ShipmentProvider] ([Id])
GO

ALTER TABLE [dbo].[ShopOrders] CHECK CONSTRAINT [FK_ShopOrders.ShipmentProviderId]
GO

