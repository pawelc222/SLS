USE [SLS]
GO
/****** Object:  Table [dbo].[authors]    Script Date: 2014-10-26 20:03:24 ******/
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
/****** Object:  Table [dbo].[book_authors]    Script Date: 2014-10-26 20:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[book_authors](
	[book_id_fk] [int] NOT NULL,
	[author_id_fk] [int] NOT NULL,
	[ord] [int] NOT NULL,
 CONSTRAINT [PK_book_authors] PRIMARY KEY CLUSTERED 
(
	[book_id_fk] ASC,
	[author_id_fk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[book_categories]    Script Date: 2014-10-26 20:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[book_categories](
	[book_id_fk] [int] NOT NULL,
	[category_id_fk] [int] NOT NULL,
 CONSTRAINT [PK_book_categories] PRIMARY KEY CLUSTERED 
(
	[book_id_fk] ASC,
	[category_id_fk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[books]    Script Date: 2014-10-26 20:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[books](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[isbn] [nchar](20) NOT NULL,
	[publisher_id_fk] [int] NULL,
	[publish_date] [date] NULL,
	[publish_city] [nvarchar](50) NULL,
	[publish_edition] [int] NULL,
	[title] [nvarchar](50) NOT NULL,
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
/****** Object:  Table [dbo].[borrows]    Script Date: 2014-10-26 20:03:24 ******/
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
/****** Object:  Table [dbo].[categories]    Script Date: 2014-10-26 20:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_categories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[publishers]    Script Date: 2014-10-26 20:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[publishers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_publishers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[reservations]    Script Date: 2014-10-26 20:03:24 ******/
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
/****** Object:  Table [dbo].[roles]    Script Date: 2014-10-26 20:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [ntext] NULL,
 CONSTRAINT [PK_roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[users]    Script Date: 2014-10-26 20:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role_id_fk] [int] NOT NULL,
	[login] [nchar](20) NOT NULL,
	[email] [nchar](50) NOT NULL,
	[firstname] [nvarchar](50) NOT NULL,
	[surname] [nvarchar](50) NOT NULL,
	[phone] [int] NOT NULL,
	[passwd] [nchar](40) NOT NULL,
	[incorrect_login_cnt] [int] NOT NULL,
	[last_login_info] [nvarchar](255) NULL,
	[token] [nvarchar](255) NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[categories] ON 

INSERT [dbo].[categories] ([id], [name]) VALUES (1, N'Komedia')
SET IDENTITY_INSERT [dbo].[categories] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ISBN]    Script Date: 2014-10-26 20:03:24 ******/
ALTER TABLE [dbo].[books] ADD  CONSTRAINT [IX_ISBN] UNIQUE NONCLUSTERED 
(
	[isbn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_name]    Script Date: 2014-10-26 20:03:24 ******/
ALTER TABLE [dbo].[roles] ADD  CONSTRAINT [IX_name] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[book_authors]  WITH CHECK ADD  CONSTRAINT [FK_book_authors_authors] FOREIGN KEY([author_id_fk])
REFERENCES [dbo].[authors] ([id])
GO
ALTER TABLE [dbo].[book_authors] CHECK CONSTRAINT [FK_book_authors_authors]
GO
ALTER TABLE [dbo].[book_authors]  WITH CHECK ADD  CONSTRAINT [FK_book_authors_books] FOREIGN KEY([book_id_fk])
REFERENCES [dbo].[books] ([id])
GO
ALTER TABLE [dbo].[book_authors] CHECK CONSTRAINT [FK_book_authors_books]
GO
ALTER TABLE [dbo].[book_categories]  WITH CHECK ADD  CONSTRAINT [FK_book_categories_books] FOREIGN KEY([book_id_fk])
REFERENCES [dbo].[books] ([id])
GO
ALTER TABLE [dbo].[book_categories] CHECK CONSTRAINT [FK_book_categories_books]
GO
ALTER TABLE [dbo].[book_categories]  WITH CHECK ADD  CONSTRAINT [FK_book_categories_categories] FOREIGN KEY([category_id_fk])
REFERENCES [dbo].[categories] ([id])
GO
ALTER TABLE [dbo].[book_categories] CHECK CONSTRAINT [FK_book_categories_categories]
GO
ALTER TABLE [dbo].[books]  WITH CHECK ADD  CONSTRAINT [FK_books_publishers] FOREIGN KEY([publisher_id_fk])
REFERENCES [dbo].[publishers] ([id])
GO
ALTER TABLE [dbo].[books] CHECK CONSTRAINT [FK_books_publishers]
GO
ALTER TABLE [dbo].[borrows]  WITH CHECK ADD  CONSTRAINT [FK_borrows_books] FOREIGN KEY([book_id_fk])
REFERENCES [dbo].[books] ([id])
GO
ALTER TABLE [dbo].[borrows] CHECK CONSTRAINT [FK_borrows_books]
GO
ALTER TABLE [dbo].[borrows]  WITH CHECK ADD  CONSTRAINT [FK_borrows_users] FOREIGN KEY([user_id_fk])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[borrows] CHECK CONSTRAINT [FK_borrows_users]
GO
ALTER TABLE [dbo].[reservations]  WITH CHECK ADD  CONSTRAINT [FK_reservations_books] FOREIGN KEY([book_id_fk])
REFERENCES [dbo].[books] ([id])
GO
ALTER TABLE [dbo].[reservations] CHECK CONSTRAINT [FK_reservations_books]
GO
ALTER TABLE [dbo].[reservations]  WITH CHECK ADD  CONSTRAINT [FK_reservations_users] FOREIGN KEY([user_id_fk])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[reservations] CHECK CONSTRAINT [FK_reservations_users]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_roles] FOREIGN KEY([role_id_fk])
REFERENCES [dbo].[roles] ([id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_roles]
GO
