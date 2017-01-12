CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [chemin] NVARCHAR(1000) NOT NULL, 
    [titre] NVARCHAR(1000) NOT NULL, 
	[realisateur] NVARCHAR(1000) NOT NULL, 
	[acteurs] NVARCHAR(1000) NOT NULL, 
	[genres] NVARCHAR(1000) NOT NULL, 
	[nationalite] NVARCHAR(1000) NOT NULL, 
	[resume]NVARCHAR(2000) NOT NULL, 
    [datesortie] NVARCHAR(1000) NOT NULL, 
    [affiche] VARBINARY(MAX) NULL, 
)
