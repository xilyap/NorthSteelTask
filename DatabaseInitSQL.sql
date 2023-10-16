
CREATE TABLE [dbo].[Provider](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] [nvarchar](50) NULL
)
CREATE TABLE [dbo].[Good](
	[Id] INT PRIMARY KEY IDENTITY,
	[ProviderId] [int] REFERENCES Provider (Id),
	[Name] [nvarchar](50) NOT NULL
)
CREATE TABLE [dbo].[Supply](
	[Id] INT PRIMARY KEY IDENTITY,
	[Date] [date] NOT NULL,
	[ProviderId] [int] REFERENCES Provider (Id)
) 
CREATE TABLE [dbo].[SupplyGood](
	[Id] INT PRIMARY KEY IDENTITY,
	[SupplyId] [int] REFERENCES Supply (Id),
	[GoodId] [int] REFERENCES Good (Id),
	[Weight] [real] NOT NULL,
	[Price] [real] NOT NULL
) 

