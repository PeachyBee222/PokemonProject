﻿using DataAccess2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PokemonCollections.Data.Models;

namespace PokemonCollections.Data.DataDelegates
{
    /// <summary>
    /// The data delegate to call our procedure for getting the stats of the pokemon, as well as the number of users that use said pokemon
    /// </summary>
    internal class GetUserCountPerPokemonDataDelegate : DataReaderDelegate<Pokemon>
    {
        public GetUserCountPerPokemonDataDelegate()
            : base("Pokemon.GetUserCountPerPokemon")
        {
        }

        public override Pokemon Translate(Command command, IDataRowReader reader)
        {
            if (!reader.Read())
                return null;

            ElementType pelem;
            ElementType selem;
            Enum.TryParse<ElementType>(reader.GetString("ElementTypePrimary"), true, out pelem);
            Enum.TryParse<ElementType>(reader.GetString("ElementTypeSecondary"), true, out selem);
            return (new Pokemon(
                reader.GetInt32("CreatureID"),
                reader.GetInt32("GenerationNum"),
                reader.GetString("PokemonName"),
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
