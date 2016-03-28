CREATE TABLE [dbo].[UserSet] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Email]      NVARCHAR (MAX) NOT NULL,
    [Firstname]  NVARCHAR (MAX) NOT NULL,
    [Middlename] NVARCHAR (MAX) NOT NULL,
    [Lastname]   NVARCHAR (MAX) NOT NULL,
    [Password]   NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_UserSet] PRIMARY KEY CLUSTERED ([Id] ASC)
);

