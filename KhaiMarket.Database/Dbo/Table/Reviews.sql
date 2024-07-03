USE [KhaiMarketV2App]
GO

/****** Object:  Table [dbo].[Reviews]    Script Date: 03/07/2024 11:10:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Reviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [varchar](500) NULL,
	[NumStars] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[AspNetUsersId] [varchar](256) NULL,
	[UserName] [varchar](256) NULL,
	[ProductId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews.AspNetUsersId] FOREIGN KEY([AspNetUsersId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO

ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews.AspNetUsersId]
GO

