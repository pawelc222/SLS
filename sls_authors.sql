USE [SLS]
GO

/****** Object:  Table [dbo].[authors]    Script Date: 2014-10-23 15:18:13 ******/
DROP TABLE [dbo].[authors]
GO

/****** Object:  Table [dbo].[authors]    Script Date: 2014-10-23 15:18:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[authors](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstname] [nvarchar](50) NOT NULL,
	[surname] [nvarchar](50) NOT NULL,
	[date_of_birth] [date] NULL,
	[date_of_death] [date] NULL,
	[description] [ntext] NULL,
 CONSTRAINT [PK_authors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

