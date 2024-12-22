CREATE DATABASE [PrototypeDataBase_];
GO

USE [PrototypeDataBase_];
GO

CREATE TABLE [dbo].[Users] (
    [UserID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Username] NVARCHAR(100) NOT NULL UNIQUE,
    [Password] NVARCHAR(100) NOT NULL,
    [UserType] NVARCHAR(50) CHECK ([UserType] IN ('Platform', 'Artist')),
    [Email] VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE [dbo].[Platforms] (
    [PlatformID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [UserID] INT NULL FOREIGN KEY REFERENCES [dbo].[Users]([UserID]),
    [Name] NVARCHAR(200) NULL,
    [Address] NVARCHAR(300) NULL,
    [Description] NVARCHAR(1000) NULL,
    [Image] VARBINARY(MAX) NULL
);

CREATE TABLE [dbo].[Artists] (
    [ArtistID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [UserID] INT NULL FOREIGN KEY REFERENCES [dbo].[Users]([UserID]),
    [FullName] NVARCHAR(200) NULL,
    [BirthDate] DATE NULL,
    [Hometown] NVARCHAR(100) NULL,
    [Description] NVARCHAR(1000) NULL,
    [Image] VARBINARY(MAX) NULL
);

CREATE TABLE [dbo].[Genres] (
    [GenreID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE [dbo].[Events] (
    [EventID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [PlatformID] INT NULL FOREIGN KEY REFERENCES [dbo].[Platforms]([PlatformID]),
    [Name] NVARCHAR(200) NULL,
    [Description] NVARCHAR(1000) NULL,
    [EventDate] DATETIME NULL,
    [TotalSeats] INT NULL,
    [Image] VARBINARY(MAX) NULL
);

CREATE TABLE [dbo].[Notifications] (
    [NotificationID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [UserID] INT NULL FOREIGN KEY REFERENCES [dbo].[Users]([UserID]),
    [Message] NVARCHAR(1000) NULL,
    [IsRead] BIT DEFAULT 0,
    [CreatedAt] DATETIME DEFAULT GETDATE(),
    [EventID] INT NULL FOREIGN KEY REFERENCES [dbo].[Events]([EventID]),
    [ArtistID] INT NULL FOREIGN KEY REFERENCES [dbo].[Artists]([ArtistID]) ON DELETE SET NULL
);

CREATE TABLE [dbo].[ArtistGenres] (
    [ArtistID] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Artists]([ArtistID]) ON DELETE CASCADE,
    [GenreID] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Genres]([GenreID]) ON DELETE CASCADE,
    PRIMARY KEY ([ArtistID], [GenreID])
);

CREATE TABLE [dbo].[EventGenres] (
    [EventID] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Events]([EventID]) ON DELETE CASCADE,
    [GenreID] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Genres]([GenreID]) ON DELETE CASCADE,
    PRIMARY KEY ([EventID], [GenreID])
);

CREATE TABLE [dbo].[ArtistEvents] (
    [ArtistID] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Artists]([ArtistID]) ON DELETE CASCADE,
    [EventID] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Events]([EventID]) ON DELETE CASCADE,
    PRIMARY KEY ([ArtistID], [EventID])
);

INSERT INTO [dbo].[Genres] ([Name])
VALUES
    ('Буффонада'),
    ('Импровизация'),
    ('КВН'),
    ('Стендап'),
    ('Чёрный юмор');
GO




CREATE PROCEDURE SignUpArtistForEvent
    @ArtistID INT,
    @EventID INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Добавляем запись в ArtistEvents
        INSERT INTO dbo.ArtistEvents (ArtistID, EventID)
        VALUES (@ArtistID, @EventID);

        -- Получаем PlatformID для уведомления
        DECLARE @PlatformID INT;
        SELECT @PlatformID = PlatformID
        FROM dbo.Events
        WHERE EventID = @EventID;

        -- Проверяем, что PlatformID найден
        IF @PlatformID IS NOT NULL
        BEGIN
            -- Создаем уведомление для платформы
            DECLARE @Message NVARCHAR(1000) = 'Новый артист записался на';
            INSERT INTO dbo.Notifications (UserID, Message, IsRead, CreatedAt, EventID, ArtistID)
            SELECT UserID, @Message, 0, GETDATE(), @EventID, @ArtistID
            FROM dbo.Platforms
            WHERE PlatformID = @PlatformID;
        END;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO


CREATE PROCEDURE CancelArtistSignUp
    @ArtistID INT,
    @EventID INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Удаляем запись из ArtistEvents
        DELETE FROM dbo.ArtistEvents
        WHERE ArtistID = @ArtistID AND EventID = @EventID;

        -- Получаем PlatformID для уведомления
        DECLARE @PlatformID INT;
        SELECT @PlatformID = PlatformID
        FROM dbo.Events
        WHERE EventID = @EventID;

        -- Проверяем, что PlatformID найден
        IF @PlatformID IS NOT NULL
        BEGIN
            -- Создаем уведомление для платформы
            DECLARE @Message NVARCHAR(1000) = 'Артист отменил запись';
            INSERT INTO dbo.Notifications (UserID, Message, IsRead, CreatedAt, EventID, ArtistID)
            SELECT UserID, @Message, 0, GETDATE(), @EventID, @ArtistID
            FROM dbo.Platforms
            WHERE PlatformID = @PlatformID;
        END;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO


CREATE TRIGGER EventFullNotification
ON dbo.ArtistEvents
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @EventID INT;
    SELECT @EventID = EventID FROM inserted;

    DECLARE @TotalSeats INT, @OccupiedSeats INT, @PlatformID INT, @UserID INT;
    SELECT 
        @TotalSeats = TotalSeats,
        @PlatformID = PlatformID
    FROM dbo.Events
    WHERE EventID = @EventID;

    SELECT 
        @OccupiedSeats = COUNT(ArtistID)
    FROM dbo.ArtistEvents
    WHERE EventID = @EventID;

    IF @OccupiedSeats >= @TotalSeats AND @PlatformID IS NOT NULL
    BEGIN
        SELECT @UserID = UserID FROM dbo.Platforms WHERE PlatformID = @PlatformID;

        INSERT INTO dbo.Notifications (UserID, Message, IsRead, CreatedAt, EventID)
        VALUES (@UserID, 'Все места заполнены', 0, GETDATE(), @EventID);
    END;
END;
GO


CREATE INDEX IX_Notifications_UserID_IsRead ON Notifications (UserID, IsRead);

CREATE INDEX IX_Events_PlatformID ON Events (PlatformID);

CREATE INDEX IX_Platforms_UserID ON Platforms (UserID);

CREATE INDEX IX_Artists_UserID ON Artists (UserID);
GO