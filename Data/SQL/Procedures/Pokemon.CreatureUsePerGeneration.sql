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