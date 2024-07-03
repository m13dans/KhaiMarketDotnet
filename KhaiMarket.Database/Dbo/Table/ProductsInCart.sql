USE [KhaiMarketV2App]
GO

/****** Object:  Table [dbo].[ProuductsInCart]    Script Date: 03/07/2024 10:35:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductsInCart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[UserShoppingCartId] [int] NULL,
	[ProductQty] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProuductsInCart]  WITH CHECK ADD  CONSTRAINT [FK_ProuductsInCart.ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO

ALTER TABLE [dbo].[ProuductsInCart] CHECK CONSTRAINT [FK_ProuductsInCart.ProductId]
GO

ALTER TABLE [dbo].[ProuductsInCart]  WITH CHECK ADD  CONSTRAINT [FK_ProuductsInCart_UserShoppingCart] FOREIGN KEY([ProductId])
REFERENCES [dbo].[UserShoppingCart] ([Id])
GO

ALTER TABLE [dbo].[ProuductsInCart] CHECK CONSTRAINT [FK_ProuductsInCart_UserShoppingCart]
GO

