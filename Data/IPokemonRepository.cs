using PokemonProject.Data.Models;

namespace PokemonProject.Data
{
    public interface IPokemonRepository
    {
        void CreatePokemon(int generationNum, string name, int baseHP, int attack, int defense, int speed);
        void CreateUser(string email);
        Pokemon FetchPokemon(string name);
        Pokemon GetPokemon(string name);
        User GetUser(string email);
        void AddPokemon(int PokemonID, string nickname);
        IReadOnlyList<Pokemon> RetrievePokemons();
        IReadOnlyList<User> RetrieveUsers();
    }
}
