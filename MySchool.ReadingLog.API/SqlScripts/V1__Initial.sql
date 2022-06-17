IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Books] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(30) NOT NULL,
    [CreatedBy] nvarchar(30) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedBy] nvarchar(30) NULL,
    [ModifiedDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Students] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(30) NOT NULL,
    [Grade] nvarchar(10) NOT NULL,
    [CreatedBy] nvarchar(30) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedBy] nvarchar(30) NULL,
    [ModifiedDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [BooksRead] (
    [Id] int NOT NULL IDENTITY,
    [BookId] int NOT NULL,
    [StudentId] int NOT NULL,
    [DateRead] datetime2 NOT NULL,
    [CreatedBy] nvarchar(30) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedBy] nvarchar(30) NULL,
    [ModifiedDate] datetime2 NOT NULL,
    CONSTRAINT [PK_BooksRead] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_BooksRead_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BooksRead_Students_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Students] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_BooksRead_BookId] ON [BooksRead] ([BookId]);
GO

CREATE INDEX [IX_BooksRead_StudentId] ON [BooksRead] ([StudentId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210821131031_initialdbsetup', N'5.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Students] ADD [UserId] int NULL;
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(30) NOT NULL,
    [LastName] nvarchar(30) NOT NULL,
    [EmailAddress] nvarchar(30) NOT NULL,
    [Role] int NOT NULL,
    [CreatedBy] nvarchar(30) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedBy] nvarchar(30) NULL,
    [ModifiedDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE INDEX [IX_Students_UserId] ON [Students] ([UserId]);
GO

ALTER TABLE [Students] ADD CONSTRAINT [FK_Students_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211207134745_AddUsers', N'5.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Students] ADD [ParentEmailId] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211208130126_AddParentEmailId', N'5.0.9');
GO

COMMIT;
GO

