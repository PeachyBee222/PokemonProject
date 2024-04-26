using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonCollections.Data;


namespace Website.Pages
{
    public class CreateAccountModel : PageModel
    {
        private readonly IPokemonRepository _pokemonRepository;

        public CreateAccountModel(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public void OnPost(string email)
        {
            Submit(email);
        }

        /// <summary>
        /// This will send the account information to SQL for creating a new account
        /// </summary>
        /// <param name="email"></param>
        public void Submit(string email)
        {
            // Example of using _pokemonRepository to create a new user
            _pokemonRepository.CreateUser(email);
        }

    }
}
