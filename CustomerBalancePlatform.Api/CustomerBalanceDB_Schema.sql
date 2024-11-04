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

CREATE TABLE [AuditTrails] (
    [Id] int NOT NULL IDENTITY,
    [EntityName] nvarchar(max) NULL,
    [Action] nvarchar(max) NULL,
    [PerformedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_AuditTrails] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Customers] (
    [CustomerNumber] nvarchar(450) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NULL,
    [ContactInfo] nvarchar(max) NOT NULL,
    [CurrentBalance] decimal(18,2) NOT NULL,
    [LastTransactionDate] datetime2 NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([CustomerNumber])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241103042244_InitialCreate', N'8.0.0');
GO

COMMIT;
GO

