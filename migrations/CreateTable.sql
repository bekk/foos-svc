IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Players' and xtype='U')
	CREATE TABLE [dbo].[Players](
		[Name] [nvarchar](50) PRIMARY KEY,
		[EmployeeId] [int] NULL,
	) ON [PRIMARY]




IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Scores' and xtype='U')
	CREATE TABLE [dbo].[Scores](
		[isWhite] [bit] NOT NULL,
		[MatchId] [int] NOT NULL,
		[Score] [int] NOT NULL,
		CONSTRAINT PK_Scores PRIMARY KEY (MatchId, isWhite)
	) ON [PRIMARY]



IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Matches' and xtype='U')
	CREATE TABLE [dbo].[Matches](
		[MatchId] [int] NOT NULL,
		[Name] [nvarchar](50) NOT NULL,
		[isWhite] [bit] NOT NULL,
		CONSTRAINT FK_Matches_Players FOREIGN KEY ([Name])
			REFERENCES  Players ([Name]),
		CONSTRAINT FK_Matches_Scores FOREIGN KEY (MatchId, isWhite)
			REFERENCES  Scores (MatchId, isWhite),
		CONSTRAINT PK_Matches PRIMARY KEY (MatchId, [Name])

	) ON [PRIMARY]
