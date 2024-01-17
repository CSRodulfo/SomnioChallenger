CREATE TABLE [dbo].[webpages_Behavior] (
    [IDBehavior]   INT          NOT NULL,
    [BehaviorName] VARCHAR (50) NOT NULL,
    [op]           INT          CONSTRAINT [DF__webpages_Beh__Op__1CF15040] DEFAULT ((-1)) NOT NULL,
    [stamp]        DATETIME     CONSTRAINT [DF__webpages___Stamp__1DE57479] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_webpages_Authorization_1] PRIMARY KEY CLUSTERED ([IDBehavior] ASC)
);



