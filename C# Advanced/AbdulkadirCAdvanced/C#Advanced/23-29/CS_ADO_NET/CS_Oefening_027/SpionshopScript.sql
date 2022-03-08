
GO
USE [Spionshop]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Artikel]
(
	[Artikel_id] [int]  NOT NULL CONSTRAINT [PK_Artikel] PRIMARY KEY CLUSTERED ,
	[Cat_id] [int] NOT NULL,
	[Artikel] [varchar](50) NOT NULL,
	[Omschrijving] [varchar](500) NULL,
	[Verkoopprijs] numeric(8,2) NULL,
	[Instock] [smallint] NULL,
)
GO

CREATE TABLE [dbo].[Bestelling]
(
	[B_id] [int]  NOT NULL  CONSTRAINT [PK_Bestelling] PRIMARY KEY CLUSTERED,
	[Klant_id] [int] NOT NULL,
	[Datum] [smalldatetime] NOT NULL,

) 

GO
CREATE TABLE [dbo].[BestellingDetail]
(
	[BD_id] [int]  NOT NULL CONSTRAINT [PK_BestellingDetail] PRIMARY KEY CLUSTERED ,
	[B_id] [int] NOT NULL,
	[Artikel_id] [int] NOT NULL,
	[Aantal] [int] NOT NULL,
)

GO
CREATE TABLE [dbo].[Categorie](
	[Cat_id] [int]  NOT NULL CONSTRAINT [PK_Categorie] PRIMARY KEY CLUSTERED ,
	[Categorie] [varchar](50) NOT NULL,
 
)

GO
CREATE TABLE [dbo].[Klant](
	[Klant_id] [int] IDENTITY(1,1) NOT NULL CONSTRAINT [PK_klant] PRIMARY KEY CLUSTERED ,
	[Naam] [varchar](50) NOT NULL,
	[Voornaam] [varchar](50) NOT NULL,
	[Woonplaats] [varchar](50) NULL,
	[Geboortedatum] [smalldatetime] NULL,
	[Gebruikersnaam] [varchar](10) NULL,
	[Pwd] [varchar](10) NULL,
 )



GO
INSERT [dbo].[Artikel] ([Artikel_id], [Cat_id], [Artikel], [Omschrijving], [Verkoopprijs], [Instock]) VALUES (1, 1, N'Communicatie apparaat', N'Klein communicatieappparaat in de vorm van een potlood, spreek in de punt en luister aan het andere uiteinde.', 49.99, 153)
GO
INSERT [dbo].[Artikel] ([Artikel_id], [Cat_id], [Artikel], [Omschrijving], [Verkoopprijs], [Instock]) VALUES (2, 1, N'Oortje vertaler', N'Dit oortje zorgt ervoor dat door gebruik te maken van geavanceerde voice-technologie uw spraak vertaald wordt in een door u ingestelde taal.', 599.99, 146)
GO
INSERT [dbo].[Artikel] ([Artikel_id], [Cat_id], [Artikel], [Omschrijving], [Verkoopprijs], [Instock]) VALUES (3, 1, N'TransApp', N'App vertaalt gesproken woorden in een door u verlangde taal, zodanig dat u vreemde talen kan begrijpen.', 459.99, 153)
GO
INSERT [dbo].[Artikel] ([Artikel_id], [Cat_id], [Artikel], [Omschrijving], [Verkoopprijs], [Instock]) VALUES (4, 1, N'LaserPointer', N'Laser pointer in de vorm van een pen.', 29.99, 153)
GO
INSERT [dbo].[Artikel] ([Artikel_id], [Cat_id], [Artikel], [Omschrijving], [Verkoopprijs], [Instock]) VALUES (5, 1, N'Overtuigingspotlood',N'Richt dit potlood op opponent in een discussie en overtuig haar/hem van uw gelijk.', 1.99, 150)
GO
INSERT [dbo].[Artikel] ([Artikel_id], [Cat_id], [Artikel], [Omschrijving], [Verkoopprijs], [Instock]) VALUES (6, 2, N'Correctie vloeistof', N'Een druppel van deze vloestof en het slachtoffer geraakt verward.', 3.99, 143)
GO
INSERT [dbo].[Artikel] ([Artikel_id], [Cat_id], [Artikel], [Omschrijving], [Verkoopprijs], [Instock]) VALUES (7, 2, N'Virtuele portefeuille', N'Coins om in lokale munteenheid te betalen.', 12.50, 153)
GO
INSERT [dbo].[Artikel] ([Artikel_id], [Cat_id], [Artikel], [Omschrijving], [Verkoopprijs], [Instock]) VALUES (8, 2, N'Confuse Identity', N'Wanneer een vijandig persoon u nadert legt u dit toestelletje aan, en hij herkent u niet meer en loopt  u zonder meer voorbij.', 17.80, 152)
GO
INSERT [dbo].[Artikel] ([Artikel_id], [Cat_id], [Artikel], [Omschrijving], [Verkoopprijs], [Instock]) VALUES (9, 3, N'Contactlenzen', N'Deze lenzen vervangen de traditionele verrekijker en geven perfect zicht tot 15km.', 13.75, 153)
GO
INSERT [dbo].[Artikel] ([Artikel_id], [Cat_id], [Artikel], [Omschrijving], [Verkoopprijs], [Instock]) VALUES (10, 3, N'Snelpleisters', N'Doe een snelpleister op een wonde en na 10-30 min is de wonde volledig genezen', 3.99, 153)



GO
INSERT [dbo].[Bestelling] ([B_id], [Klant_id], [Datum]) VALUES (2, 3, '2020-01-05')
GO
INSERT [dbo].[Bestelling] ([B_id], [Klant_id], [Datum]) VALUES (3, 2, '2020-01-06')
GO
INSERT [dbo].[Bestelling] ([B_id], [Klant_id], [Datum]) VALUES (4, 4, '2020-01-08')
GO
INSERT [dbo].[Bestelling] ([B_id], [Klant_id], [Datum]) VALUES (5, 5, '2020-01-15')
GO
INSERT [dbo].[Bestelling] ([B_id], [Klant_id], [Datum]) VALUES (6, 2, '2020-02-05')
GO
INSERT [dbo].[Bestelling] ([B_id], [Klant_id], [Datum]) VALUES (7, 3, '2020-02-06')
GO
INSERT [dbo].[Bestelling] ([B_id], [Klant_id], [Datum]) VALUES (9, 4, '2020-04-22')
GO
INSERT [dbo].[Bestelling] ([B_id], [Klant_id], [Datum]) VALUES (10, 4,'2020-04-24')
GO
INSERT [dbo].[Bestelling] ([B_id], [Klant_id], [Datum]) VALUES (11, 5, '2020-04-25')
GO
INSERT [dbo].[Bestelling] ([B_id], [Klant_id], [Datum]) VALUES (12, 2, '2020-05-23')
GO
INSERT [dbo].[Bestelling] ([B_id], [Klant_id], [Datum]) VALUES (13, 3, '2020-06-09')
GO
INSERT [dbo].[Bestelling] ([B_id], [Klant_id], [Datum]) VALUES (14, 4, '2020-06-14')
GO
INSERT [dbo].[Bestelling] ([B_id], [Klant_id], [Datum]) VALUES (15, 2, '2020-07-19')
GO
INSERT [dbo].[Bestelling] ([B_id], [Klant_id], [Datum]) VALUES (16, 3, '2021-02-20')
GO
INSERT [dbo].[Bestelling] ([B_id], [Klant_id], [Datum]) VALUES (17, 1, '2021-04-25')
GO
INSERT [dbo].[Bestelling] ([B_id], [Klant_id], [Datum]) VALUES (18, 1,'2021-04-25')
GO
INSERT [dbo].[Bestelling] ([B_id], [Klant_id], [Datum]) VALUES (19, 2, '2021-04-25')
GO
INSERT [dbo].[Bestelling] ([B_id], [Klant_id], [Datum]) VALUES (20, 1, '2021-11-05')
GO


INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (3, 2, 1, 2)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (4, 2, 3, 4)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (5, 2, 7, 2)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (6, 3, 1, 3)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (7, 3, 2, 1)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (8, 3, 9, 6)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (9, 3, 10, 4)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (10, 4, 3, 2)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (11, 4, 4, 3)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (12, 4, 8, 2)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (13, 4, 9, 1)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (14, 5, 2, 3)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (15, 6, 6, 1)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (16, 6, 7, 2)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (17, 7, 9, 3)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (18, 7, 10, 3)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (25, 9, 8, 1)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (26, 10, 3, 4)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (27, 10, 5, 2)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (28, 10, 7, 2)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (29, 11, 8, 1)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (30, 12, 10, 4)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (31, 13, 6, 7)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (32, 13, 7, 2)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (33, 14, 2, 3)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (34, 14, 9, 1)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (35, 15, 4, 5)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (36, 15, 5, 1)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (37, 15, 7, 2)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (38, 15, 10, 5)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (39, 16, 5, 2)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (44, 18, 2, 7)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (45, 18, 5, 3)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (46, 19, 6, 5)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (47, 19, 8, 1)
GO
INSERT [dbo].[BestellingDetail] ([BD_id], [B_id], [Artikel_id], [Aantal]) VALUES (48, 20, 6, 5)



GO
INSERT [dbo].[Categorie] ([Cat_id], [Categorie]) VALUES (1, N'communicatie')
GO
INSERT [dbo].[Categorie] ([Cat_id], [Categorie]) VALUES (2, N'afleiding')
GO
INSERT [dbo].[Categorie] ([Cat_id], [Categorie]) VALUES (3, N'algemeen')



GO
INSERT [dbo].[Klant] ([Naam], [Voornaam], [Woonplaats], [Geboortedatum], [Gebruikersnaam], [Pwd]) VALUES (N'Hari', N'Mata', N'Paris', '1985-05-14', N'HM', N'a')
GO
INSERT [dbo].[Klant] ([Naam], [Voornaam], [Woonplaats], [Geboortedatum], [Gebruikersnaam], [Pwd]) VALUES (N'Chapman', N'Anna', N'Moscou', '1981-12-23', N'CA', N'a')
GO
INSERT [dbo].[Klant] ([Naam], [Voornaam], [Woonplaats], [Geboortedatum], [Gebruikersnaam], [Pwd]) VALUES (N'Browser', N'Mar', N'Richmond', '1984-08-04', N'BM', N'a')
GO
INSERT [dbo].[Klant] ([Naam], [Voornaam], [Woonplaats], [Geboortedatum], [Gebruikersnaam], [Pwd]) VALUES (N'Wake', N'Nancy', N'Wellington', '1976-04-30', NULL, NULL)
GO
INSERT [dbo].[Klant] ([Naam], [Voornaam], [Woonplaats], [Geboortedatum], [Gebruikersnaam], [Pwd]) VALUES (N'Rosenberg', N'Ethel', N'Oostende', '1973-09-03', NULL, NULL)
GO
INSERT [dbo].[Klant] ([Naam], [Voornaam], [Woonplaats], [Geboortedatum], [Gebruikersnaam], [Pwd]) VALUES (N'Bond', N'James', N'London', '1978-05-15', NULL, NULL)
GO
INSERT [dbo].[Klant] ([Naam], [Voornaam], [Woonplaats], [Geboortedatum], [Gebruikersnaam], [Pwd]) VALUES (N'Craig', N'Daniel', N'London', '1968-03-02', NULL, NULL)
GO
INSERT [dbo].[Klant] ([Naam], [Voornaam], [Woonplaats], [Geboortedatum], [Gebruikersnaam], [Pwd]) VALUES (N'Saenz', N'Manuela', N'Peru', '1945-11-27', 'SaM', '009')
GO

ALTER TABLE [dbo].[Artikel]  WITH CHECK ADD  CONSTRAINT [FK_Artikel_Categorie] FOREIGN KEY([Cat_id])
REFERENCES [dbo].[Categorie] ([Cat_id])
GO

ALTER TABLE [dbo].[Bestelling]  WITH CHECK ADD  CONSTRAINT [FK_Bestelling_klant] FOREIGN KEY([Klant_id])
REFERENCES [dbo].[Klant] ([Klant_id])

GO
ALTER TABLE [dbo].[BestellingDetail]  WITH CHECK ADD  CONSTRAINT [FK_BestellingDetail_Artikel] FOREIGN KEY([Artikel_id])
REFERENCES [dbo].[Artikel] ([Artikel_id])

GO
ALTER TABLE [dbo].[BestellingDetail]  WITH CHECK ADD  CONSTRAINT [FK_BestellingDetail_Bestelling] FOREIGN KEY([B_id])
REFERENCES [dbo].[Bestelling] ([B_id])
GO

