IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [DeviceTypes] (
    [DeviceTypeId] nvarchar(450) NOT NULL,
    [DisplayName] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_DeviceTypes] PRIMARY KEY ([DeviceTypeId])
);

GO

CREATE TABLE [GoogleUsers] (
    [GoogleUserId] uniqueidentifier NOT NULL,
    [UserId] nvarchar(max) NULL,
    [Active] bit NOT NULL,
    [ActivationDate] datetime2 NOT NULL,
    CONSTRAINT [PK_GoogleUsers] PRIMARY KEY ([GoogleUserId])
);

GO

CREATE TABLE [Homes] (
    [HomeId] uniqueidentifier NOT NULL,
    [UserId] nvarchar(max) NULL,
    [Name] nvarchar(max) NOT NULL,
    [FullAddress] nvarchar(max) NOT NULL,
    [City] nvarchar(max) NOT NULL,
    [State] nvarchar(max) NOT NULL,
    [Country] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Homes] PRIMARY KEY ([HomeId])
);

GO

CREATE TABLE [Pieces] (
    [PieceId] uniqueidentifier NOT NULL,
    [HomeId] uniqueidentifier NOT NULL,
    [UserId] nvarchar(max) NULL,
    [Name] nvarchar(max) NOT NULL,
    [Type] int NOT NULL,
    [Floor] int NOT NULL,
    CONSTRAINT [PK_Pieces] PRIMARY KEY ([PieceId]),
    CONSTRAINT [FK_Pieces_Homes_HomeId] FOREIGN KEY ([HomeId]) REFERENCES [Homes] ([HomeId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Hubs] (
    [HubId] uniqueidentifier NOT NULL,
    [UserId] nvarchar(max) NOT NULL,
    [HomeId] uniqueidentifier NOT NULL,
    [Hardware] nvarchar(max) NULL,
    [PieceId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Hubs] PRIMARY KEY ([HubId]),
    CONSTRAINT [FK_Hubs_Homes_HomeId] FOREIGN KEY ([HomeId]) REFERENCES [Homes] ([HomeId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Hubs_Pieces_PieceId] FOREIGN KEY ([PieceId]) REFERENCES [Pieces] ([PieceId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Relays] (
    [RelayId] uniqueidentifier NOT NULL,
    [HubId] uniqueidentifier NOT NULL,
    [UserId] nvarchar(max) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [HardWare] nvarchar(max) NULL,
    [ConnectionType] int NOT NULL,
    CONSTRAINT [PK_Relays] PRIMARY KEY ([RelayId]),
    CONSTRAINT [FK_Relays_Hubs_HubId] FOREIGN KEY ([HubId]) REFERENCES [Hubs] ([HubId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Devices] (
    [DeviceId] uniqueidentifier NOT NULL,
    [UserId] nvarchar(max) NULL,
    [RelayId] uniqueidentifier NULL,
    [HubId] uniqueidentifier NOT NULL,
    [PieceId] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [ArduinoId] int NOT NULL,
    [DeviceTypeId] nvarchar(450) NULL,
    CONSTRAINT [PK_Devices] PRIMARY KEY ([DeviceId]),
    CONSTRAINT [FK_Devices_DeviceTypes_DeviceTypeId] FOREIGN KEY ([DeviceTypeId]) REFERENCES [DeviceTypes] ([DeviceTypeId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Devices_Hubs_HubId] FOREIGN KEY ([HubId]) REFERENCES [Hubs] ([HubId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Devices_Pieces_PieceId] FOREIGN KEY ([PieceId]) REFERENCES [Pieces] ([PieceId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Devices_Relays_RelayId] FOREIGN KEY ([RelayId]) REFERENCES [Relays] ([RelayId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [DeviceNickName] (
    [DeviceNickNameId] uniqueidentifier NOT NULL,
    [DeviceId] uniqueidentifier NOT NULL,
    [NickName] nvarchar(max) NULL,
    CONSTRAINT [PK_DeviceNickName] PRIMARY KEY ([DeviceNickNameId]),
    CONSTRAINT [FK_DeviceNickName_Devices_DeviceId] FOREIGN KEY ([DeviceId]) REFERENCES [Devices] ([DeviceId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [DeviceTraits] (
    [DeviceTraitId] nvarchar(450) NOT NULL,
    [DisplayName] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [DeviceId] uniqueidentifier NULL,
    [DeviceTypeId] nvarchar(450) NULL,
    CONSTRAINT [PK_DeviceTraits] PRIMARY KEY ([DeviceTraitId]),
    CONSTRAINT [FK_DeviceTraits_Devices_DeviceId] FOREIGN KEY ([DeviceId]) REFERENCES [Devices] ([DeviceId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_DeviceTraits_DeviceTypes_DeviceTypeId] FOREIGN KEY ([DeviceTypeId]) REFERENCES [DeviceTypes] ([DeviceTypeId]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_DeviceNickName_DeviceId] ON [DeviceNickName] ([DeviceId]);

GO

CREATE INDEX [IX_Devices_DeviceTypeId] ON [Devices] ([DeviceTypeId]);

GO

CREATE INDEX [IX_Devices_HubId] ON [Devices] ([HubId]);

GO

CREATE INDEX [IX_Devices_PieceId] ON [Devices] ([PieceId]);

GO

CREATE INDEX [IX_Devices_RelayId] ON [Devices] ([RelayId]);

GO

CREATE INDEX [IX_DeviceTraits_DeviceId] ON [DeviceTraits] ([DeviceId]);

GO

CREATE INDEX [IX_DeviceTraits_DeviceTypeId] ON [DeviceTraits] ([DeviceTypeId]);

GO

CREATE INDEX [IX_Hubs_HomeId] ON [Hubs] ([HomeId]);

GO

CREATE INDEX [IX_Hubs_PieceId] ON [Hubs] ([PieceId]);

GO

CREATE INDEX [IX_Pieces_HomeId] ON [Pieces] ([HomeId]);

GO

CREATE INDEX [IX_Relays_HubId] ON [Relays] ([HubId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190306232815_Devices', N'2.2.0-rtm-35687');

GO

