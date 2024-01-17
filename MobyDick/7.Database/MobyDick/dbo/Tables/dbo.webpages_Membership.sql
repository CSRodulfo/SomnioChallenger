CREATE TABLE [dbo].[webpages_Membership] (
    [UserId]                                  INT            NOT NULL,
    [CreateDate]                              DATETIME       NULL,
    [ConfirmationToken]                       NVARCHAR (128) NULL,
    [IsConfirmed]                             BIT            CONSTRAINT [DF__webpages___IsCon__1ED998B2] DEFAULT ((0)) NULL,
    [LastPasswordFailureDate]                 DATETIME       NULL,
    [PasswordFailuresSinceLastSuccess]        INT            CONSTRAINT [DF__webpages___Passw__1FCDBCEB] DEFAULT ((0)) NOT NULL,
    [Password]                                NVARCHAR (128) NOT NULL,
    [PasswordMobile]                          NVARCHAR (128) NULL,
    [PasswordChangedDate]                     DATETIME       NULL,
    [PasswordSalt]                            NVARCHAR (128) NOT NULL,
    [PasswordVerificationToken]               NVARCHAR (128) NULL,
    [PasswordVerificationTokenExpirationDate] DATETIME       NULL,
    [op]                                      INT            CONSTRAINT [DF__webpages_Mem__Op__20C1E124] DEFAULT ((-1)) NULL,
    [stamp]                                   DATETIME       CONSTRAINT [DF__webpages___Stamp__21B6055D] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_webpages_Membership] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_webpages_Membership_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);







