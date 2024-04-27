USE PokemonProject
GO

--User rank based on pokemon amount query (Gets the top 3 users with the most pokemon)
CREATE OR ALTER PROCEDURE Pokemon.GetUserRanks
AS
SELECT TOP 3 U.UserID, U.Email, 
    COUNT(UC.CreatureID) AS NumberOfPokemon
FROM Pokemon.Users U
    LEFT JOIN Pokemon.UserCreature UC ON UC.UserID = U.UserID
GROUP BY U.Email, U.UserID
ORDER BY NumberOfPokemon DESC
GO

--User rank based on average Pokemon statistic block total (Gets the top 3 users with the highest average stat block)
CREATE OR ALTER PROCEDURE Pokemon.GetUserStatBlockRanking
AS
SELECT TOP 3 U.UserID, U.Email,
    ISNULL(SUM(C.Attack + C.BaseHP + C.Defense + C.Speed) / COUNT(UC.CreatureID), 0) AS AverageStatBlockTotal
FROM Pokemon.Users U
    LEFT JOIN Pokemon.UserCreature UC ON UC.UserID = U.UserID
    LEFT JOIN Pokemon.Creatures C ON C.CreatureID = UC.CreatureID
GROUP BY U.UserID, U.Email
ORDER BY AverageStatBlockTotal DESC
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

--Total number of pokemon that are in use for each generation
CREATE OR ALTER PROCEDURE Pokemon.CreatureUsePerGeneration
AS
SELECT G.GenerationNum,
    G.[Name],
    ISNULL(COUNT(UC.CreatureID), 0) AS TotalNumOfUsers
FROM Pokemon.Generation G
    LEFT JOIN Pokemon.Creatures C ON G.GenerationNum = C.GenerationNum
    LEFT JOIN Pokemon.UserCreature UC ON UC.CreatureID = C.CreatureID
GROUP BY G.GenerationNum, G.[Name]
ORDER BY G.GenerationNum ASC;
GO

--Add user procedure to add a brand new user to the database.
CREATE OR ALTER PROCEDURE Pokemon.AddUser
   @Email NVARCHAR(128),
   @UserID INT OUTPUT
AS
IF NOT EXISTS (SELECT * FROM Pokemon.Users WHERE Email = @Email)
    INSERT INTO Pokemon.Users(Email)
        VALUES (@Email);
SET @UserID = SCOPE_IDENTITY();
GO

--Create pokemon by adding to the creatures table, and linking the creature to it's elements in the CreatureElements table.
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

INSERT Pokemon.CreatureElement(CreatureID, ElementID, IsPrimary)
SELECT @CreatureID, E.ElementID, 0 
FROM Pokemon.Element E
WHERE E.[Name] = @ElementTypeSecondary AND NOT EXISTS
    (
        SELECT *
        FROM Pokemon.CreatureElement CE
        WHERE @CreatureID = CE.CreatureID AND E.ElementID = CE.ElementID
    );
GO

--Add Pokemon to the UserCreature table so a pokemon can be associated with a user
CREATE OR ALTER PROCEDURE Pokemon.AddPokemon
    @Email NVARCHAR(128),
    @PokemonID INT,
    @Nickname NVARCHAR(100)
AS
WITH SourceCte(UserID, PokemonID) AS
   (
      SELECT U.UserID, @PokemonID
      FROM (VALUES
            (@Email)
      ) Temp_table(Email)
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

--Get all of the pokemon and their stats associated with a user
CREATE OR ALTER PROCEDURE Pokemon.GetUser
    @Email NVARCHAR(128)
AS
SELECT U.UserID, U.Email, C.CreatureID AS CreatureID, MAX(C.Name) AS CreatureName, ISNULL(MAX(UC.Nickname), N'N/A') AS Nickname, C.GenerationNum,
        MAX(C.BaseHP) AS HP, MAX(C.Attack) AS Attack, MAX(C.Defense) AS Defense, MAX(C.Speed) AS Speed,
        MAX(IIF(CE.IsPrimary = 1, E.Name, NULL)) AS PrimaryElement,
        MAX(IIF(CE.IsPrimary = 0, E.Name, NULL)) AS SecondaryElement 
FROM Pokemon.UserCreature UC
    FULL JOIN Pokemon.Users U ON UC.UserID = U.UserID
    LEFT JOIN Pokemon.Creatures C ON C.CreatureID = UC.CreatureID
    LEFT JOIN Pokemon.CreatureElement CE ON CE.CreatureID = C.CreatureID
    LEFT JOIN Pokemon.Element E ON E.ElementID = CE.ElementID
WHERE U.Email = @Email
GROUP BY U.UserID, U.Email, C.CreatureID, C.GenerationNum
GO

--Retrieve Pokemon (all)
CREATE OR ALTER PROCEDURE Pokemon.RetrievePokemon
AS
BEGIN
    DECLARE @UserCountPerPokemon TABLE (
        Name NVARCHAR(50),
        NumberOfUsers INT
    );
    INSERT INTO @UserCountPerPokemon (Name, NumberOfUsers)
    EXEC Pokemon.GetUserCountPerPokemon;
    SELECT C.CreatureID,
           C.Name,
           C.BaseHP AS HP,
           C.Attack,
           C.Defense,
           C.Speed,
           C.GenerationNum,
           MAX(IIF(CE.IsPrimary = 1, E.Name, NULL)) AS PrimaryElement,
           MAX(IIF(CE.IsPrimary = 0, E.Name, NULL)) AS SecondaryElement,
           UCP.NumberOfUsers  
    FROM Pokemon.Creatures C
    INNER JOIN Pokemon.CreatureElement CE ON CE.CreatureID = C.CreatureID
    INNER JOIN Pokemon.Element E ON E.ElementID = CE.ElementID
    LEFT JOIN @UserCountPerPokemon UCP ON C.Name = UCP.Name
    GROUP BY C.CreatureID,
             C.Name,
             C.BaseHP,
             C.Attack,
             C.Defense,
             C.Speed,
             C.GenerationNum,
             UCP.NumberOfUsers
    ORDER BY C.CreatureID ASC
END;
GO
