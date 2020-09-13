IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Escola] (
    [Id] uniqueidentifier NOT NULL ,
    [Nome] nvarchar(max) NULL,
    CONSTRAINT [PK_Escola] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Alunos] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(max) NULL,
    [DataNascimento] datetime2 NOT NULL,
    [EscolaId] uniqueidentifier NULL,
    CONSTRAINT [PK_Alunos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Alunos_Escola_EscolaId] FOREIGN KEY ([EscolaId]) REFERENCES [Escola] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [EscolasAlunos] (
    [Id] uniqueidentifier NOT NULL,
    [AlunoId] uniqueidentifier NULL,
    [IdAluno] uniqueidentifier NOT NULL,
    [EscolaId] uniqueidentifier NULL,
    [IdEscola] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_EscolasAlunos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EscolasAlunos_Alunos_AlunoId] FOREIGN KEY ([AlunoId]) REFERENCES [Alunos] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EscolasAlunos_Escola_EscolaId] FOREIGN KEY ([EscolaId]) REFERENCES [Escola] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Alunos_EscolaId] ON [Alunos] ([EscolaId]);

GO

CREATE INDEX [IX_EscolasAlunos_AlunoId] ON [EscolasAlunos] ([AlunoId]);

GO

CREATE INDEX [IX_EscolasAlunos_EscolaId] ON [EscolasAlunos] ([EscolaId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200909145853_InitialCreate', N'3.1.8');

GO

