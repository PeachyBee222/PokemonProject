﻿using TheFlyingSaucer.Data.Models;

namespace TheFlyingSaucer.Data
{
    public interface IPokemonRepository
    {
        IReadOnlyList<Pokemon> RetrievePokemons();
        Pokemon FetchPokemon(string name);
        Pokemon GetPokemon(string name);
        Pokemon CreatePokemon(int generationNum, string name, int baseHP, int attack, int defense, int speed);
    }
}
