using TheFlyingSaucer.Data.Models;

namespace TheFlyingSaucer.Data
{
    public interface IPokemonRepository
    {
        List<Pokemon> RetrievePokemons();
        Pokemon CreatePokemon(int generationNum, string name, int baseHP, int attack, int defense, int speed, ElementType pelem, ElementType selem, int numUsers);
    }
}
