CREATE TABLE [dbo].[Users] (
    [UserId]    INT           IDENTITY (1, 1) NOT NULL,
    [UserName]  NVARCHAR (56) NOT NULL,
    [LastName]  VARCHAR (50)  NOT NULL,
    [FirstName] VARCHAR (50)  NOT NULL,
    [Email]     VARCHAR (50)  NULL,
    [IdFile]    INT           NULL,
    [op]        INT           CONSTRAINT [DF__Users__Op__1B0907CE] DEFAULT ((-1)) NOT NULL,
    [stamp]     DATETIME      CONSTRAINT [DF__Users__Stamp__1BFD2C07] DEFAULT (getdate()) NOT NULL,
    [deleted]   BIT           CONSTRAINT [DF_Users_deleted] DEFAULT ((0)) NOT NULL,
    [IdCulture] INT           CONSTRAINT [DF_Users_IdCulture] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__Users__1788CC4C0AD2A005] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_Users_webpages_Culture] FOREIGN KEY ([IdCulture]) REFERENCES [dbo].[webpages_Culture] ([IdCulture]),
    CONSTRAINT [FK_Users_webpages_File] FOREIGN KEY ([IdFile]) REFERENCES [dbo].[webpages_File] ([IdFile]),
    CONSTRAINT [UQ__Users__C9F28456276EDEB3] UNIQUE NONCLUSTERED ([UserName] ASC)
);









