IF SCHEMA_ID(N'Pokemon') IS NULL
    EXEC(N'CREATE SCHEMA [Pokemon];');
GO


DROP TABLE IF EXISTS Pokemon.UserCreature
DROP TABLE IF EXISTS Pokemon.CreatureElement
DROP TABLE IF EXISTS Pokemon.Creatures
DROP TABLE IF EXISTS Pokemon.Generation
DROP TABLE IF EXISTS Pokemon.Users
DROP TABLE IF EXISTS Pokemon.Element

CREATE TABLE Pokemon.Users
(
    UserID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Email NVARCHAR(128) NOT NULL UNIQUE
)

CREATE TABLE Pokemon.Generation
(
    GenerationID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL UNIQUE,
    [Number] INT NOT NULL UNIQUE,
)

CREATE TABLE Pokemon.Element
(
    ElementID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(20) NOT NULL UNIQUE,
)

CREATE TABLE Pokemon.Creatures
(
    CreatureID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    GenerationID INT NOT NULL FOREIGN KEY
        REFERENCES Pokemon.Generation(GenerationID),
    [Name] NVARCHAR(30) NOT NULL UNIQUE,
    BaseHP INT NOT NULL
        CONSTRAINT [NE_Pokemon_Creatures_BaseHP] CHECK(BaseHP > 0),
    Attack INT NOT NULL
        CONSTRAINT [NE_Pokemon_Creatures_Attack] CHECK(Attack > 0),
    Defense INT NOT NULL
        CONSTRAINT [NE_Pokemon_Creatures_Defense] CHECK(Defense > 0),
    Speed INT NOT NULL
        CONSTRAINT [NE_Pokemon_Creatures_Speed] CHECK(Speed > 0),
    Total INT NOT NULL,
    CONSTRAINT [TE_Pokemon_Creatures_Total] CHECK(Total = (BaseHP + Attack + Defense + Speed)) --Has to be equal to BaseHP + Attack + Defense + Speed
)

CREATE TABLE Pokemon.CreatureElement
(
    CreatureID INT NOT NULL FOREIGN KEY
        REFERENCES Pokemon.Creatures(CreatureID),
    ElementID INT NOT NULL FOREIGN KEY
        REFERENCES Pokemon.Element(ElementID),
    PRIMARY KEY(CreatureID, ElementID)
)

CREATE TABLE Pokemon.UserCreature
(
    UserID INT NOT NULL FOREIGN KEY
        REFERENCES Pokemon.Users(UserID),
    CreatureID INT NOT NULL FOREIGN KEY
        REFERENCES Pokemon.Creatures(CreatureID),
    Nickname NVARCHAR(100) NULL,
    
    CONSTRAINT [UK_Pokemon_UserCreature_UserID_CreatureID] PRIMARY KEY
   (
      UserID,
      CreatureID
   )
)

CREATE UNIQUE NONCLUSTERED INDEX [UFX_Pokemon_UserCreature_UserID_Nickname] ON Pokemon.UserCreature
(
    UserID,
    Nickname
)
WHERE Nickname IS NOT NULL


-- CREATE TABLE Pokemon.UserCreature
-- (
--     UserCreatureID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
--     UserID INT NOT NULL FOREIGN KEY
--         REFERENCES Pokemon.Users(UserID),
--     CreatureID INT NOT NULL FOREIGN KEY
--         REFERENCES Pokemon.Creatures(CreatureID),
--     Nickname NVARCHAR(100) NULL,
    
--     CONSTRAINT [UK_Pokemon_UserCreature_UserID_CreatureID] UNIQUE
--    (
--       UserID,
--       CreatureID
--    ),

--     CONSTRAINT [UK_Pokemon_UserCreature_UserID_Nickname] UNIQUE
--    (
--       UserID,
--       Nickname
--    ),
-- )