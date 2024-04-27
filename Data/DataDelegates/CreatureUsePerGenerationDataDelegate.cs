using DataAccess2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PokemonCollections.Data.Models;

namespace PokemonCollections.Data.DataDelegates
{
    /// <summary>
    /// The data delegate to call our procedure for the aggregated query for the total number of pokemon being used per generation.
    /// </summary>
    internal class CreatureUsePerGenerationDataDelegate : DataReaderDelegate<List<Generation>>
    {
        public CreatureUsePerGenerationDataDelegate()
            : base("Pokemon.CreatureUsePerGeneration")
        {
        }

        public override List<Generation> Translate(Command command, IDataRowReader reader)
        {

            var generations = new List<Generation>();

            while (reader.Read())
            {
                generations.Add(new Generation(
                    reader.GetString("Name"),
                   reader.GetInt32("GenerationNum"),
                   reader.GetInt32("TotalNumOfUsers")));
            }

            return generations;
        }
    }
}
