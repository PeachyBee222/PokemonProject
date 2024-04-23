using DataAccess2;
using TheFlyingSaucer.Data.Models;
using TheFlyingSaucer.Data.DataDelegates;

namespace TheFlyingSaucer.Data
{
    public class SqlPokemonRepository : IPokemonRepository
    {
        private readonly SqlCommandExecutor executor;
        
        public SqlPokemonRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }
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
        /// <exception cref="ArgumentException"></exception>
        public Pokemon CreatePokemon(int generationNum, string name, int baseHP, int attack, int defense, int speed, ElementType pelem, ElementType selem)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The parameter cannot be null or empty.", nameof(name));

            var d = new CreatePokemonDataDelegate(generationNum, name, baseHP, attack, defense, speed, pelem, selem);
            return executor.ExecuteNonQuery(d);
        }
        /// <summary>
        /// creates a new user
        /// </summary>
        /// <param name="email">email of the user</param>
        /// <exception cref="ArgumentException"></exception>
        public void CreateUser(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("The parameter cannot be null or empty.", nameof(email));

            var d = new CreateUserDataDelegate(email);
            executor.ExecuteNonQuery(d);
        }
        /// <summary>
        /// fetches the pokemon with the specified name
        /// </summary>
        /// <param name="name">name of a pokemon</param>
        /// <returns>found Pokemon object</returns>
        public Pokemon FetchPokemon(string name)
        {
            var d = new FetchPokemonDataDelegate(name);
            return executor.ExecuteReader(d);
        }
        /// <summary>
        /// gets the pokemon with the specified name
        /// </summary>
        /// <param name="name">name of a pokemon</param>
        /// <returns>found Pokemon object</returns>
        public Pokemon GetPokemon(string name)
        {
            var d = new GetPokemonDataDelegate(name);
            return executor.ExecuteReader(d);
        }
        /// <summary>
        /// gets the user with the specified email
        /// </summary>
        /// <param name="email">email of the user</param>
        /// <returns>found User object</returns>
        public User GetUser(string email)
        {
            var d = new GetUserDataDelegate(email);
            return executor.ExecuteReader(d);
        }
        /// <summary>
        /// adds the pokemon to the user
        /// </summary>
        /// <param name="pokemon">Pokemon object</param>
        /// <param name="nickname">Pokemon nickname</param>
        public void AddPokemon(int pokemonID, string nickname, string email)
        {
            var d = new AddPokemonDataDelegate(pokemonID, nickname, email);
            executor.ExecuteNonQuery(d);
        }
        /// <summary>
        /// gets all of the pokemon from the database
        /// </summary>
        /// <returns>a list of all pokemon</returns>
        public List<Pokemon> RetrievePokemons()
        {
            return executor.ExecuteReader(new RetrievePokemonDataDelegate());
        }
        /// <summary>
        /// gets all of the users from the database
        /// </summary>
        /// <returns>a list of all users</returns>
        public List<User> RetrieveUsers()
        {
            return executor.ExecuteReader(new RetrieveUserDataDelegate());
        }
        /// <summary>
        /// gets all the generations from the database
        /// </summary>
        /// <returns>list of all generations</returns>
        public List<Generation> RetrieveGenerations()
        {
            return executor.ExecuteReader(new CreatureUsePerGenerationDataDelegate());
        }
        /// <summary>
        /// gets all of the users average total from the database
        /// </summary>
        /// <returns>a list of all users</returns>
        public List<User> RetrieveUserStat()
        {
            return executor.ExecuteReader(new GetUserStatBlockRankingDataDelegate());
        }
        /// <summary>
        /// gets all of the users number of pokemon
        /// </summary>
        /// <returns>a list of all users</returns>
        public List<User> RetrieveUserNumPokemon()
        {
            return executor.ExecuteReader(new GetUserRanksDataDelegate());
        }
        /// <summary>
        /// gets the pokemon associated with the user
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Dictionary<User, Pokemon> GetUserPokemon(string email)
        {
            return executor.ExecuteReader(new GetUserDataDelegate(email));
        }
    }
}
