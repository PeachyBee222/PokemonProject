using TheFlyingSaucer.Data.Models;

namespace TheFlyingSaucer.Data
{
    public interface IPokemonRepository
    {
        List<Pokemon> RetrievePokemons();
        List<User> RetrieveUsers();
        Pokemon CreatePokemon(int generationNum, string name, int baseHP, int attack, int defense, int speed, ElementType pelem, ElementType selem, int numUsers);
        void CreateUser(string email);
        Pokemon FetchPokemon(string name);
        Pokemon GetPokemon(string name);
        User GetUser(string email);
        void AddPokemon(Pokemon pokemon, string nickname);
    }
}
