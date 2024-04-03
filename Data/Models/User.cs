using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data.Models
{
    public class User
    {
        public int UserID { get; }

        public string Email { get; }
        
        public List<UserPokemon> Pokemon { get; set; }

        /// <summary>
        /// Constructor for User
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="email"></param>
        public User(int userID, string email)
        {
            UserID = userID;
            Email = email;

        }

        /// <summary>
        /// A way to set the users pokemon
        /// </summary>
        public void SetUserPokemon(List<UserPokemon> pokemon)
        {
            Pokemon = pokemon;
        }

        /// <summary>
        /// A way to set the users pokemon
        /// </summary>
        public void SetUserPokemon(UserPokemon pokemon)
        {
            Pokemon.Add(pokemon);
        }

        /// <summary>
        /// A way to set the users pokemon
        /// </summary>
        public void SetUserPokemon(int pokemonID, string? nickname)
        {
            UserPokemon temp = new UserPokemon(pokemonID, nickname);
            Pokemon.Add(temp);
        }
    }
}
