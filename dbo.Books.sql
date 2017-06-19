CREATE TABLE [dbo].[Books] (
    [BookID]      INT         IDENTITY (1, 1) NOT NULL,
    [Title]       NCHAR (100) NULL,
    [Author]      NCHAR (100) NULL,
    [Category]    NCHAR (100) NULL,
    [Publisher]   NCHAR (100) NULL,
    [ReleaseDate] DATE        NULL,
    [Price]       SMALLMONEY       NULL,
    [KindOfBook]  NCHAR (10)  NULL,
    PRIMARY KEY CLUSTERED ([BookID] ASC)
);

