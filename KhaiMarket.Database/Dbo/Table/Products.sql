USE [KhaiMarketV2App]
GO

/****** Object:  Table [dbo].[Products]    Script Date: 03/07/2024 10:17:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](256) NULL,
	[Description] [varchar](500) NULL,
	[ProductStock] [int] NULL,
	[Price] [money] NULL,
	[ImageUrl] [varchar](256) NULL,
	[DiscountPrice] [money] NULL,
	[CategoryId] [int] NULL,
	[BrandId] [int] NULL,
	[SKU] [varchar](256) NULL,
	[CreatedAt] [datetime] NULL,
	[LastModifieAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products.BrandId] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([Id])
GO

ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products.BrandId]
GO

