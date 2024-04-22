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

DECLARE @CreaturesId INT = (
   SELECT C.CreatureID
   FROM Pokemon.Creatures C
   WHERE C.[Name] = @PokemonName
)

INSERT Pokemon.CreatureElement(CreatureID, ElementID, IsPrimary)
SELECT @CreaturesId, E.ElementID, 1
FROM Pokemon.Element E
WHERE E.[Name] = @ElementTypePrimary AND NOT EXISTS
   (
      SELECT *
      FROM Pokemon.CreatureElement CE
      WHERE @CreaturesId = CE.CreatureID AND E.ElementID = CE.ElementID
   );

IF @ElementTypeSecondary IS NOT NULL
BEGIN
    INSERT Pokemon.CreatureElement(CreatureID, ElementID, IsPrimary)
    SELECT @CreaturesId, E.ElementID, 0 
    FROM Pokemon.Element E
    WHERE E.[Name] = @ElementTypeSecondary AND NOT EXISTS
        (
            SELECT *
            FROM Pokemon.CreatureElement CE
            WHERE @CreaturesId = CE.CreatureID AND E.ElementID = CE.ElementID
        )
END;
GO
