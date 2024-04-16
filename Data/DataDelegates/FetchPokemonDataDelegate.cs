using DataAccess2;
using TheFlyingSaucer.Data.Models;

namespace TheFlyingSaucer.Data.DataDelegates
{
    internal class FetchPokemonDataDelegate : DataReaderDelegate<Pokemon>
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

            return new Pokemon(
                reader.GetInt32("CreatureID"),
                reader.GetInt32("GenerationNum"),
                name,
                reader.GetInt32("BaseHP"),
                reader.GetInt32("Attack"),
                reader.GetInt32("Defense"),
                reader.GetInt32("Speed")
                );
        }
    }
}
