USE [Modul2Test2]
GO
/****** Object:  Table [dbo].[RADNIK]    Script Date: 6/21/2022 4:04:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RADNIK](
	[RADNIK_ID] [int] IDENTITY(1,1) NOT NULL,
	[IME_I_PREZIME] [varchar](200) NULL,
	[RADNO_MESTO] [varchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZADATAK]    Script Date: 6/21/2022 4:04:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZADATAK](
	[ZADATAK_ID] [int] IDENTITY(1,1) NOT NULL,
	[RADNIK_ID] [int] NOT NULL,
	[NASLOV] [varchar](100) NOT NULL,
	[PROCENJENO_VREME] [decimal](18, 0) NOT NULL,
	[TEZINA] [int] NOT NULL,
	[OPIS] [varchar](1024) NOT NULL,
	[STANJE] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[RADNIK] ON 
GO
INSERT [dbo].[RADNIK] ([RADNIK_ID], [IME_I_PREZIME], [RADNO_MESTO]) VALUES (1, N'Petar Petrovic', N'programer')
GO
INSERT [dbo].[RADNIK] ([RADNIK_ID], [IME_I_PREZIME], [RADNO_MESTO]) VALUES (2, N'Marko Markovic', N'programer')
GO
INSERT [dbo].[RADNIK] ([RADNIK_ID], [IME_I_PREZIME], [RADNO_MESTO]) VALUES (3, N'Nikola Nikolic', N'programer')
GO
INSERT [dbo].[RADNIK] ([RADNIK_ID], [IME_I_PREZIME], [RADNO_MESTO]) VALUES (4, N'Predrag Peric', N'Slikar')
GO
INSERT [dbo].[RADNIK] ([RADNIK_ID], [IME_I_PREZIME], [RADNO_MESTO]) VALUES (5, N'Jovan Jovanovic', N'Pekar')
GO
SET IDENTITY_INSERT [dbo].[RADNIK] OFF
GO
SET IDENTITY_INSERT [dbo].[ZADATAK] ON 
GO
INSERT [dbo].[ZADATAK] ([ZADATAK_ID], [RADNIK_ID], [NASLOV], [PROCENJENO_VREME], [TEZINA], [OPIS], [STANJE]) VALUES (1, 1, N'Test', CAST(1 AS Decimal(18, 0)), 1, N'Test123', N'u toku')
GO
INSERT [dbo].[ZADATAK] ([ZADATAK_ID], [RADNIK_ID], [NASLOV], [PROCENJENO_VREME], [TEZINA], [OPIS], [STANJE]) VALUES (8, 5, N'Upload slika za korisnike', CAST(8 AS Decimal(18, 0)), 5, N'Programer', N'zavrsen')
GO
SET IDENTITY_INSERT [dbo].[ZADATAK] OFF
GO
/****** Object:  Index [PK_RADNIK]    Script Date: 6/21/2022 4:04:27 PM ******/
ALTER TABLE [dbo].[RADNIK] ADD  CONSTRAINT [PK_RADNIK] PRIMARY KEY NONCLUSTERED 
(
	[RADNIK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK_ZADATAK]    Script Date: 6/21/2022 4:04:27 PM ******/
ALTER TABLE [dbo].[ZADATAK] ADD  CONSTRAINT [PK_ZADATAK] PRIMARY KEY NONCLUSTERED 
(
	[ZADATAK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ZADATAK]  WITH NOCHECK ADD  CONSTRAINT [DEL_ZADATAK_RADNIK] FOREIGN KEY([RADNIK_ID])
REFERENCES [dbo].[RADNIK] ([RADNIK_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ZADATAK] CHECK CONSTRAINT [DEL_ZADATAK_RADNIK]
GO
ALTER TABLE [dbo].[ZADATAK]  WITH CHECK ADD  CONSTRAINT [FK_ZADATAK_RADNIK] FOREIGN KEY([RADNIK_ID])
REFERENCES [dbo].[RADNIK] ([RADNIK_ID])
GO
ALTER TABLE [dbo].[ZADATAK] CHECK CONSTRAINT [FK_ZADATAK_RADNIK]
GO
