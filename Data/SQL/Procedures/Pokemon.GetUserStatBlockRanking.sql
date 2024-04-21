CREATE OR ALTER PROCEDURE Pokemon.GetUserStatBlockRanking
AS
SELECT U.Email,
    DENSE_RANK() OVER(ORDER BY  SUM(C.Attack + C.BaseHP + C.Defense + C.Speed) / COUNT(UC.CreatureID) DESC) AS Rank,
    SUM(C.Attack + C.BaseHP + C.Defense + C.Speed) / COUNT(UC.CreatureID) AS AverageStatBlockTotal
FROM Pokemon.Users U
    INNER JOIN Pokemon.UserCreature UC ON UC.UserID = U.UserID
    INNER JOIN Pokemon.Creatures C ON C.CreatureID = UC.CreatureID
GROUP BY U.Email, C.CreatureID;
GO