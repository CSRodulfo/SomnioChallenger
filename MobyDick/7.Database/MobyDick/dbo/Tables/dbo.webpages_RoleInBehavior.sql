CREATE TABLE [dbo].[webpages_RoleInBehavior] (
    [IDRoleInBehavior] INT IDENTITY (1, 1) NOT NULL,
    [IDRole]           INT NOT NULL,
    [IDBehavior]       INT NOT NULL,
    [Authorization]    BIT NOT NULL,
    CONSTRAINT [PK_webpages_RoleInBehavior] PRIMARY KEY CLUSTERED ([IDRoleInBehavior] ASC),
    CONSTRAINT [FK_webpages_RoleInBehavior_webpages_Behavior] FOREIGN KEY ([IDBehavior]) REFERENCES [dbo].[webpages_Behavior] ([IDBehavior]),
    CONSTRAINT [FK_webpages_RoleInBehavior_webpages_Roles] FOREIGN KEY ([IDRole]) REFERENCES [dbo].[webpages_Roles] ([RoleId])
);



