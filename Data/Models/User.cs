﻿namespace TheFlyingSaucer.Data.Models
{
    /// <summary>
    /// The users of the pokemon
    /// </summary>
    public class User
    {
        /// <summary>
        /// The users ID
        /// </summary>
        public int UserID { get; }

        /// <summary>
        /// The users email
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// List of the users pokemon
        /// </summary>
        public List<UserPokemon> Pokemon { get; set; }

        /// <summary>
        /// Constructor for User --fancy comments
        /// </summary>
        /// <param name="userID">the id for the user</param>
        /// <param name="email">the email for the user</param>
        public User(int userID, string email)
        {
            UserID = userID;
            Email = email;
            Pokemon = new List<UserPokemon>();
        }

        /// <summary>
        /// A way to set the users pokemon
        /// </summary>
        /// <param name="pokemon">the list of pokemon to be added</param>
        public void SetUserPokemon(List<UserPokemon> pokemon)
        {
            Pokemon = pokemon;
        }

        /// <summary>
        /// A way to set the users pokemon
        /// </summary>
        /// <param name="pokemon">sets the users pokemon by adding 1 pokemon</param>
        public void SetUserPokemon(UserPokemon pokemon)
        {
            Pokemon.Add(pokemon);
        }

        /// <summary>
        /// A way to set the users pokemon
        /// </summary>
        /// <param name="nickname">the nickname of the pokemon</param>
        /// <param name="pokemon">the Pokemon object</param>
        public void SetUserPokemon(Pokemon pokemon, string? nickname)
        {
            UserPokemon temp = new UserPokemon(pokemon, nickname);
            Pokemon.Add(temp);
        }
    }
}
