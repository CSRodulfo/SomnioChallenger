CREATE TABLE [dbo].[webpages_MenuInRoles] (
    [IDRole] INT NOT NULL,
    [IDMenu] INT NOT NULL,
    CONSTRAINT [PK_webpages_MenuInRoles_1] PRIMARY KEY CLUSTERED ([IDRole] ASC, [IDMenu] ASC),
    CONSTRAINT [FK_webpages_MenuInRoles_webpages_Menu] FOREIGN KEY ([IDMenu]) REFERENCES [dbo].[webpages_Menu] ([IDMenu]),
    CONSTRAINT [FK_webpages_MenuInRoles_webpages_Roles] FOREIGN KEY ([IDRole]) REFERENCES [dbo].[webpages_Roles] ([RoleId])
);



