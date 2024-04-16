using PokemonProject.Data.Models;

namespace PokemonProject.Data
{
    public interface IPokemonRepository
    {
        Pokemon CreatePokemon(int generationNum, string name, int baseHP, int attack, int defense, int speed);
        User CreateUser(string email);
        Pokemon FetchPokemon(string name);
        Pokemon GetPokemon(string name);
        User GetUser(string email);
        IReadOnlyList<Pokemon> RetrievePokemons();
        IReadOnlyList<User> RetrieveUsers();
    }
}
