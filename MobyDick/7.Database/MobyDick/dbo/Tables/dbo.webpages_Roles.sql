CREATE TABLE [dbo].[webpages_Roles] (
    [RoleId]            INT          IDENTITY (1, 1) NOT NULL,
    [RoleName]          VARCHAR (50) NOT NULL,
    [op]                INT          CONSTRAINT [DF__webpages_Rol__Op__2C3393D0] DEFAULT ((-1)) NOT NULL,
    [stamp]             DATETIME     CONSTRAINT [DF__webpages___Stamp__2D27B809] DEFAULT (getdate()) NOT NULL,
    [EnableViewDeleted] BIT          DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_webpages_Roles] PRIMARY KEY CLUSTERED ([RoleId] ASC),
    CONSTRAINT [UQ__webpages__8A2B61602A4B4B5E] UNIQUE NONCLUSTERED ([RoleName] ASC),
    CONSTRAINT [UQ__webpages__8A2B61607C4F7684] UNIQUE NONCLUSTERED ([RoleName] ASC)
);







