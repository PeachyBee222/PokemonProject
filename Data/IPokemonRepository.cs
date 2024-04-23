using TheFlyingSaucer.Data.Models;

namespace TheFlyingSaucer.Data
{
    public interface IPokemonRepository
    {
        /// <summary>
        /// gets all of the pokemon from the database
        /// </summary>
        /// <returns>a list of all pokemon</returns>
        List<Pokemon> RetrievePokemons();
        /// <summary>
        /// gets all of the users from the database
        /// </summary>
        /// <returns>a list of all users</returns>
        List<User> RetrieveUsers();
        /// <summary>
        /// Gets a list of all the generations from the database
        /// </summary>
        /// <returns>all generations</returns>
        List<Generation> RetrieveGenerations();
        /// <summary>
        /// Gets the average total of all the pokemon the user has from database
        /// </summary>
        /// <returns>list of users</returns>
        List<User> RetrieveUserStat();
        /// <summary>
        /// Gets all the users number of pokemon
        /// </summary>
        /// <returns>a list of all users</returns>
        List<User> RetrieveUserNumPokemon();
        /// <summary>
        /// creates a new pokemon
        /// </summary>
        /// <param name="generationNum">generation number of the pokemon</param>
        /// <param name="name">name of the pokemon</param>
        /// <param name="baseHP">base HP of the pokemon</param>
        /// <param name="attack">attack of the pokemon</param>
        /// <param name="defense">defense of the pokemon</param>
        /// <param name="speed">speed of the pokemon</param>
        /// <param name="pelem">first element type of the pokemon</param>
        /// <param name="selem">second element type of the pokemon</param>
        /// <returns>the new Pokemon object</returns>
        Pokemon CreatePokemon(int generationNum, string name, int baseHP, int attack, int defense, int speed, ElementType pelem, ElementType selem);
        /// <summary>
        /// creates a new user
        /// </summary>
        /// <param name="email">email of the user</param>
        void CreateUser(string email);
        /// <summary>
        /// fetches the pokemon with the specified name
        /// </summary>
        /// <param name="name">name of a pokemon</param>
        /// <returns>found Pokemon object</returns>
        Pokemon FetchPokemon(string name);
        /// <summary>
        /// gets the pokemon with the specified name
        /// </summary>
        /// <param name="name">name of a pokemon</param>
        /// <returns>found Pokemon object</returns>
        Pokemon GetPokemon(string name);
        /// <summary>
        /// gets the user with the specified email
        /// </summary>
        /// <param name="email">email of the user</param>
        /// <returns>found User object</returns>
        User GetUser(string email);
        /// <summary>
        /// adds the pokemon to the user
        /// </summary>
        /// <param name="pokemon">Pokemon object</param>
        /// <param name="nickname">Pokemon nickname</param>
        void AddPokemon(int pokemonID, string nickname, string email);
    }
}
