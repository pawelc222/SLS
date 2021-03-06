USE [SLS]
GO
/****** Object:  Table [dbo].[authors]    Script Date: 2014-10-27 16:06:55 ******/
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
/****** Object:  Table [dbo].[book_authors]    Script Date: 2014-10-27 16:06:55 ******/
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
/****** Object:  Table [dbo].[book_categories]    Script Date: 2014-10-27 16:06:55 ******/
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
/****** Object:  Table [dbo].[books]    Script Date: 2014-10-27 16:06:55 ******/
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
/****** Object:  Table [dbo].[borrows]    Script Date: 2014-10-27 16:06:55 ******/
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
/****** Object:  Table [dbo].[categories]    Script Date: 2014-10-27 16:06:55 ******/
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
/****** Object:  Table [dbo].[publishers]    Script Date: 2014-10-27 16:06:55 ******/
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
/****** Object:  Table [dbo].[reservations]    Script Date: 2014-10-27 16:06:55 ******/
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
/****** Object:  Table [dbo].[roles]    Script Date: 2014-10-27 16:06:55 ******/
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
/****** Object:  Table [dbo].[users]    Script Date: 2014-10-27 16:06:55 ******/
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
SET IDENTITY_INSERT [dbo].[authors] ON 

INSERT [dbo].[authors] ([id], [firstname], [surname], [date_of_birth], [date_of_death], [description]) VALUES (1, N'Henryk', N'Sienkiewicz', CAST(0xCC480A00 AS Date), CAST(0x6EAD0A00 AS Date), N'Polski nowelista, powieściopisarz i publicysta')
INSERT [dbo].[authors] ([id], [firstname], [surname], [date_of_birth], [date_of_death], [description]) VALUES (2, N'Adam', N'Mickiewicz', CAST(0x3A050A00 AS Date), CAST(0x70560A00 AS Date), N'Polski poeta, działacz i publicysta polityczny, wolnomularz')
SET IDENTITY_INSERT [dbo].[authors] OFF
INSERT [dbo].[book_authors] ([book_id_fk], [author_id_fk], [ord]) VALUES (1, 2, 1)
INSERT [dbo].[book_authors] ([book_id_fk], [author_id_fk], [ord]) VALUES (2, 1, 1)
INSERT [dbo].[book_authors] ([book_id_fk], [author_id_fk], [ord]) VALUES (3, 1, 1)
INSERT [dbo].[book_categories] ([book_id_fk], [category_id_fk]) VALUES (1, 2)
INSERT [dbo].[book_categories] ([book_id_fk], [category_id_fk]) VALUES (2, 3)
INSERT [dbo].[book_categories] ([book_id_fk], [category_id_fk]) VALUES (3, 3)
SET IDENTITY_INSERT [dbo].[books] ON 

INSERT [dbo].[books] ([id], [isbn], [publisher_id_fk], [publish_date], [publish_city], [publish_edition], [title], [cover], [table_of_contents], [language], [description], [available_copies]) VALUES (1, N'978-83-7738-363-6   ', 1, CAST(0xE7350B00 AS Date), N'Warszawa', 3, N'Pan Tadeusz', N'\covers\pantadeusz.jpg', NULL, N'polski', N'"Pan Tadeusz" Adama Mickiewicza to lektura z sugerowanego przez nową podstawę programową spisu utworów literackich do omawiania w liceum. Wydanie zawiera tekst utworu oraz omówienie.', 5)
INSERT [dbo].[books] ([id], [isbn], [publisher_id_fk], [publish_date], [publish_city], [publish_edition], [title], [cover], [table_of_contents], [language], [description], [available_copies]) VALUES (2, N'978-83-7738-363-7   ', 2, CAST(0xA2340B00 AS Date), N'Kraków', 2, N'Quo vadis', N'\covers\quovadis.jpg', NULL, N'polski', N'"Quo vadis" jest powieścią, która przyniosła Henrykowi Sienkiewiczowi nie tylko ogromny rozgłos, ale i miliony czytelników na całym świecie.', 3)
INSERT [dbo].[books] ([id], [isbn], [publisher_id_fk], [publish_date], [publish_city], [publish_edition], [title], [cover], [table_of_contents], [language], [description], [available_copies]) VALUES (3, N'978-83-7738-363-8   ', 2, CAST(0x48370B00 AS Date), N'Kraków', 1, N'Potop', N'\covers\potop.jpg', NULL, N'polski', N'Rok 1655, w granice Rzeczpospolitej wkracza olbrzymia armia szwedzka. Polacy zapamiętają ten najazd jako „potop szwedzki”.', 1)
SET IDENTITY_INSERT [dbo].[books] OFF
SET IDENTITY_INSERT [dbo].[borrows] ON 

INSERT [dbo].[borrows] ([id], [book_id_fk], [user_id_fk], [from_date], [to_date], [prolong_cnt]) VALUES (1, 1, 2, CAST(0x0000A3A100000000 AS DateTime), CAST(0x0000A3BE00000000 AS DateTime), 0)
INSERT [dbo].[borrows] ([id], [book_id_fk], [user_id_fk], [from_date], [to_date], [prolong_cnt]) VALUES (2, 2, 2, CAST(0x0000A38100000000 AS DateTime), CAST(0x0000A3A000000000 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[borrows] OFF
SET IDENTITY_INSERT [dbo].[categories] ON 

INSERT [dbo].[categories] ([id], [name]) VALUES (1, N'Komedia')
INSERT [dbo].[categories] ([id], [name]) VALUES (2, N'Dramat')
INSERT [dbo].[categories] ([id], [name]) VALUES (3, N'Proza')
SET IDENTITY_INSERT [dbo].[categories] OFF
SET IDENTITY_INSERT [dbo].[publishers] ON 

INSERT [dbo].[publishers] ([id], [name]) VALUES (1, N'Merlin')
INSERT [dbo].[publishers] ([id], [name]) VALUES (2, N'GREG')
SET IDENTITY_INSERT [dbo].[publishers] OFF
INSERT [dbo].[roles] ([id], [name], [description]) VALUES (1, N'bibliotekarz', N'bibliotekarz')
INSERT [dbo].[roles] ([id], [name], [description]) VALUES (2, N'czytelnik', N'czytelnik')
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([id], [role_id_fk], [login], [email], [firstname], [surname], [phone], [passwd], [incorrect_login_cnt], [last_login_info], [token]) VALUES (1, 1, N'jkowalski           ', N'jkowalski@gmail.com                               ', N'Jan', N'Kowalski', 111222333, N'1234                                    ', 0, NULL, NULL)
INSERT [dbo].[users] ([id], [role_id_fk], [login], [email], [firstname], [surname], [phone], [passwd], [incorrect_login_cnt], [last_login_info], [token]) VALUES (2, 2, N'jnowak              ', N'jnowak@gmail.com                                  ', N'Jan', N'Nowak', 444555666, N'1234                                    ', 0, NULL, NULL)
INSERT [dbo].[users] ([id], [role_id_fk], [login], [email], [firstname], [surname], [phone], [passwd], [incorrect_login_cnt], [last_login_info], [token]) VALUES (3, 2, N'pwisniewski         ', N'pwisniewski@gmail.com                             ', N'Piotr', N'Wiśniewski', 777888999, N'1234                                    ', 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[users] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ISBN]    Script Date: 2014-10-27 16:06:55 ******/
ALTER TABLE [dbo].[books] ADD  CONSTRAINT [IX_ISBN] UNIQUE NONCLUSTERED 
(
	[isbn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_name]    Script Date: 2014-10-27 16:06:55 ******/
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
