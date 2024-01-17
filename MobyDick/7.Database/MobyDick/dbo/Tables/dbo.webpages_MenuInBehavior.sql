CREATE TABLE [dbo].[webpages_MenuInBehavior] (
    [IDMenu]     INT NOT NULL,
    [IDBehavior] INT NOT NULL,
    CONSTRAINT [PK_webpages_MenuAuthorization] PRIMARY KEY CLUSTERED ([IDMenu] ASC, [IDBehavior] ASC),
    CONSTRAINT [FK_webpages_MenuInBehavior_webpages_Behavior] FOREIGN KEY ([IDBehavior]) REFERENCES [dbo].[webpages_Behavior] ([IDBehavior]),
    CONSTRAINT [FK_webpages_MenuInBehavior_webpages_Menu] FOREIGN KEY ([IDMenu]) REFERENCES [dbo].[webpages_Menu] ([IDMenu])
);



