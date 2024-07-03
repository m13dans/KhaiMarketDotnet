USE [KhaiMarketV2App]
GO

/****** Object:  Table [dbo].[UserShoppingCarts]    Script Date: 03/07/2024 11:14:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserShoppingCarts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AspNetUsersId] [varchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserShoppingCarts]  WITH CHECK ADD  CONSTRAINT [FK_UserShoppingCarts_AspNetUsers] FOREIGN KEY([AspNetUsersId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO

ALTER TABLE [dbo].[UserShoppingCarts] CHECK CONSTRAINT [FK_UserShoppingCarts_AspNetUsers]
GO

