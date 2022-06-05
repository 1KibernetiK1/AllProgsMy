
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/01/2022 09:58:19
-- Generated from EDMX file: E:\SergPAv\Программирование\Апрель\ConsoleEntityFramework\ConsoleEntityFramework\DataAccessLayer\ModelMovies.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Moviedb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Movies'
CREATE TABLE [dbo].[Movies] (
    [MovieId] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(200)  NOT NULL,
    [Year] int  NOT NULL
);
GO

-- Creating table 'PersonSet'
CREATE TABLE [dbo].[PersonSet] (
    [PersonId] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(200)  NOT NULL,
    [LastName] nvarchar(250)  NOT NULL,
    [PhotoUrl] nvarchar(250)  NOT NULL
);
GO

-- Creating table 'Genres'
CREATE TABLE [dbo].[Genres] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MovieGenre'
CREATE TABLE [dbo].[MovieGenre] (
    [MovieOfGenres_MovieId] int  NOT NULL,
    [GenreofMovies_Id] int  NOT NULL
);
GO

-- Creating table 'MovieActor'
CREATE TABLE [dbo].[MovieActor] (
    [ActorofMovies_MovieId] int  NOT NULL,
    [Actors_PersonId] int  NOT NULL
);
GO

-- Creating table 'MovieDirector'
CREATE TABLE [dbo].[MovieDirector] (
    [DirectorofMovies_MovieId] int  NOT NULL,
    [Directors_PersonId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MovieId] in table 'Movies'
ALTER TABLE [dbo].[Movies]
ADD CONSTRAINT [PK_Movies]
    PRIMARY KEY CLUSTERED ([MovieId] ASC);
GO

-- Creating primary key on [PersonId] in table 'PersonSet'
ALTER TABLE [dbo].[PersonSet]
ADD CONSTRAINT [PK_PersonSet]
    PRIMARY KEY CLUSTERED ([PersonId] ASC);
GO

-- Creating primary key on [Id] in table 'Genres'
ALTER TABLE [dbo].[Genres]
ADD CONSTRAINT [PK_Genres]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MovieOfGenres_MovieId], [GenreofMovies_Id] in table 'MovieGenre'
ALTER TABLE [dbo].[MovieGenre]
ADD CONSTRAINT [PK_MovieGenre]
    PRIMARY KEY CLUSTERED ([MovieOfGenres_MovieId], [GenreofMovies_Id] ASC);
GO

-- Creating primary key on [ActorofMovies_MovieId], [Actors_PersonId] in table 'MovieActor'
ALTER TABLE [dbo].[MovieActor]
ADD CONSTRAINT [PK_MovieActor]
    PRIMARY KEY CLUSTERED ([ActorofMovies_MovieId], [Actors_PersonId] ASC);
GO

-- Creating primary key on [DirectorofMovies_MovieId], [Directors_PersonId] in table 'MovieDirector'
ALTER TABLE [dbo].[MovieDirector]
ADD CONSTRAINT [PK_MovieDirector]
    PRIMARY KEY CLUSTERED ([DirectorofMovies_MovieId], [Directors_PersonId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MovieOfGenres_MovieId] in table 'MovieGenre'
ALTER TABLE [dbo].[MovieGenre]
ADD CONSTRAINT [FK_MovieGenre_Movie]
    FOREIGN KEY ([MovieOfGenres_MovieId])
    REFERENCES [dbo].[Movies]
        ([MovieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [GenreofMovies_Id] in table 'MovieGenre'
ALTER TABLE [dbo].[MovieGenre]
ADD CONSTRAINT [FK_MovieGenre_Genre]
    FOREIGN KEY ([GenreofMovies_Id])
    REFERENCES [dbo].[Genres]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieGenre_Genre'
CREATE INDEX [IX_FK_MovieGenre_Genre]
ON [dbo].[MovieGenre]
    ([GenreofMovies_Id]);
GO

-- Creating foreign key on [ActorofMovies_MovieId] in table 'MovieActor'
ALTER TABLE [dbo].[MovieActor]
ADD CONSTRAINT [FK_MovieActor_Movie]
    FOREIGN KEY ([ActorofMovies_MovieId])
    REFERENCES [dbo].[Movies]
        ([MovieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Actors_PersonId] in table 'MovieActor'
ALTER TABLE [dbo].[MovieActor]
ADD CONSTRAINT [FK_MovieActor_Person]
    FOREIGN KEY ([Actors_PersonId])
    REFERENCES [dbo].[PersonSet]
        ([PersonId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieActor_Person'
CREATE INDEX [IX_FK_MovieActor_Person]
ON [dbo].[MovieActor]
    ([Actors_PersonId]);
GO

-- Creating foreign key on [DirectorofMovies_MovieId] in table 'MovieDirector'
ALTER TABLE [dbo].[MovieDirector]
ADD CONSTRAINT [FK_MovieDirector_Movie]
    FOREIGN KEY ([DirectorofMovies_MovieId])
    REFERENCES [dbo].[Movies]
        ([MovieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Directors_PersonId] in table 'MovieDirector'
ALTER TABLE [dbo].[MovieDirector]
ADD CONSTRAINT [FK_MovieDirector_Person]
    FOREIGN KEY ([Directors_PersonId])
    REFERENCES [dbo].[PersonSet]
        ([PersonId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieDirector_Person'
CREATE INDEX [IX_FK_MovieDirector_Person]
ON [dbo].[MovieDirector]
    ([Directors_PersonId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------