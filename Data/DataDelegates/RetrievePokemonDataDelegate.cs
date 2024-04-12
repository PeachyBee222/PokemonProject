﻿using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data.DataDelegates
{
    internal class RetrievePokemonDataDelegate : DataReaderDelegate<IReadOnlyList<Pokemon>>
    {
        public RetrievePokemonDataDelegate()
            : base("Pokemon.RetrievePokemons")
        {
        }
    }
}
