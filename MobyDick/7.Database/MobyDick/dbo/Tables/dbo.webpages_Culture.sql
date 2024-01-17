CREATE TABLE [dbo].[webpages_Culture] (
    [IdCulture]   INT          IDENTITY (1, 1) NOT NULL,
    [Description] VARCHAR (50) NOT NULL,
    [Code]        VARCHAR (10) DEFAULT (NULL) NULL,
    CONSTRAINT [PK_Culture] PRIMARY KEY CLUSTERED ([IdCulture] ASC)
);

