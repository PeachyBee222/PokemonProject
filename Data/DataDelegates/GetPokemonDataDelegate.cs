using TheFlyingSaucer.Data.Models;
using DataAccess2;

namespace TheFlyingSaucer.Data.DataDelegates
{
    public class GetPokemonDataDelegate : DataReaderDelegate<Pokemon>
    {
        private readonly string PokemonName;

        public GetPokemonDataDelegate(string name) 
            :base("Pokemon.GetPokemon")
        {
            this.PokemonName = name;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("Name", PokemonName);
        }

        public override Pokemon Translate(Command command, IDataRowReader reader)
        {
            if (!reader.Read()) return null;

            ElementType pelem;
            ElementType selem;
            //FIXME i need to know the names of these exactly
            Enum.TryParse<ElementType>(reader.GetString("PrimaryElement"), true, out pelem);
            Enum.TryParse<ElementType>(reader.GetString("SecondaryElement"), true, out selem);
            return (new Pokemon(
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
    }
}
