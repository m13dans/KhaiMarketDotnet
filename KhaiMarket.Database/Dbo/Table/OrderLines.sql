USE [KhaiMarketV2App]
GO

/****** Object:  Table [dbo].[OrderLines]    Script Date: 03/07/2024 10:30:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrderLines](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserShoppingCartId] [int] NULL,
	[ShopOrderId] [int] NULL,
	[TotalProuct] [money] NULL,
	[TotalDiscount] [money] NULL,
	[TotalPrice] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OrderLines]  WITH CHECK ADD  CONSTRAINT [FK_OrderLines.ShopOrderId] FOREIGN KEY([ShopOrderId])
REFERENCES [dbo].[ShopOrder] ([Id])
GO

ALTER TABLE [dbo].[OrderLines] CHECK CONSTRAINT [FK_OrderLines.ShopOrderId]
GO

