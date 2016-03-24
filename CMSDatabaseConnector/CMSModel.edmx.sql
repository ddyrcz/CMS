
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/24/2016 19:20:57
-- Generated from EDMX file: C:\Users\ddyrcz\Desktop\Programowanie\C#\Projects\CMS Delelopment\CMSDatabaseConnector\CMSDatabaseConnector\CMSDatabaseConnector\CMSModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CMS];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Cars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cars];
GO
IF OBJECT_ID(N'[dbo].[Logs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Logs];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Cars'
CREATE TABLE [dbo].[Cars] (
    [CarID] int  NOT NULL,
    [Brand] nchar(50)  NULL,
    [RegistrationNumber] nchar(50)  NULL,
    [VIN_Number] nchar(50)  NULL,
    [TermTechnicalResearch] datetime  NULL,
    [TechLegalization] datetime  NULL,
    [LiftUDT] datetime  NULL,
    [OCPolicy] datetime  NULL,
    [ACPolicy] datetime  NULL
);
GO

-- Creating table 'Logs'
CREATE TABLE [dbo].[Logs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Message] nvarchar(200)  NOT NULL,
    [StackTrace] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'OcInstallment'
CREATE TABLE [dbo].[OcInstallment] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PaymentDate] datetime  NOT NULL,
    [IsPaid] bit  NOT NULL,
    [CarID] int  NOT NULL
);
GO

-- Creating table 'AcInstallment'
CREATE TABLE [dbo].[AcInstallment] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PaymentDate] datetime  NOT NULL,
    [IsPaid] bit  NOT NULL,
    [CarID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CarID] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [PK_Cars]
    PRIMARY KEY CLUSTERED ([CarID] ASC);
GO

-- Creating primary key on [Id] in table 'Logs'
ALTER TABLE [dbo].[Logs]
ADD CONSTRAINT [PK_Logs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OcInstallment'
ALTER TABLE [dbo].[OcInstallment]
ADD CONSTRAINT [PK_OcInstallment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AcInstallment'
ALTER TABLE [dbo].[AcInstallment]
ADD CONSTRAINT [PK_AcInstallment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CarID] in table 'AcInstallment'
ALTER TABLE [dbo].[AcInstallment]
ADD CONSTRAINT [FK_CarAcInstallment]
    FOREIGN KEY ([CarID])
    REFERENCES [dbo].[Cars]
        ([CarID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarAcInstallment'
CREATE INDEX [IX_FK_CarAcInstallment]
ON [dbo].[AcInstallment]
    ([CarID]);
GO

-- Creating foreign key on [CarID] in table 'OcInstallment'
ALTER TABLE [dbo].[OcInstallment]
ADD CONSTRAINT [FK_CarOcInstallment]
    FOREIGN KEY ([CarID])
    REFERENCES [dbo].[Cars]
        ([CarID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarOcInstallment'
CREATE INDEX [IX_FK_CarOcInstallment]
ON [dbo].[OcInstallment]
    ([CarID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------