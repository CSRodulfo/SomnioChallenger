CREATE TABLE [dbo].[webpages_File] (
    [IdFile]   INT             IDENTITY (1, 1) NOT NULL,
    [FileData] VARBINARY (MAX) NOT NULL,
    [MimeType] VARCHAR (255)   NOT NULL,
    [Date]     DATETIME        NOT NULL,
    [FileName] VARCHAR (50)    NOT NULL,
    [op]       INT             CONSTRAINT [DF_webpages_File_op] DEFAULT ((-1)) NOT NULL,
    [stamp]    DATETIME        CONSTRAINT [DF_webpages_File_stamp] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Files] PRIMARY KEY CLUSTERED ([IdFile] ASC)
);

