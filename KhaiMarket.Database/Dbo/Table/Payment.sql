USE [KhaiMarketV2App]
GO

/****** Object:  Table [dbo].[Payment]    Script Date: 03/07/2024 10:32:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Payments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentMethod] [varchar](20) NULL,
	[PaymentDate] [datetime] NULL,
	[AspNetUsersId] [varchar](256) NULL,
	[Email] [varchar](256) NULL,
	[TotalPayment] [money] NULL,
	[Status] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment.AspNetUsersId] FOREIGN KEY([AspNetUsersId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO

ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment.AspNetUsersId]
GO

