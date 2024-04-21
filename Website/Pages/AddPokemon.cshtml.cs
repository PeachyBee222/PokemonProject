using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheFlyingSaucer.Data.DataDelegates;

namespace Website.Pages
{
    public class AddPokemonModel : PageModel
    {
        public void OnGet(string email, string nickname, int pokemonid)
        {

            Submit(email, nickname, pokemonid);

        }
        /// <summary>
        /// Adds the given data to the users pokemon based off their email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="nickname"></param>
        /// <param name="pokemonid"></param>
        public void Submit(string email, string nickname, int pokemonid)
        {
            //Add this to the user pokemon //fixme what next???
            AddPokemonDataDelegate a = new AddPokemonDataDelegate(pokemonid, nickname, email);
            
        }
    }
}
