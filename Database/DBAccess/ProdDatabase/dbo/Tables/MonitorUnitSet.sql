CREATE TABLE [dbo].[MonitorUnitSet] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Clorine]      FLOAT (53)     NOT NULL,
    [Name]         NVARCHAR (MAX) NOT NULL,
    [Ph]           FLOAT (53)     NOT NULL,
    [SerialNumber] NVARCHAR (MAX) NOT NULL,
    [Temperature]  FLOAT (53)     NOT NULL,
    [PoolId]       INT            NOT NULL,
    CONSTRAINT [PK_MonitorUnitSet] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PoolMonitorUnit] FOREIGN KEY ([PoolId]) REFERENCES [dbo].[PoolSet] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_PoolMonitorUnit]
    ON [dbo].[MonitorUnitSet]([PoolId] ASC);

