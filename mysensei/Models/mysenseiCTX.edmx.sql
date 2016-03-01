
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/04/2015 10:57:20
-- Generated from EDMX file: C:\mysenseigit2\mysensei\Models\mysenseiCTX.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [mysensei];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PersonCourse1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourseSet] DROP CONSTRAINT [FK_PersonCourse1];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonCourse_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonCourse] DROP CONSTRAINT [FK_PersonCourse_Person];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonCourse_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonCourse] DROP CONSTRAINT [FK_PersonCourse_Course];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseTag_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourseTag] DROP CONSTRAINT [FK_CourseTag_Course];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseTag_Tag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourseTag] DROP CONSTRAINT [FK_CourseTag_Tag];
GO
IF OBJECT_ID(N'[dbo].[FK_LocationCityPerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonSet] DROP CONSTRAINT [FK_LocationCityPerson];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonRating]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RatingSet] DROP CONSTRAINT [FK_PersonRating];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseRating]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RatingSet] DROP CONSTRAINT [FK_CourseRating];
GO
IF OBJECT_ID(N'[dbo].[FK_TagTagGroup_Tag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TagTagGroup] DROP CONSTRAINT [FK_TagTagGroup_Tag];
GO
IF OBJECT_ID(N'[dbo].[FK_TagTagGroup_TagGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TagTagGroup] DROP CONSTRAINT [FK_TagTagGroup_TagGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonChat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChatSet] DROP CONSTRAINT [FK_PersonChat];
GO
IF OBJECT_ID(N'[dbo].[FK_ChatRoomCourse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChatRoomSet] DROP CONSTRAINT [FK_ChatRoomCourse];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonChatRoom_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonChatRoom] DROP CONSTRAINT [FK_PersonChatRoom_Person];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonChatRoom_ChatRoom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonChatRoom] DROP CONSTRAINT [FK_PersonChatRoom_ChatRoom];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonChatRoom1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChatRoomSet] DROP CONSTRAINT [FK_PersonChatRoom1];
GO
IF OBJECT_ID(N'[dbo].[FK_ChatRoomChat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChatSet] DROP CONSTRAINT [FK_ChatRoomChat];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonLogChatRead]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LogChatReadSet] DROP CONSTRAINT [FK_PersonLogChatRead];
GO
IF OBJECT_ID(N'[dbo].[FK_ChatLogChatRead]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LogChatReadSet] DROP CONSTRAINT [FK_ChatLogChatRead];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PersonSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonSet];
GO
IF OBJECT_ID(N'[dbo].[CourseSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourseSet];
GO
IF OBJECT_ID(N'[dbo].[TagSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TagSet];
GO
IF OBJECT_ID(N'[dbo].[LocationCitySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LocationCitySet];
GO
IF OBJECT_ID(N'[dbo].[LocationGroupSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LocationGroupSet];
GO
IF OBJECT_ID(N'[dbo].[RatingSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RatingSet];
GO
IF OBJECT_ID(N'[dbo].[AdministratorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdministratorSet];
GO
IF OBJECT_ID(N'[dbo].[TagGroupSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TagGroupSet];
GO
IF OBJECT_ID(N'[dbo].[ChatSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChatSet];
GO
IF OBJECT_ID(N'[dbo].[ChatRoomSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChatRoomSet];
GO
IF OBJECT_ID(N'[dbo].[LogChatReadSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LogChatReadSet];
GO
IF OBJECT_ID(N'[dbo].[PersonCourse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonCourse];
GO
IF OBJECT_ID(N'[dbo].[CourseTag]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourseTag];
GO
IF OBJECT_ID(N'[dbo].[TagTagGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TagTagGroup];
GO
IF OBJECT_ID(N'[dbo].[PersonChatRoom]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonChatRoom];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PersonSet'
CREATE TABLE [dbo].[PersonSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NULL,
    [LastName] nvarchar(max)  NULL,
    [Address] nvarchar(max)  NULL,
    [Zipcode] smallint  NULL,
    [Phone] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [Username] nvarchar(max)  NULL,
    [Password] nvarchar(max)  NULL,
    [Image] nvarchar(max)  NULL,
    [Active] bit  NOT NULL,
    [DateCreated] datetime  NULL,
    [LocationCity_Id] int  NULL
);
GO

-- Creating table 'CourseSet'
CREATE TABLE [dbo].[CourseSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [PersonId] int  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Image] nvarchar(max)  NULL,
    [Active] bit  NOT NULL,
    [DateCreated] datetime  NULL
);
GO

-- Creating table 'TagSet'
CREATE TABLE [dbo].[TagSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'LocationCitySet'
CREATE TABLE [dbo].[LocationCitySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ZipcodeStart] smallint  NULL,
    [ZipcodeEnd] smallint  NULL,
    [City] nvarchar(max)  NULL
);
GO

-- Creating table 'LocationGroupSet'
CREATE TABLE [dbo].[LocationGroupSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ZipcodeStart] smallint  NULL,
    [ZipcodeEnd] smallint  NULL
);
GO

-- Creating table 'RatingSet'
CREATE TABLE [dbo].[RatingSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Stars] smallint  NULL,
    [Info] nvarchar(max)  NULL,
    [CourseId] int  NOT NULL,
    [Person_Id] int  NOT NULL
);
GO

-- Creating table 'AdministratorSet'
CREATE TABLE [dbo].[AdministratorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [UserName] nvarchar(max)  NULL,
    [Password] nvarchar(max)  NULL,
    [Image] nvarchar(max)  NULL,
    [Active] bit  NULL,
    [DateCreated] datetime  NULL
);
GO

-- Creating table 'TagGroupSet'
CREATE TABLE [dbo].[TagGroupSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL
);
GO

-- Creating table 'ChatSet'
CREATE TABLE [dbo].[ChatSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Message] nvarchar(max)  NULL,
    [PersonId] int  NOT NULL,
    [ChatRoomId] int  NOT NULL,
    [DateCreated] datetime  NOT NULL
);
GO

-- Creating table 'ChatRoomSet'
CREATE TABLE [dbo].[ChatRoomSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [PersonId] int  NOT NULL,
    [Active] bit  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [Course_Id] int  NULL
);
GO

-- Creating table 'LogChatReadSet'
CREATE TABLE [dbo].[LogChatReadSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [PersonId] int  NOT NULL,
    [ChatId] int  NOT NULL
);
GO

-- Creating table 'PersonCourse'
CREATE TABLE [dbo].[PersonCourse] (
    [Student_Id] int  NOT NULL,
    [StudentCourse_Id] int  NOT NULL
);
GO

-- Creating table 'CourseTag'
CREATE TABLE [dbo].[CourseTag] (
    [Course_Id] int  NOT NULL,
    [Tag_Id] int  NOT NULL
);
GO

-- Creating table 'TagTagGroup'
CREATE TABLE [dbo].[TagTagGroup] (
    [Tag_Id] int  NOT NULL,
    [TagGroup_Id] int  NOT NULL
);
GO

-- Creating table 'PersonChatRoom'
CREATE TABLE [dbo].[PersonChatRoom] (
    [Person_Id] int  NOT NULL,
    [ChatRoom_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PersonSet'
ALTER TABLE [dbo].[PersonSet]
ADD CONSTRAINT [PK_PersonSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CourseSet'
ALTER TABLE [dbo].[CourseSet]
ADD CONSTRAINT [PK_CourseSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TagSet'
ALTER TABLE [dbo].[TagSet]
ADD CONSTRAINT [PK_TagSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LocationCitySet'
ALTER TABLE [dbo].[LocationCitySet]
ADD CONSTRAINT [PK_LocationCitySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LocationGroupSet'
ALTER TABLE [dbo].[LocationGroupSet]
ADD CONSTRAINT [PK_LocationGroupSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RatingSet'
ALTER TABLE [dbo].[RatingSet]
ADD CONSTRAINT [PK_RatingSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AdministratorSet'
ALTER TABLE [dbo].[AdministratorSet]
ADD CONSTRAINT [PK_AdministratorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TagGroupSet'
ALTER TABLE [dbo].[TagGroupSet]
ADD CONSTRAINT [PK_TagGroupSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ChatSet'
ALTER TABLE [dbo].[ChatSet]
ADD CONSTRAINT [PK_ChatSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ChatRoomSet'
ALTER TABLE [dbo].[ChatRoomSet]
ADD CONSTRAINT [PK_ChatRoomSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LogChatReadSet'
ALTER TABLE [dbo].[LogChatReadSet]
ADD CONSTRAINT [PK_LogChatReadSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Student_Id], [StudentCourse_Id] in table 'PersonCourse'
ALTER TABLE [dbo].[PersonCourse]
ADD CONSTRAINT [PK_PersonCourse]
    PRIMARY KEY CLUSTERED ([Student_Id], [StudentCourse_Id] ASC);
GO

-- Creating primary key on [Course_Id], [Tag_Id] in table 'CourseTag'
ALTER TABLE [dbo].[CourseTag]
ADD CONSTRAINT [PK_CourseTag]
    PRIMARY KEY CLUSTERED ([Course_Id], [Tag_Id] ASC);
GO

-- Creating primary key on [Tag_Id], [TagGroup_Id] in table 'TagTagGroup'
ALTER TABLE [dbo].[TagTagGroup]
ADD CONSTRAINT [PK_TagTagGroup]
    PRIMARY KEY CLUSTERED ([Tag_Id], [TagGroup_Id] ASC);
GO

-- Creating primary key on [Person_Id], [ChatRoom_Id] in table 'PersonChatRoom'
ALTER TABLE [dbo].[PersonChatRoom]
ADD CONSTRAINT [PK_PersonChatRoom]
    PRIMARY KEY CLUSTERED ([Person_Id], [ChatRoom_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PersonId] in table 'CourseSet'
ALTER TABLE [dbo].[CourseSet]
ADD CONSTRAINT [FK_PersonCourse1]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonCourse1'
CREATE INDEX [IX_FK_PersonCourse1]
ON [dbo].[CourseSet]
    ([PersonId]);
GO

-- Creating foreign key on [Student_Id] in table 'PersonCourse'
ALTER TABLE [dbo].[PersonCourse]
ADD CONSTRAINT [FK_PersonCourse_Person]
    FOREIGN KEY ([Student_Id])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [StudentCourse_Id] in table 'PersonCourse'
ALTER TABLE [dbo].[PersonCourse]
ADD CONSTRAINT [FK_PersonCourse_Course]
    FOREIGN KEY ([StudentCourse_Id])
    REFERENCES [dbo].[CourseSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonCourse_Course'
CREATE INDEX [IX_FK_PersonCourse_Course]
ON [dbo].[PersonCourse]
    ([StudentCourse_Id]);
GO

-- Creating foreign key on [Course_Id] in table 'CourseTag'
ALTER TABLE [dbo].[CourseTag]
ADD CONSTRAINT [FK_CourseTag_Course]
    FOREIGN KEY ([Course_Id])
    REFERENCES [dbo].[CourseSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Tag_Id] in table 'CourseTag'
ALTER TABLE [dbo].[CourseTag]
ADD CONSTRAINT [FK_CourseTag_Tag]
    FOREIGN KEY ([Tag_Id])
    REFERENCES [dbo].[TagSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseTag_Tag'
CREATE INDEX [IX_FK_CourseTag_Tag]
ON [dbo].[CourseTag]
    ([Tag_Id]);
GO

-- Creating foreign key on [LocationCity_Id] in table 'PersonSet'
ALTER TABLE [dbo].[PersonSet]
ADD CONSTRAINT [FK_LocationCityPerson]
    FOREIGN KEY ([LocationCity_Id])
    REFERENCES [dbo].[LocationCitySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LocationCityPerson'
CREATE INDEX [IX_FK_LocationCityPerson]
ON [dbo].[PersonSet]
    ([LocationCity_Id]);
GO

-- Creating foreign key on [Person_Id] in table 'RatingSet'
ALTER TABLE [dbo].[RatingSet]
ADD CONSTRAINT [FK_PersonRating]
    FOREIGN KEY ([Person_Id])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonRating'
CREATE INDEX [IX_FK_PersonRating]
ON [dbo].[RatingSet]
    ([Person_Id]);
GO

-- Creating foreign key on [CourseId] in table 'RatingSet'
ALTER TABLE [dbo].[RatingSet]
ADD CONSTRAINT [FK_CourseRating]
    FOREIGN KEY ([CourseId])
    REFERENCES [dbo].[CourseSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseRating'
CREATE INDEX [IX_FK_CourseRating]
ON [dbo].[RatingSet]
    ([CourseId]);
GO

-- Creating foreign key on [Tag_Id] in table 'TagTagGroup'
ALTER TABLE [dbo].[TagTagGroup]
ADD CONSTRAINT [FK_TagTagGroup_Tag]
    FOREIGN KEY ([Tag_Id])
    REFERENCES [dbo].[TagSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TagGroup_Id] in table 'TagTagGroup'
ALTER TABLE [dbo].[TagTagGroup]
ADD CONSTRAINT [FK_TagTagGroup_TagGroup]
    FOREIGN KEY ([TagGroup_Id])
    REFERENCES [dbo].[TagGroupSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TagTagGroup_TagGroup'
CREATE INDEX [IX_FK_TagTagGroup_TagGroup]
ON [dbo].[TagTagGroup]
    ([TagGroup_Id]);
GO

-- Creating foreign key on [PersonId] in table 'ChatSet'
ALTER TABLE [dbo].[ChatSet]
ADD CONSTRAINT [FK_PersonChat]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonChat'
CREATE INDEX [IX_FK_PersonChat]
ON [dbo].[ChatSet]
    ([PersonId]);
GO

-- Creating foreign key on [Course_Id] in table 'ChatRoomSet'
ALTER TABLE [dbo].[ChatRoomSet]
ADD CONSTRAINT [FK_ChatRoomCourse]
    FOREIGN KEY ([Course_Id])
    REFERENCES [dbo].[CourseSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChatRoomCourse'
CREATE INDEX [IX_FK_ChatRoomCourse]
ON [dbo].[ChatRoomSet]
    ([Course_Id]);
GO

-- Creating foreign key on [Person_Id] in table 'PersonChatRoom'
ALTER TABLE [dbo].[PersonChatRoom]
ADD CONSTRAINT [FK_PersonChatRoom_Person]
    FOREIGN KEY ([Person_Id])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ChatRoom_Id] in table 'PersonChatRoom'
ALTER TABLE [dbo].[PersonChatRoom]
ADD CONSTRAINT [FK_PersonChatRoom_ChatRoom]
    FOREIGN KEY ([ChatRoom_Id])
    REFERENCES [dbo].[ChatRoomSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonChatRoom_ChatRoom'
CREATE INDEX [IX_FK_PersonChatRoom_ChatRoom]
ON [dbo].[PersonChatRoom]
    ([ChatRoom_Id]);
GO

-- Creating foreign key on [PersonId] in table 'ChatRoomSet'
ALTER TABLE [dbo].[ChatRoomSet]
ADD CONSTRAINT [FK_PersonChatRoom1]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonChatRoom1'
CREATE INDEX [IX_FK_PersonChatRoom1]
ON [dbo].[ChatRoomSet]
    ([PersonId]);
GO

-- Creating foreign key on [ChatRoomId] in table 'ChatSet'
ALTER TABLE [dbo].[ChatSet]
ADD CONSTRAINT [FK_ChatRoomChat]
    FOREIGN KEY ([ChatRoomId])
    REFERENCES [dbo].[ChatRoomSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChatRoomChat'
CREATE INDEX [IX_FK_ChatRoomChat]
ON [dbo].[ChatSet]
    ([ChatRoomId]);
GO

-- Creating foreign key on [PersonId] in table 'LogChatReadSet'
ALTER TABLE [dbo].[LogChatReadSet]
ADD CONSTRAINT [FK_PersonLogChatRead]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonLogChatRead'
CREATE INDEX [IX_FK_PersonLogChatRead]
ON [dbo].[LogChatReadSet]
    ([PersonId]);
GO

-- Creating foreign key on [ChatId] in table 'LogChatReadSet'
ALTER TABLE [dbo].[LogChatReadSet]
ADD CONSTRAINT [FK_ChatLogChatRead]
    FOREIGN KEY ([ChatId])
    REFERENCES [dbo].[ChatSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChatLogChatRead'
CREATE INDEX [IX_FK_ChatLogChatRead]
ON [dbo].[LogChatReadSet]
    ([ChatId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------