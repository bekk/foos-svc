IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Players' and xtype='U')
	CREATE TABLE [dbo].[Players](
		[Name] [nvarchar](50) PRIMARY KEY,
		[EmployeeId] [int] NULL,
	) ON [PRIMARY]


IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Matches' and xtype='U')
	CREATE TABLE [dbo].[Matches](
		[MatchId] [int] IDENTITY (1, 1) PRIMARY KEY,
		[Date] [DATETIME] NOT NULL DEFAULT (GETDATE())
	) ON [PRIMARY]


IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Teams' and xtype='U')
	CREATE TABLE [dbo].Teams(
		[MatchId] [int]  NOT NULL,
		[Name] [nvarchar](50) NOT NULL,
		[IsWhite] [bit] NOT NULL,
		CONSTRAINT FK_Teams_Players FOREIGN KEY ([Name])
			REFERENCES  Players ([Name]),
		CONSTRAINT FK_Teams_Matches FOREIGN KEY (MatchId)
			REFERENCES  Matches (MatchId),
		CONSTRAINT PK_Teams PRIMARY KEY (MatchId, [Name])
	) ON [PRIMARY]


IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Scores' and xtype='U')
	CREATE TABLE [dbo].Scores(
		[MatchId] [int]  NOT NULL,
		[Score] [int] NOT NULL,
		[IsWhite] [bit] NOT NULL,
		CONSTRAINT FK_Scores_Matches FOREIGN KEY (MatchId)
			REFERENCES  Matches ([MatchId]),
		CONSTRAINT PK_Scores PRIMARY KEY (MatchId, IsWhite)
	) ON [PRIMARY]
