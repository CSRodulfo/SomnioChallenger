﻿CREATE TABLE [dbo].[webpages_Logging] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [EventDateTime]     DATETIME       NOT NULL,
    [EventLevel]        NVARCHAR (100) NOT NULL,
    [UserName]          NVARCHAR (100) NOT NULL,
    [MachineName]       NVARCHAR (100) NOT NULL,
    [EventMessage]      NVARCHAR (MAX) NOT NULL,
    [ErrorSource]       NVARCHAR (100) NULL,
    [ErrorClass]        NVARCHAR (500) NULL,
    [ErrorMethod]       NVARCHAR (MAX) NULL,
    [ErrorMessage]      NVARCHAR (MAX) NULL,
    [InnerErrorMessage] NVARCHAR (MAX) NULL,
    [StackTrace]        NVARCHAR (MAX) NULL,
    [TargetSite]        NVARCHAR (500) NULL,
    CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED ([Id] ASC)
);

