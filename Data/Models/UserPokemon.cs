using PokemonProject.Data.Model;
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
        /// The pokemon creature
        /// </summary>
        public Pokemon Pokemon { get; set; }

        /// <summary>
        /// The nickname the user gives the specified pokemon
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// The constructor for a user adding a pokemon
        /// </summary>
        /// <param name="pokemon"></param>
        /// <param name="nickname"></param>
        public UserPokemon(Pokemon pokemon, string? nickname)
        {
            Pokemon = pokemon;
            NickName = nickname ?? string.Empty;
        }
    }
}
