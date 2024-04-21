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