CREATE TABLE [dbo].[webpages_Checkpoint] (
    [IdCheckpoint] INT          IDENTITY (1, 1) NOT NULL,
    [Code]         VARCHAR (10) NOT NULL,
    [Description]  VARCHAR (50) NOT NULL,
    [IpService]    VARCHAR (50) NOT NULL,
    [deleted]      BIT          CONSTRAINT [DF_webpages_Checkoint_deleted] DEFAULT ((0)) NOT NULL,
    [op]           INT          CONSTRAINT [DF_webpages_Checkoint_op] DEFAULT ((-1)) NOT NULL,
    [stamp]        DATETIME     CONSTRAINT [DF_webpages_Checkoint_stamp] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Checkpoint] PRIMARY KEY CLUSTERED ([IdCheckpoint] ASC)
);

