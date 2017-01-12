CREATE TABLE [dbo].[Films] (
    [Id]          INT             NOT NULL,
    [chemin]      NVARCHAR (MAX) NOT NULL,
    [titre]       NVARCHAR (MAX) NOT NULL,
    [realisateur] NVARCHAR (MAX) NOT NULL,
    [acteurs]     NVARCHAR (MAX) NOT NULL,
    [genres]      NVARCHAR (MAX) NOT NULL,
    [nationalite] NVARCHAR (MAX) NOT NULL,
    [resume]      NVARCHAR (MAX) NOT NULL,
    [datesortie]  NVARCHAR (MAX) NOT NULL,
    [affiche]     VARBINARY (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

