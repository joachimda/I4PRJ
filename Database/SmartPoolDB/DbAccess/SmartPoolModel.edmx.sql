
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/30/2016 18:36:54
-- Generated from EDMX file: F:\Cygwin64\home\Mr. Derp\Git repos\I4PRJ\Database\SmartPoolDB\DbAccess\SmartPoolModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SmartPoolProductionDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserPool]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PoolSet] DROP CONSTRAINT [FK_UserPool];
GO
IF OBJECT_ID(N'[dbo].[FK_PoolMonitorUnit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MonitorUnitSet] DROP CONSTRAINT [FK_PoolMonitorUnit];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[PoolSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PoolSet];
GO
IF OBJECT_ID(N'[dbo].[MonitorUnitSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MonitorUnitSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Firstname] nvarchar(max)  NOT NULL,
    [Middlename] nvarchar(max)  NULL,
    [Lastname] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PoolSet'
CREATE TABLE [dbo].[PoolSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Length] float  NOT NULL,
    [Width] float  NOT NULL,
    [Depth] float  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'MonitorUnitSet'
CREATE TABLE [dbo].[MonitorUnitSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ph] nvarchar(max)  NOT NULL,
    [Temperature] nvarchar(max)  NOT NULL,
    [Chlorine] nvarchar(max)  NOT NULL,
    [Humidity] nvarchar(max)  NOT NULL,
    [SerialNumber] nvarchar(max)  NOT NULL,
    [PoolId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PoolSet'
ALTER TABLE [dbo].[PoolSet]
ADD CONSTRAINT [PK_PoolSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MonitorUnitSet'
ALTER TABLE [dbo].[MonitorUnitSet]
ADD CONSTRAINT [PK_MonitorUnitSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'PoolSet'
ALTER TABLE [dbo].[PoolSet]
ADD CONSTRAINT [FK_UserPool]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPool'
CREATE INDEX [IX_FK_UserPool]
ON [dbo].[PoolSet]
    ([UserId]);
GO

-- Creating foreign key on [PoolId] in table 'MonitorUnitSet'
ALTER TABLE [dbo].[MonitorUnitSet]
ADD CONSTRAINT [FK_PoolMonitorUnit]
    FOREIGN KEY ([PoolId])
    REFERENCES [dbo].[PoolSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PoolMonitorUnit'
CREATE INDEX [IX_FK_PoolMonitorUnit]
ON [dbo].[MonitorUnitSet]
    ([PoolId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------