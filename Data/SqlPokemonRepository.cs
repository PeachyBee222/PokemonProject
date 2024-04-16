using DataAccess;
using PokemonProject.Data.Models;
using PokemonProject.Data.DataDelegates;

namespace PokemonProject.Data
{
    public class SqlPokemonRepository : IPokemonRepository
    {
        private readonly SqlCommandExecutor executor;
        
        public SqlPokemonRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }

        public Pokemon CreatePokemon(int generationNum, string name, int baseHP, int attack, int defense, int speed)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The parameter cannot be null or empty.", nameof(name));

            var d = new CreatePokemonDataDelegate(generationNum, name, baseHP, attack, defense, speed);
            return executor.ExecuteNonQuery(d);
        }

        public User CreateUser(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("The parameter cannot be null or empty.", nameof(email));

            var d = new CreateUserDataDelegate(email);
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

        public User GetUser(string email)
        {
            var d = new GetUserDataDelegate(email);
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<Pokemon> RetrievePokemons()
        {
            return executor.ExecuteReader(new RetrievePokemonDataDelegate());
        }
    }
}
