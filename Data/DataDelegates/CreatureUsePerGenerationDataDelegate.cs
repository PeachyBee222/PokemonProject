using DataAccess2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFlyingSaucer.Data.Models;

namespace TheFlyingSaucer.Data.DataDelegates
{
    internal class CreatureUsePerGenerationDataDelegate : DataReaderDelegate<Generation>
    {
        public CreatureUsePerGenerationDataDelegate()
            : base("Pokemon.CreatureUsePerGeneration")
        {
        }

        public override Generation Translate(Command command, IDataRowReader reader)
        {
            if (!reader.Read())
                return null;

            return new Generation(
               reader.GetInt32("GenerationNum"),
               0
               );
        }
    }
}
