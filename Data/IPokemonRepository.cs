using PokemonProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProject.Data
{
    public interface IPokemonRepository
    {
        IReadOnlyList<Pokemon> RetrievePokemons();
        Pokemon FetchPokemon(string name);
        Pokemon GetPokemon(string name);
        Pokemon CreatePokemon(int generationNum, string name, int baseHP, int attack, int defense, int speed);
    }
}
