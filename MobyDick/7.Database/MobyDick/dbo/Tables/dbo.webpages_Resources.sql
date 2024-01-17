CREATE TABLE [dbo].[webpages_Resources] (
    [IdResource] INT             IDENTITY (1, 1) NOT NULL,
    [IdCulture]  INT             NOT NULL,
    [Name]       VARCHAR (100)   NOT NULL,
    [Value]      NVARCHAR (4000) NOT NULL,
    [IDMenu]     INT             NULL,
    [op]         INT             CONSTRAINT [DF__webpages_Res__op__11158940] DEFAULT ((-1)) NOT NULL,
    [stamp]      DATETIME        DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [pk_resources_culture_name] PRIMARY KEY CLUSTERED ([IdResource] ASC),
    CONSTRAINT [FK_Culture_Resources] FOREIGN KEY ([IdCulture]) REFERENCES [dbo].[webpages_Culture] ([IdCulture]),
    CONSTRAINT [FK_Menu_Resources] FOREIGN KEY ([IDMenu]) REFERENCES [dbo].[webpages_Menu] ([IDMenu])
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_webpages_UResources]
    ON [dbo].[webpages_Resources]([IdCulture] ASC, [Name] ASC, [IDMenu] ASC);

