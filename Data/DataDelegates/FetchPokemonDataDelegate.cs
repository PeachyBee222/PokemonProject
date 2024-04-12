using DataAccess;
using TheFlyingSaucer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data.DataDelegates
{
    internal class FetchPokemonDataDelegate : DataReaderDelegate<Pokemon>
    {
        private readonly string name;

        public FetchPokemonDataDelegate(string name)
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
