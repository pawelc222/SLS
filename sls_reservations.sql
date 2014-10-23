USE [SLS]
GO

/****** Object:  Table [dbo].[reservations]    Script Date: 2014-10-23 15:19:03 ******/
DROP TABLE [dbo].[reservations]
GO

/****** Object:  Table [dbo].[reservations]    Script Date: 2014-10-23 15:19:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[reservations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[book_id_fk] [int] NOT NULL,
	[user_id_fk] [int] NOT NULL,
	[reservation_date] [datetime] NOT NULL,
	[queue_position] [int] NULL,
 CONSTRAINT [PK_reservations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

