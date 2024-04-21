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