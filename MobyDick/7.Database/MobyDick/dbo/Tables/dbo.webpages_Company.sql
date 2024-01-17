CREATE TABLE [dbo].[webpages_Company] (
    [IdCompany] INT          IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (50) NOT NULL,
    [CUIT]      VARCHAR (50) NULL,
    [Address]   VARCHAR (50) NULL,
    [Number]    VARCHAR (50) NULL,
    [State]     VARCHAR (50) NULL,
    [Country]   VARCHAR (50) NULL,
    [Logo]      INT          NULL,
    [op]        INT          DEFAULT ((-1)) NOT NULL,
    [stamp]     DATETIME     DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_webpages_Company] PRIMARY KEY CLUSTERED ([IdCompany] ASC),
    CONSTRAINT [FK_Company_webpages_File] FOREIGN KEY ([Logo]) REFERENCES [dbo].[webpages_File] ([IdFile])
);

