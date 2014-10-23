USE [SLS]
GO

/****** Object:  Table [dbo].[books]    Script Date: 2014-10-23 15:18:23 ******/
DROP TABLE [dbo].[books]
GO

/****** Object:  Table [dbo].[books]    Script Date: 2014-10-23 15:18:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[books](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[publisher_id] [int] NULL,
	[publish_date] [date] NULL,
	[publish_city] [nvarchar](50) NULL,
	[publish_edition] [int] NULL,
	[title] [nvarchar](50) NOT NULL,
	[isbn] [nchar](20) NOT NULL,
	[cover] [varchar](255) NULL,
	[table_of_contents] [ntext] NULL,
	[language] [nvarchar](50) NULL,
	[description] [ntext] NULL,
	[available_copies] [int] NOT NULL,
 CONSTRAINT [PK_books] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

