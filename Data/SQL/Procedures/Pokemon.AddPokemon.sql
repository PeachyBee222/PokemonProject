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