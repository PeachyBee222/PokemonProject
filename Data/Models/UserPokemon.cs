using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data.Models
{
    /// <summary>
    /// The pokemon for each user
    /// </summary>
    public class UserPokemon
    {
        /// <summary>
        /// The id of the pokemon
        /// </summary>
        public int PokemonID { get; set; }

        /// <summary>
        /// The nickname the user gives the specified pokemon
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// The constructor for a user adding a pokemon
        /// </summary>
        /// <param name="pokemonID"></param>
        /// <param name="nickname"></param>
        public UserPokemon(int pokemonID, string? nickname)
        {
            PokemonID = pokemonID;
            NickName = nickname ?? string.Empty;
        }
    }
}
