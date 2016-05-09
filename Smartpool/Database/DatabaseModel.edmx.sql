
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/09/2016 12:26:17
-- Generated from EDMX file: C:\cygwin64\home\Mr. Derp-lappitoppi\git-repos\I4PRJ\Smartpool\Database\DatabaseModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SmartpoolDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserPool]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PoolSet] DROP CONSTRAINT [FK_UserPool];
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
IF OBJECT_ID(N'[dbo].[pHSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[pHSet];
GO
IF OBJECT_ID(N'[dbo].[ChlorineSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChlorineSet];
GO
IF OBJECT_ID(N'[dbo].[TemperatureSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TemperatureSet];
GO
IF OBJECT_ID(N'[dbo].[HumiditySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HumiditySet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Firstname] nvarchar(max)  NOT NULL,
    [Middelname] nvarchar(max)  NULL,
    [Lastname] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PoolSet'
CREATE TABLE [dbo].[PoolSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Volume] float  NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'pHSet'
CREATE TABLE [dbo].[pHSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] int  NOT NULL,
    [DataId] int  NOT NULL
);
GO

-- Creating table 'ChlorineSet'
CREATE TABLE [dbo].[ChlorineSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] int  NOT NULL,
    [DataId] int  NOT NULL
);
GO

-- Creating table 'TemperatureSet'
CREATE TABLE [dbo].[TemperatureSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] int  NOT NULL,
    [DataId] int  NOT NULL
);
GO

-- Creating table 'HumiditySet'
CREATE TABLE [dbo].[HumiditySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] int  NOT NULL,
    [DataId] int  NOT NULL
);
GO

-- Creating table 'DataSet'
CREATE TABLE [dbo].[DataSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Timestamp] nvarchar(max)  NOT NULL,
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

-- Creating primary key on [Id] in table 'pHSet'
ALTER TABLE [dbo].[pHSet]
ADD CONSTRAINT [PK_pHSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ChlorineSet'
ALTER TABLE [dbo].[ChlorineSet]
ADD CONSTRAINT [PK_ChlorineSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TemperatureSet'
ALTER TABLE [dbo].[TemperatureSet]
ADD CONSTRAINT [PK_TemperatureSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HumiditySet'
ALTER TABLE [dbo].[HumiditySet]
ADD CONSTRAINT [PK_HumiditySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DataSet'
ALTER TABLE [dbo].[DataSet]
ADD CONSTRAINT [PK_DataSet]
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

-- Creating foreign key on [PoolId] in table 'DataSet'
ALTER TABLE [dbo].[DataSet]
ADD CONSTRAINT [FK_PoolData]
    FOREIGN KEY ([PoolId])
    REFERENCES [dbo].[PoolSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PoolData'
CREATE INDEX [IX_FK_PoolData]
ON [dbo].[DataSet]
    ([PoolId]);
GO

-- Creating foreign key on [DataId] in table 'ChlorineSet'
ALTER TABLE [dbo].[ChlorineSet]
ADD CONSTRAINT [FK_DataChlorine]
    FOREIGN KEY ([DataId])
    REFERENCES [dbo].[DataSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DataChlorine'
CREATE INDEX [IX_FK_DataChlorine]
ON [dbo].[ChlorineSet]
    ([DataId]);
GO

-- Creating foreign key on [DataId] in table 'HumiditySet'
ALTER TABLE [dbo].[HumiditySet]
ADD CONSTRAINT [FK_DataHumidity]
    FOREIGN KEY ([DataId])
    REFERENCES [dbo].[DataSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DataHumidity'
CREATE INDEX [IX_FK_DataHumidity]
ON [dbo].[HumiditySet]
    ([DataId]);
GO

-- Creating foreign key on [DataId] in table 'pHSet'
ALTER TABLE [dbo].[pHSet]
ADD CONSTRAINT [FK_DatapH]
    FOREIGN KEY ([DataId])
    REFERENCES [dbo].[DataSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DatapH'
CREATE INDEX [IX_FK_DatapH]
ON [dbo].[pHSet]
    ([DataId]);
GO

-- Creating foreign key on [DataId] in table 'TemperatureSet'
ALTER TABLE [dbo].[TemperatureSet]
ADD CONSTRAINT [FK_DataTemperature]
    FOREIGN KEY ([DataId])
    REFERENCES [dbo].[DataSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DataTemperature'
CREATE INDEX [IX_FK_DataTemperature]
ON [dbo].[TemperatureSet]
    ([DataId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------