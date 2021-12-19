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

CREATE TABLE [Clientes] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(40) NOT NULL,
    [Endereco] nvarchar(200) NOT NULL,
    [Telefone] nvarchar(11) NOT NULL,
    [CPF] char(11) NOT NULL,
    [Sexo] char(1) NULL,
    [Idade] int NOT NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Destinos] (
    [Id] int NOT NULL IDENTITY,
    [Titulo] nvarchar(20) NOT NULL,
    [Descricao] nvarchar(200) NOT NULL,
    [Tipo] nvarchar(3) NULL,
    [Promo] nvarchar(3) NULL,
    [Preco] money NOT NULL,
    CONSTRAINT [PK_Destinos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Pacotes] (
    [Id] int NOT NULL IDENTITY,
    [Id_cliente] int NOT NULL,
    [Id_destino] int NOT NULL,
    [DataCompra] date NOT NULL,
    [DataViagem] date NOT NULL,
    [Preco] money NOT NULL,
    CONSTRAINT [PK_Pacotes] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211218070946_SegundaMigrac', N'5.0.13');
GO

COMMIT;
GO

