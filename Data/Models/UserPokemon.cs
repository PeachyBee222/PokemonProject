using PokemonCollections.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCollections.Data.Models
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
        /// The email of the user
        /// </summary>
        public string UserEmail {  get; set; }
        
        /// <summary>
        /// The constructor for a user adding a pokemon
        /// </summary>
        /// <param name="pokemon"></param>
        /// <param name="nickname"></param>
        public UserPokemon(Pokemon pokemon, string userEmail, string? nickname)
        {
            Pokemon = pokemon;
            UserEmail = userEmail;
            NickName = nickname ?? string.Empty;
        }
    }
}
