USE [KhaiMarketV2App]
GO

/****** Object:  Table [dbo].[Addresses]    Script Date: 03/07/2024 11:22:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Addresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AddressesDetail] [varchar](256) NOT NULL,
	[District] [varchar](100) NOT NULL,
	[City] [varchar](100) NOT NULL,
	[Province] [varchar](100) NOT NULL,
	[ZipCode] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

