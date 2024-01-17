CREATE TABLE [dbo].[webpages_Menu] (
    [IDMenu]       INT          IDENTITY (1, 1) NOT NULL,
    [IDMenuModule] INT          NULL,
    [IDParent]     INT          NULL,
    [Name]         VARCHAR (50) NOT NULL,
    [Area]         VARCHAR (50) NULL,
    [Controller]   VARCHAR (50) NOT NULL,
    [Action]       VARCHAR (50) NOT NULL,
    [Description]  VARCHAR (50) NOT NULL,
    [Orden]        INT          NOT NULL,
    [Axis_X]       INT          NOT NULL,
    [Axis_Y]       INT          NOT NULL,
    [op]           INT          CONSTRAINT [DF_webpages_Menu_op] DEFAULT ((-1)) NOT NULL,
    [stamp]        DATETIME     CONSTRAINT [DF_webpages_Menu_stamp] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_webpages_Authorization] PRIMARY KEY CLUSTERED ([IDMenu] ASC),
    CONSTRAINT [FK_webpages_Menu_webpages_Menu] FOREIGN KEY ([IDParent]) REFERENCES [dbo].[webpages_Menu] ([IDMenu]),
    CONSTRAINT [FK_webpages_Menu_webpages_MenuModule] FOREIGN KEY ([IDMenuModule]) REFERENCES [dbo].[webpages_MenuModule] ([IDMenuModule])
);



