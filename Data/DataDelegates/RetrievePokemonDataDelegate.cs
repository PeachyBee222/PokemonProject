using DataAccess;
using PokemonProject.Data.Models;

namespace PokemonProject.Data.DataDelegates
{
    internal class RetrievePokemonDataDelegate : DataReaderDelegate<IReadOnlyList<Pokemon>>
    {
        public RetrievePokemonDataDelegate()
            : base("Pokemon.RetrievePokemons")
        {
        }
        public override IReadOnlyList<Pokemon> Translate(Command command, IDataRowReader reader)
        {
            var pokemons = new List<Pokemon>();

            while (reader.Read())
            {
                pokemons.Add(new Pokemon(
                    reader.GetInt32("CreatureID"),
                    reader.GetInt32("GenerationNum"),
                    reader.GetString("Name"),
                    reader.GetInt32("BaseHP"),
                    reader.GetInt32("Attack"),
                    reader.GetInt32("Defense"),
                    reader.GetInt32("Speed"))
                    );
            }

            return pokemons;
        }
    }
}
