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