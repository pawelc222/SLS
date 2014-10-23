USE [SLS]
GO

/****** Object:  Table [dbo].[borrows]    Script Date: 2014-10-23 15:18:31 ******/
DROP TABLE [dbo].[borrows]
GO

/****** Object:  Table [dbo].[borrows]    Script Date: 2014-10-23 15:18:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[borrows](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[book_id_fk] [int] NOT NULL,
	[user_id_fk] [int] NOT NULL,
	[from_date] [datetime] NOT NULL,
	[to_date] [datetime] NOT NULL,
	[prolong_cnt] [int] NOT NULL,
 CONSTRAINT [PK_borrows] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

