using DataAccess;
using PokemonProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProject.Data.DataDelegates
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
