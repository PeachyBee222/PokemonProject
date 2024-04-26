using DataAccess2;
using PokemonCollections.Data.Models;

namespace PokemonCollections.Data.DataDelegates
{
    public class FetchPokemonDataDelegate : DataReaderDelegate<Pokemon>
    {
        private readonly string name;

        public FetchPokemonDataDelegate(string name)
            : base("Pokemon.FetchPokemon")
        {
            this.name = name;
        }

        public override Pokemon Translate(Command command, IDataRowReader reader)
        {
            if (!reader.Read())
                throw new RecordNotFoundException(name);

            ElementType pelem;
            ElementType selem;
            //FIXME i need to know the names of these exactly
            Enum.TryParse<ElementType>(reader.GetString("PrimaryElement"), true, out pelem);
            Enum.TryParse<ElementType>(reader.GetString("SecondaryElement"), true, out selem);
            return(new Pokemon(
                reader.GetInt32("CreatureID"),
                reader.GetInt32("GenerationNum"),
                name,
                reader.GetInt32("BaseHP"),
                reader.GetInt32("Attack"),
                reader.GetInt32("Defense"),
                reader.GetInt32("Speed"),
                pelem,
                selem,
                reader.GetInt32("NumUsers")
                ));
        }
    }
}
