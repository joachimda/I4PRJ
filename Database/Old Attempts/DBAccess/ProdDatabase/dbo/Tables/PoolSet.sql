CREATE TABLE [dbo].[PoolSet] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (MAX) NOT NULL,
    [UserId] INT            NOT NULL,
    CONSTRAINT [PK_PoolSet] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserPool] FOREIGN KEY ([UserId]) REFERENCES [dbo].[UserSet] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_UserPool]
    ON [dbo].[PoolSet]([UserId] ASC);

