using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonCollections.Data.Models;
using PokemonCollections.Data;

namespace Website.Pages
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Private backing  variable
        /// </summary>
        private readonly IPokemonRepository _pokemonRepository;

        /// <summary>
        /// a list of generations with the number of pokemon used by all the users
        /// </summary>
        public IEnumerable<Generation>? GenerationPop
        {
            get; protected set;
        }

        /// <summary>
        /// a list of 3 users with the best average pokemon totals
        /// </summary>
        public IEnumerable<User>? TopUserStat
        {
            get; protected set;
        }

        /// <summary>
        /// a list of 3 users with the most pokemon
        /// </summary>
        public IEnumerable<User>? TopUserNumPokemon
        {
            get; protected set;
        }

        /// <summary>
        /// links the pokemon repository to the page
        /// </summary>
        /// <param name="pokemonRepository"></param>
        public IndexModel(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public void OnGet()
        {
            GenerationPop = GetGeneration();
            TopUserStat = GetUserStat();
            TopUserNumPokemon = GetUserNumPokemon();
        }
        /// <summary>
        /// gets a list of the top 3 generations
        /// </summary>
        /// <returns>a list of generations</returns>
        public List<Generation> GetGeneration()
        {
            List<Generation> generations = _pokemonRepository.RetrieveGenerations();
            return generations;
        }
        /// <summary>
        /// Gets the users and their average pokemon total stats
        /// </summary>
        /// <returns>a list of users</returns>
        public List<User> GetUserStat()
        {
            List<User> users = _pokemonRepository.RetrieveUserStat();
            return users;
        }
        /// <summary>
        /// gets the users total number of pokemon
        /// </summary>
        /// <returns>a list of users</returns>
        public List<User> GetUserNumPokemon()
        {
            List<User> users = _pokemonRepository.RetrieveUserNumPokemon();
            return users;
        }
    }
}
