
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/19/2022 22:05:07
-- Generated from EDMX file: C:\Users\moron\OneDrive - Universidad Veracruzana\7mo semestre\tecnologias para la construccion\Proyecto final\PassThePenServer\DataAccess\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [passthepen];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[fk_idGame]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GamesPlayed] DROP CONSTRAINT [fk_idGame];
GO
IF OBJECT_ID(N'[dbo].[fk_usernamePlayer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GamesPlayed] DROP CONSTRAINT [fk_usernamePlayer];
GO
IF OBJECT_ID(N'[dbo].[fk_usernamePlayer_Friend]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Friends] DROP CONSTRAINT [fk_usernamePlayer_Friend];
GO
IF OBJECT_ID(N'[dbo].[fk_usernamePlayer_FriendRequest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FriendRequest] DROP CONSTRAINT [fk_usernamePlayer_FriendRequest];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FriendRequest]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FriendRequest];
GO
IF OBJECT_ID(N'[dbo].[Friends]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Friends];
GO
IF OBJECT_ID(N'[dbo].[Game]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Game];
GO
IF OBJECT_ID(N'[dbo].[GamesPlayed]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GamesPlayed];
GO
IF OBJECT_ID(N'[dbo].[Player]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Player];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'FriendRequest'
CREATE TABLE [dbo].[FriendRequest] (
    [idRequest] int IDENTITY(1,1) NOT NULL,
    [usernamePlayer] varchar(20)  NOT NULL,
    [friendUsername] varchar(20)  NOT NULL,
    [status] varchar(20)  NOT NULL
);
GO

-- Creating table 'Friends'
CREATE TABLE [dbo].[Friends] (
    [idFriend] int IDENTITY(1,1) NOT NULL,
    [usernamePlayer] varchar(20)  NOT NULL,
    [friendUsername] varchar(20)  NOT NULL
);
GO

-- Creating table 'Game'
CREATE TABLE [dbo].[Game] (
    [idGame] int IDENTITY(1,1) NOT NULL,
    [winner] varchar(20)  NOT NULL
);
GO

-- Creating table 'Player'
CREATE TABLE [dbo].[Player] (
    [username] varchar(20)  NOT NULL,
    [password] varchar(64)  NOT NULL,
    [name] varchar(50)  NOT NULL,
    [lastname] varchar(50)  NOT NULL,
    [email] varchar(100)  NOT NULL,
    [profileImage] varbinary(max)  NOT NULL
);
GO

-- Creating table 'GamesPlayed'
CREATE TABLE [dbo].[GamesPlayed] (
    [Game_idGame] int  NOT NULL,
    [Player_username] varchar(20)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [idRequest], [usernamePlayer] in table 'FriendRequest'
ALTER TABLE [dbo].[FriendRequest]
ADD CONSTRAINT [PK_FriendRequest]
    PRIMARY KEY CLUSTERED ([idRequest], [usernamePlayer] ASC);
GO

-- Creating primary key on [idFriend], [usernamePlayer] in table 'Friends'
ALTER TABLE [dbo].[Friends]
ADD CONSTRAINT [PK_Friends]
    PRIMARY KEY CLUSTERED ([idFriend], [usernamePlayer] ASC);
GO

-- Creating primary key on [idGame] in table 'Game'
ALTER TABLE [dbo].[Game]
ADD CONSTRAINT [PK_Game]
    PRIMARY KEY CLUSTERED ([idGame] ASC);
GO

-- Creating primary key on [username] in table 'Player'
ALTER TABLE [dbo].[Player]
ADD CONSTRAINT [PK_Player]
    PRIMARY KEY CLUSTERED ([username] ASC);
GO

-- Creating primary key on [Game_idGame], [Player_username] in table 'GamesPlayed'
ALTER TABLE [dbo].[GamesPlayed]
ADD CONSTRAINT [PK_GamesPlayed]
    PRIMARY KEY CLUSTERED ([Game_idGame], [Player_username] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [usernamePlayer] in table 'FriendRequest'
ALTER TABLE [dbo].[FriendRequest]
ADD CONSTRAINT [fk_usernamePlayer_FriendRequest]
    FOREIGN KEY ([usernamePlayer])
    REFERENCES [dbo].[Player]
        ([username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_usernamePlayer_FriendRequest'
CREATE INDEX [IX_fk_usernamePlayer_FriendRequest]
ON [dbo].[FriendRequest]
    ([usernamePlayer]);
GO

-- Creating foreign key on [usernamePlayer] in table 'Friends'
ALTER TABLE [dbo].[Friends]
ADD CONSTRAINT [fk_usernamePlayer_Friend]
    FOREIGN KEY ([usernamePlayer])
    REFERENCES [dbo].[Player]
        ([username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_usernamePlayer_Friend'
CREATE INDEX [IX_fk_usernamePlayer_Friend]
ON [dbo].[Friends]
    ([usernamePlayer]);
GO

-- Creating foreign key on [Game_idGame] in table 'GamesPlayed'
ALTER TABLE [dbo].[GamesPlayed]
ADD CONSTRAINT [FK_GamesPlayed_Game]
    FOREIGN KEY ([Game_idGame])
    REFERENCES [dbo].[Game]
        ([idGame])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Player_username] in table 'GamesPlayed'
ALTER TABLE [dbo].[GamesPlayed]
ADD CONSTRAINT [FK_GamesPlayed_Player]
    FOREIGN KEY ([Player_username])
    REFERENCES [dbo].[Player]
        ([username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GamesPlayed_Player'
CREATE INDEX [IX_FK_GamesPlayed_Player]
ON [dbo].[GamesPlayed]
    ([Player_username]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------