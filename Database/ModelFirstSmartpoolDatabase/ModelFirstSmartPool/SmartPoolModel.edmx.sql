
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/07/2016 01:36:23
-- Generated from EDMX file: C:\cygwin64\home\Mr. Derp-lappitoppi\git-repos\I4PRJ\Database\ModelFirstSmartpoolDatabase\ModelFirstSmartPool\SmartPoolModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ModelFirst.SmartPool];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PoolMonitorUnit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MonitorUnits] DROP CONSTRAINT [FK_PoolMonitorUnit];
GO
IF OBJECT_ID(N'[dbo].[FK_PoolPoolDimensions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pools] DROP CONSTRAINT [FK_PoolPoolDimensions];
GO
IF OBJECT_ID(N'[dbo].[FK_ResidenceValueConstraints]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Residences] DROP CONSTRAINT [FK_ResidenceValueConstraints];
GO
IF OBJECT_ID(N'[dbo].[FK_UserFullName]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_UserFullName];
GO
IF OBJECT_ID(N'[dbo].[FK_UserPool]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pools] DROP CONSTRAINT [FK_UserPool];
GO
IF OBJECT_ID(N'[dbo].[FK_UserResidence]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Residences] DROP CONSTRAINT [FK_UserResidence];
GO
IF OBJECT_ID(N'[dbo].[FK_ValueConstraintsChlorine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ValueConstraints] DROP CONSTRAINT [FK_ValueConstraintsChlorine];
GO
IF OBJECT_ID(N'[dbo].[FK_ValueConstraintspH]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ValueConstraints] DROP CONSTRAINT [FK_ValueConstraintspH];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ChlorineValues]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChlorineValues];
GO
IF OBJECT_ID(N'[dbo].[FullNames]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FullNames];
GO
IF OBJECT_ID(N'[dbo].[MonitorUnits]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MonitorUnits];
GO
IF OBJECT_ID(N'[dbo].[pHs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[pHs];
GO
IF OBJECT_ID(N'[dbo].[PoolDimensions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PoolDimensions];
GO
IF OBJECT_ID(N'[dbo].[Pools]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pools];
GO
IF OBJECT_ID(N'[dbo].[Residences]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Residences];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[ValueConstraints]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ValueConstraints];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [FullName_Id] int  NOT NULL
);
GO

-- Creating table 'Pools'
CREATE TABLE [dbo].[Pools] (
    [PoolId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [UserUserId] int  NOT NULL,
    [PoolDimension_PoolDimensionsId] int  NOT NULL
);
GO

-- Creating table 'FullNames'
CREATE TABLE [dbo].[FullNames] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserUserId] int  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [MiddleName] nvarchar(max)  NULL,
    [LastName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MonitorUnits'
CREATE TABLE [dbo].[MonitorUnits] (
    [MonitorUnitId] int IDENTITY(1,1) NOT NULL,
    [PoolPoolId] int  NOT NULL,
    [SerialNo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Residences'
CREATE TABLE [dbo].[Residences] (
    [AddressId] int IDENTITY(1,1) NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NULL,
    [ZipCode] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [UserUserId] int  NOT NULL,
    [ValueConstraint_ValueConstraintsId] int  NOT NULL
);
GO

-- Creating table 'PoolDimensions'
CREATE TABLE [dbo].[PoolDimensions] (
    [PoolDimensionsId] int IDENTITY(1,1) NOT NULL,
    [Length] int  NOT NULL,
    [Width] int  NOT NULL,
    [Depth] int  NOT NULL
);
GO

-- Creating table 'ValueConstraints'
CREATE TABLE [dbo].[ValueConstraints] (
    [ValueConstraintsId] int IDENTITY(1,1) NOT NULL,
    [pH_pHValueId] int  NOT NULL,
    [ChlorineConstraint_ChlorineValueId] int  NOT NULL
);
GO

-- Creating table 'pHs'
CREATE TABLE [dbo].[pHs] (
    [pHValueId] int IDENTITY(1,1) NOT NULL,
    [MinimumPhValue] nvarchar(max)  NOT NULL,
    [MaximumPhValue] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ChlorineValues'
CREATE TABLE [dbo].[ChlorineValues] (
    [ChlorineValueId] int IDENTITY(1,1) NOT NULL,
    [MinimumFreeChlorine] nvarchar(max)  NOT NULL,
    [MaximumFreeChlorine] nvarchar(max)  NOT NULL,
    [MinimumBondedChlorine] nvarchar(max)  NOT NULL,
    [MaximumBondedChlorine] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [PoolId] in table 'Pools'
ALTER TABLE [dbo].[Pools]
ADD CONSTRAINT [PK_Pools]
    PRIMARY KEY CLUSTERED ([PoolId] ASC);
GO

-- Creating primary key on [Id] in table 'FullNames'
ALTER TABLE [dbo].[FullNames]
ADD CONSTRAINT [PK_FullNames]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MonitorUnitId] in table 'MonitorUnits'
ALTER TABLE [dbo].[MonitorUnits]
ADD CONSTRAINT [PK_MonitorUnits]
    PRIMARY KEY CLUSTERED ([MonitorUnitId] ASC);
GO

-- Creating primary key on [AddressId] in table 'Residences'
ALTER TABLE [dbo].[Residences]
ADD CONSTRAINT [PK_Residences]
    PRIMARY KEY CLUSTERED ([AddressId] ASC);
GO

-- Creating primary key on [PoolDimensionsId] in table 'PoolDimensions'
ALTER TABLE [dbo].[PoolDimensions]
ADD CONSTRAINT [PK_PoolDimensions]
    PRIMARY KEY CLUSTERED ([PoolDimensionsId] ASC);
GO

-- Creating primary key on [ValueConstraintsId] in table 'ValueConstraints'
ALTER TABLE [dbo].[ValueConstraints]
ADD CONSTRAINT [PK_ValueConstraints]
    PRIMARY KEY CLUSTERED ([ValueConstraintsId] ASC);
GO

-- Creating primary key on [pHValueId] in table 'pHs'
ALTER TABLE [dbo].[pHs]
ADD CONSTRAINT [PK_pHs]
    PRIMARY KEY CLUSTERED ([pHValueId] ASC);
GO

-- Creating primary key on [ChlorineValueId] in table 'ChlorineValues'
ALTER TABLE [dbo].[ChlorineValues]
ADD CONSTRAINT [PK_ChlorineValues]
    PRIMARY KEY CLUSTERED ([ChlorineValueId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserUserId] in table 'Pools'
ALTER TABLE [dbo].[Pools]
ADD CONSTRAINT [FK_UserPool]
    FOREIGN KEY ([UserUserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPool'
CREATE INDEX [IX_FK_UserPool]
ON [dbo].[Pools]
    ([UserUserId]);
GO

-- Creating foreign key on [PoolPoolId] in table 'MonitorUnits'
ALTER TABLE [dbo].[MonitorUnits]
ADD CONSTRAINT [FK_PoolMonitorUnit]
    FOREIGN KEY ([PoolPoolId])
    REFERENCES [dbo].[Pools]
        ([PoolId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PoolMonitorUnit'
CREATE INDEX [IX_FK_PoolMonitorUnit]
ON [dbo].[MonitorUnits]
    ([PoolPoolId]);
GO

-- Creating foreign key on [UserUserId] in table 'Residences'
ALTER TABLE [dbo].[Residences]
ADD CONSTRAINT [FK_UserResidence]
    FOREIGN KEY ([UserUserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserResidence'
CREATE INDEX [IX_FK_UserResidence]
ON [dbo].[Residences]
    ([UserUserId]);
GO

-- Creating foreign key on [FullName_Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_UserFullName]
    FOREIGN KEY ([FullName_Id])
    REFERENCES [dbo].[FullNames]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserFullName'
CREATE INDEX [IX_FK_UserFullName]
ON [dbo].[Users]
    ([FullName_Id]);
GO

-- Creating foreign key on [PoolDimension_PoolDimensionsId] in table 'Pools'
ALTER TABLE [dbo].[Pools]
ADD CONSTRAINT [FK_PoolPoolDimensions]
    FOREIGN KEY ([PoolDimension_PoolDimensionsId])
    REFERENCES [dbo].[PoolDimensions]
        ([PoolDimensionsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PoolPoolDimensions'
CREATE INDEX [IX_FK_PoolPoolDimensions]
ON [dbo].[Pools]
    ([PoolDimension_PoolDimensionsId]);
GO

-- Creating foreign key on [pH_pHValueId] in table 'ValueConstraints'
ALTER TABLE [dbo].[ValueConstraints]
ADD CONSTRAINT [FK_ValueConstraintspH]
    FOREIGN KEY ([pH_pHValueId])
    REFERENCES [dbo].[pHs]
        ([pHValueId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ValueConstraintspH'
CREATE INDEX [IX_FK_ValueConstraintspH]
ON [dbo].[ValueConstraints]
    ([pH_pHValueId]);
GO

-- Creating foreign key on [ChlorineConstraint_ChlorineValueId] in table 'ValueConstraints'
ALTER TABLE [dbo].[ValueConstraints]
ADD CONSTRAINT [FK_ValueConstraintsChlorine]
    FOREIGN KEY ([ChlorineConstraint_ChlorineValueId])
    REFERENCES [dbo].[ChlorineValues]
        ([ChlorineValueId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ValueConstraintsChlorine'
CREATE INDEX [IX_FK_ValueConstraintsChlorine]
ON [dbo].[ValueConstraints]
    ([ChlorineConstraint_ChlorineValueId]);
GO

-- Creating foreign key on [ValueConstraint_ValueConstraintsId] in table 'Residences'
ALTER TABLE [dbo].[Residences]
ADD CONSTRAINT [FK_ResidenceValueConstraints]
    FOREIGN KEY ([ValueConstraint_ValueConstraintsId])
    REFERENCES [dbo].[ValueConstraints]
        ([ValueConstraintsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ResidenceValueConstraints'
CREATE INDEX [IX_FK_ResidenceValueConstraints]
ON [dbo].[Residences]
    ([ValueConstraint_ValueConstraintsId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------