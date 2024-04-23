using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Xml.Linq;
using TheFlyingSaucer.Data;
using TheFlyingSaucer.Data.Models;

namespace Website.Pages
{
    public class CreatePokemonModel : PageModel
    {
        /// <summary>
        /// Private backing  variable
        /// </summary>
        private readonly IPokemonRepository _pokemonRepository;

        /// <summary>
        /// links the pokemon repository to the page
        /// </summary>
        /// <param name="pokemonRepository"></param>
        public CreatePokemonModel(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        /// <summary>
        /// Happens after the user presses submit. 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="speed"></param>
        /// <param name="hp"></param>
        /// <param name="gen"></param>
        /// <param name="pelement"></param>
        /// <param name="selement"></param>
        public void OnPost(string name, int attack, int defense, int speed, int hp, int gen, string pelement, string selement)
        {
            Submit(name, attack, defense, speed, hp, gen, pelement, selement);
        }
        /// <summary>
        /// submits the information to SQL with creating a pokemon
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="speed"></param>
        /// <param name="hp"></param>
        /// <param name="gen"></param>
        /// <param name="pelement"></param>
        /// <param name="selement"></param>
        public void Submit(string name, int attack, int defense, int speed, int hp, int gen,string pelement, string selement)
        {
            //send this information to the create pokemon page
            ElementType p;
            ElementType primary;
            ElementType secondary;
            if (Enum.TryParse<ElementType>(pelement, true, out p))
            {
                primary = p;
            }
            else
            {
                primary = ElementType.none;
            }
            if (Enum.TryParse<ElementType>(selement, true, out p))
            {
                secondary = p;
            }
            else
            {
                secondary = ElementType.none;
            }

            //send all of the attributes to SQL using primary and secondary
            _pokemonRepository.CreatePokemon(gen, name, hp, attack, defense, speed, primary, secondary);
        }
    }
}
