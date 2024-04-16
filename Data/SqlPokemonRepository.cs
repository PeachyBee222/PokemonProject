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

        public Pokemon FetchPokemon(string name)
        {
            var d = new FetchPokemonDataDelegate(name);
            return executor.ExecuteReader(d);
        }

        public Pokemon GetPokemon(string name)
        {
            var d = new GetPokemonDataDelegate(name);
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<Pokemon> RetrievePokemons()
        {
            return executor.ExecuteReader(new RetrievePokemonDataDelegate());
        }
    }
}
