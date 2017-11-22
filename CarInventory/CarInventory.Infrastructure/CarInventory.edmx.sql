
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/22/2017 09:29:32
-- Generated from EDMX file: E:\Project\GetVentive Team\Car-Inventory-Crud\CarInventory\CarInventory.Infrastructure\CarInventory.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CarsInventory];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Cars_Users_Mapping_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cars_Users_Mapping] DROP CONSTRAINT [FK_Cars_Users_Mapping_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_Cars_Users_Mapping_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cars_Users_Mapping] DROP CONSTRAINT [FK_Cars_Users_Mapping_Users];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Cars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cars];
GO
IF OBJECT_ID(N'[dbo].[Cars_Users_Mapping]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cars_Users_Mapping];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Cars'
CREATE TABLE [dbo].[Cars] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Brand] nvarchar(50)  NULL,
    [Model] nvarchar(50)  NULL,
    [Year] int  NULL,
    [Price] decimal(18,0)  NULL,
    [New] bit  NULL
);
GO

-- Creating table 'Cars_Users_Mapping'
CREATE TABLE [dbo].[Cars_Users_Mapping] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CarsId] int  NULL,
    [UsersId] int  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NULL,
    [Password] nvarchar(max)  NULL,
    [Email] nvarchar(50)  NULL,
    [IsActive] bit  NULL,
    [LastLogin] datetime  NULL,
    [IsEmailVerified] bit  NULL,
    [ContactNumber] nvarchar(15)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [PK_Cars]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cars_Users_Mapping'
ALTER TABLE [dbo].[Cars_Users_Mapping]
ADD CONSTRAINT [PK_Cars_Users_Mapping]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CarsId] in table 'Cars_Users_Mapping'
ALTER TABLE [dbo].[Cars_Users_Mapping]
ADD CONSTRAINT [FK_Cars_Users_Mapping_Cars]
    FOREIGN KEY ([CarsId])
    REFERENCES [dbo].[Cars]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cars_Users_Mapping_Cars'
CREATE INDEX [IX_FK_Cars_Users_Mapping_Cars]
ON [dbo].[Cars_Users_Mapping]
    ([CarsId]);
GO

-- Creating foreign key on [UsersId] in table 'Cars_Users_Mapping'
ALTER TABLE [dbo].[Cars_Users_Mapping]
ADD CONSTRAINT [FK_Cars_Users_Mapping_Users]
    FOREIGN KEY ([UsersId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cars_Users_Mapping_Users'
CREATE INDEX [IX_FK_Cars_Users_Mapping_Users]
ON [dbo].[Cars_Users_Mapping]
    ([UsersId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------