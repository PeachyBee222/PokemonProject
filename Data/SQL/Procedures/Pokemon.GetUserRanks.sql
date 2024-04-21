CREATE OR ALTER PROCEDURE Pokemon.GetUserRanks
AS
SELECT U.Email, 
    COUNT(UC.CreatureID) AS NumberOfPokemon
FROM Pokemon.Users U
    INNER JOIN Pokemon.UserCreature UC ON UC.UserID = U.UserID
GROUP BY U.Email
ORDER BY NumberOfPokemon ASC;
GO