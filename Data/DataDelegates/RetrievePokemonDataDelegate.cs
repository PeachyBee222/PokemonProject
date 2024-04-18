using DataAccess2;
using TheFlyingSaucer.Data.Models;

namespace TheFlyingSaucer.Data.DataDelegates
{
    public class RetrievePokemonDataDelegate : DataReaderDelegate<List<Pokemon>>
    {
        public RetrievePokemonDataDelegate()
            : base("Pokemon.RetrievePokemons")
        {
        }
        public override List<Pokemon> Translate(Command command, IDataRowReader reader)
        {
            var pokemons = new List<Pokemon>();

            while (reader.Read())
            {
                ElementType pelem;
                ElementType selem;
                //FIXME i need to know the names of these exactly
                Enum.TryParse<ElementType>(reader.GetString("PrimaryElement"), true, out pelem);
                Enum.TryParse<ElementType>(reader.GetString("SecondaryElement"), true, out selem);
                pokemons.Add(new Pokemon(
                    reader.GetInt32("CreatureID"),
                    reader.GetInt32("GenerationNum"),
                    reader.GetString("Name"),
                    reader.GetInt32("BaseHP"),
                    reader.GetInt32("Attack"),
                    reader.GetInt32("Defense"),
                    reader.GetInt32("Speed"),
                    pelem,
                    selem,
                    reader.GetInt32("NumUsers")
                    ));
            }

            return pokemons;
        }
    }
}
