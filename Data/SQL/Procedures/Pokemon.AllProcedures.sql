USE PokemonProject
GO

--User rank based on pokemon amount query
CREATE OR ALTER PROCEDURE Pokemon.GetUserRanks
AS
SELECT U.Email, 
    COUNT(UC.CreatureID) AS NumberOfPokemon
FROM Pokemon.Users U
    INNER JOIN Pokemon.UserCreature UC ON UC.UserID = U.UserID
GROUP BY U.Email
ORDER BY NumberOfPokemon ASC
GO

--User rank based on average Pokemon statistic block total
CREATE OR ALTER PROCEDURE Pokemon.GetUserStatBlockRanking
AS
SELECT U.Email,
    DENSE_RANK() OVER(ORDER BY  SUM(C.Attack + C.BaseHP + C.Defense + C.Speed) / COUNT(UC.CreatureID) DESC) AS Rank,
    SUM(C.Attack + C.BaseHP + C.Defense + C.Speed) / COUNT(UC.CreatureID) AS AverageStatBlockTotal
FROM Pokemon.Users U
    INNER JOIN Pokemon.UserCreature UC ON UC.UserID = U.UserID
    INNER JOIN Pokemon.Creatures C ON C.CreatureID = UC.CreatureID
GROUP BY U.Email, C.CreatureID
GO

--Number of users that utilize specific pokemon
CREATE OR ALTER PROCEDURE Pokemon.GetUserCountPerPokemon
AS
SELECT C.Name,
    ISNULL(COUNT(UC.UserID), 0) AS NumberOfUsers
FROM Pokemon.Creatures C
    LEFT JOIN Pokemon.UserCreature UC ON C.CreatureID = UC.CreatureID
GROUP BY C.Name, C.CreatureID, C.GenerationNum
ORDER BY C.GenerationNum ASC, C.CreatureID ASC;
GO

--Total number of pokemon for in use for each generation
CREATE OR ALTER PROCEDURE Pokemon.CreatureUsePerGeneration
AS
SELECT G.GenerationNum,
    ISNULL(COUNT(UC.CreatureID), 0) AS TotalNumOfPokemon
FROM Pokemon.Generation G
    LEFT JOIN Pokemon.Creatures C ON G.GenerationNum = C.GenerationNum
    LEFT JOIN Pokemon.UserCreature UC ON UC.CreatureID = C.CreatureID
GROUP BY G.GenerationNum
ORDER BY G.GenerationNum ASC;
GO

--Add user procedure
CREATE OR ALTER PROCEDURE Pokemon.AddUser
   @Email NVARCHAR(128),
   @UserID INT OUTPUT
AS
IF NOT EXISTS (SELECT * FROM Pokemon.Users WHERE Email = @Email)
    INSERT INTO Pokemon.Users(Email)
        VALUES (@Email);
SET @UserID = SCOPE_IDENTITY();
GO

--Create pokemon
CREATE OR ALTER PROCEDURE Pokemon.CreatePokemon
    @GenerationNum INT,
    @PokemonName NVARCHAR(30),
    @BaseHP INT,
    @Attack INT,
    @Defense INT,
    @Speed INT,
    @ElementTypePrimary NVARCHAR(20),
    @ElementTypeSecondary NVARCHAR(20),
    @CreatureID INT OUTPUT
AS
MERGE Pokemon.Creatures C
USING ( 
   VALUES (
        @GenerationNum,
        @PokemonName,
        @BaseHP,
        @Attack,
        @Defense,
        @Speed
   )
)  NA (GenerationNum, PokemonName, BaseHP, Attack, Defense, Speed) ON NA.PokemonName = C.[Name]
WHEN NOT MATCHED THEN
   INSERT(GenerationNum, [Name], BaseHP, Attack, Defense, Speed)
   VALUES(NA.GenerationNum, NA.PokemonName, NA.BaseHP, NA.Attack, NA.Defense, NA.Speed);
SET @CreatureID = SCOPE_IDENTITY();

INSERT Pokemon.CreatureElement(CreatureID, ElementID, IsPrimary)
SELECT @CreatureID, E.ElementID, 1
FROM Pokemon.Element E
WHERE E.[Name] = @ElementTypePrimary AND NOT EXISTS
   (
      SELECT *
      FROM Pokemon.CreatureElement CE
      WHERE @CreatureID = CE.CreatureID AND E.ElementID = CE.ElementID
   );

IF @ElementTypeSecondary IS NOT NULL
BEGIN
    INSERT Pokemon.CreatureElement(CreatureID, ElementID, IsPrimary)
    SELECT @CreatureID, E.ElementID, 0 
    FROM Pokemon.Element E
    WHERE E.[Name] = @ElementTypeSecondary AND NOT EXISTS
        (
            SELECT *
            FROM Pokemon.CreatureElement CE
            WHERE @CreatureID = CE.CreatureID AND E.ElementID = CE.ElementID
        )
END;
GO

--Add Pokemon
CREATE OR ALTER PROCEDURE Pokemon.AddPokemon
    @Email NVARCHAR(128),
    @PokemonName NVARCHAR(30),
    @Nickname NVARCHAR(100)
AS
WITH SourceCte(UserID, PokemonID) AS
   (
      SELECT U.UserID, C.CreatureID
      FROM (VALUES
            (@Email, @PokemonName)
      ) Temp_table(Email, PokemonName)
        INNER JOIN Pokemon.Creatures C ON c.[Name] = Temp_table.PokemonName
        INNER JOIN Pokemon.Users U ON U.Email = Temp_table.Email
   )
INSERT Pokemon.UserCreature(UserID, CreatureID, Nickname)
SELECT SCTE.UserID, SCTE.PokemonID, IIF(@Nickname IS NULL, NULL, @Nickname)
FROM SourceCte SCTE
WHERE NOT EXISTS
   (
      SELECT *
      FROM Pokemon.UserCreature UC
      WHERE SCTE.UserID = UC.UserID AND SCTE.PokemonID = UC.CreatureID
   );
GO

--Get User
CREATE OR ALTER PROCEDURE Pokemon.GetUser
    @Email NVARCHAR(128)
AS
SELECT U.UserID, U.Email, MAX(C.CreatureID) AS CreatureID, MAX(C.Name) AS CreatureName, ISNULL(MAX(UC.Nickname), N'N/A') AS Nickname,
        MAX(C.BaseHP) AS HP, MAX(C.Attack) AS Attack, MAX(C.Defense) AS Defense, MAX(C.Speed) AS Speed,
        MAX(IIF(CE.IsPrimary = 1, E.Name, NULL)) AS PrimaryElement,
        MAX(IIF(CE.IsPrimary = 0, E.Name, NULL)) AS SecondaryElement 
FROM Pokemon.UserCreature UC
    INNER JOIN Pokemon.Users U ON UC.UserID = U.UserID
    INNER JOIN Pokemon.Creatures C ON C.CreatureID = UC.CreatureID
    INNER JOIN Pokemon.CreatureElement CE ON CE.CreatureID = C.CreatureID
    INNER JOIN Pokemon.Element E ON E.ElementID = CE.ElementID
WHERE U.Email = @Email
GROUP BY U.UserID, U.Email;
GO

--Retrieve Pokemon (all)
CREATE OR ALTER PROCEDURE Pokemon.RetrievePokemon
AS
SELECT C.CreatureID, C.Name, C.BaseHP AS HP, 
        C.Attack, C.Defense, C.Speed,
        MAX(IIF(CE.IsPrimary = 1, E.Name, NULL)) AS PrimaryElement,
        MAX(IIF(CE.IsPrimary = 0, E.Name, NULL)) AS SecondaryElement 
FROM Pokemon.Creatures C
    INNER JOIN Pokemon.CreatureElement CE ON CE.CreatureID = C.CreatureID
    INNER JOIN Pokemon.Element E ON E.ElementID = CE.ElementID
GROUP BY C.CreatureID, C.Name, C.BaseHP, C.Attack, C.Defense, C.Speed;
GO