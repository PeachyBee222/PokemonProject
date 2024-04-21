CREATE OR ALTER PROCEDURE Pokemon.GetUserCountPerPokemon
AS
SELECT C.Name,
    ISNULL(COUNT(UC.UserID), 0) AS NumberOfUsers
FROM Pokemon.Creatures C
    LEFT JOIN Pokemon.UserCreature UC ON C.CreatureID = UC.CreatureID
GROUP BY C.Name, C.CreatureID, C.GenerationNum
ORDER BY C.GenerationNum ASC, C.CreatureID ASC;
GO