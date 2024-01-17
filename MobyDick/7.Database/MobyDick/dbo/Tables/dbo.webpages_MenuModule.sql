CREATE TABLE [dbo].[webpages_MenuModule] (
    [IDMenuModule] INT          IDENTITY (1, 1) NOT NULL,
    [Description]  VARCHAR (50) NOT NULL,
    [op]           INT          CONSTRAINT [DF__webpages_Men__Op__267ABA7A] DEFAULT ((-1)) NOT NULL,
    [stamp]        DATETIME     CONSTRAINT [DF__webpages___Stamp__276EDEB3] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_webpages_MenuModule] PRIMARY KEY CLUSTERED ([IDMenuModule] ASC)
);



