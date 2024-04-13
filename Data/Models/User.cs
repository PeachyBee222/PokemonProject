namespace PokemonProject.Data.Models
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
