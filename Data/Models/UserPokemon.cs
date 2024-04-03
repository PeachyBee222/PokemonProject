using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data.Models
{
    public class UserPokemon
    {
        public int PokemonID { get; set; }
        public string NickName { get; set; }

        public UserPokemon(int pokemonID, string? nickname)
        {
            PokemonID = pokemonID;
            NickName = nickname ?? string.Empty;
        }
    }
}
