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

        public Pokemon CreatePokemon(int generationNum, string name, int baseHP, int attack, int defense, int speed, ElementType pelem, ElementType selem)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The parameter cannot be null or empty.", nameof(name));

            var d = new CreatePokemonDataDelegate(generationNum, name, baseHP, attack, defense, speed, pelem, selem);
            return executor.ExecuteNonQuery(d);
        }
        /// <summary>
        /// gets all of the pokemon from the database
        /// </summary>
        /// <returns>a list of all pokemon</returns>
        public List<Pokemon> RetrievePokemons()
        {
            return executor.ExecuteReader(new RetrievePokemonDataDelegate());
        }
    }
}
