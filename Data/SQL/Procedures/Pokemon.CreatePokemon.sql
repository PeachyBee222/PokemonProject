--Create pokemon
CREATE OR ALTER PROCEDURE Pokemon.CreatePokemon
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
        0,
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

DECLARE @CreatureId INT = (
   SELECT C.CreatureID
   FROM Pokemon.Creatures C
   WHERE C.[Name] = @PokemonName
)

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
