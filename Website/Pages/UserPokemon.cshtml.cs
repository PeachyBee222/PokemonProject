using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonProject.Data.Models;
using PokemonProject.Data;
using PokemonProject.Data.Models;

namespace Website.Pages
{
    public class UserPokemonModel : PageModel
    {
        /// <summary>
        ///  Starts the webpage
        /// </summary>
        /// <param name="SearchUser">the terms to search for</param>
        /// <param name="TotalMin">for filtering total</param>
        /// <param name="TotalMax">for filtering total</param>
        /// <param name="ElementFilter"> for filtering elements</param>
        public void OnGet(string SearchUser, uint? TotalMin, uint? TotalMax, string? ElementFilter)
        {
            //This can go once we have our data in, its an example of how to get the data
            //MenuItems = Menu.FullMenu;
            Users = TestUsers();
            UserPokemon = TestPokemon();
            AllPokemon = TestPokemon();

            this.SearchUser = SearchUser;

            this.TotalMax = TotalMax;
            this.TotalMin = TotalMin;

            ElementType element;
            if (Enum.TryParse<ElementType>(ElementFilter, true, out element))
            {
                this.ElementFilter = element;
            }
            else
            {
                this.ElementFilter = null;
            }

            UserPokemon = Search(SearchUser);

            UserPokemon = FilterByTotal(UserPokemon, TotalMin, TotalMax);
            UserPokemon = FilterByElement(UserPokemon, element);

        }

        /// <summary>
        /// Test for the pokemon database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Pokemon> TestPokemon()
        {
            List<Pokemon> testPokemon = new List<Pokemon>();

            for (int i = 1; i <= 50; i++)
            {
                Pokemon temp = new Pokemon(i, 1, "Some Pokemon", 1, 1, 1, 1, ElementType.fire, null);
                testPokemon.Add(temp);
            }

            return testPokemon;
        }

        /// <summary>
        /// Test for the user database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> TestUsers()
        {
            List<User> testUser = new List<User>();

            for (int i = 1; i <= 50; i++)
            {
                string email = i + "@gmail.com";
                User temp = new User(i, email);
                testUser.Add(temp);
            }
            return testUser;
        }
        /// <summary>
        /// The list of pokemon for the database to display, FIXME might not need
        /// </summary>
        public IEnumerable<Pokemon>? AllPokemon
        {
            get; protected set;
        }

        /// <summary>
        /// The list of pokemon for the specific user
        /// </summary>
        public IEnumerable<Pokemon>? UserPokemon
        {
            get; protected set;
        }

        /// <summary>
        /// The list of users for the program
        /// </summary>
        public IEnumerable<User>? Users { get; protected set; }

        /// <summary>
        /// the maximum bound for the total
        /// </summary>
        public uint? TotalMax { get; set; }
        /// <summary>
        /// the minimum bound for the total
        /// </summary>
        public uint? TotalMin { get; set; }

        /// <summary>
        /// the element being filtered
        /// </summary>
        public ElementType? ElementFilter { get; set; }

        /// <summary>
        /// The input in the search bar
        /// </summary>
        public string? SearchUser
        {
            get;
            set;
        }

        /// <summary>
        /// Filters by the search words passed in
        /// </summary>
        /// <param name="terms">the words to search for</param>
        /// <returns>the list with items that have the terms in it</returns>
        public IEnumerable<Pokemon> Search(string userEmail)
        {
            List<Pokemon> results = new List<Pokemon>();
            if (userEmail == null)
            {
                return AllPokemon;
            }
            
            foreach (User user in Users)
            {
                //if we find the user we are searching for
                if(user.Email == userEmail)
                {
                    //FIXME send this through a delegate to get the pokemon needed
                    //idea for getting nickanem
                    /*
                     *  Loop through each pokemon the user has
                     *  then loop through each userpokemon the user has
                     *  when the pokemon id's match, ???
                     *  
                     *  
                     *  or sort both of the lists, by pokemonid
                     *  then the indexes should line up
                     *  
                     *  we could have SQL return a list of tuples or a dictionary
                     *  var tupleList = new IEnumerable<(Pokemon, UserPokemon)>;
                     */
                }

            }
            return AllPokemon; //FIX TO RESULTS WHEN READY
        }

        /// <summary>
        /// Filters by the specified total
        /// </summary>
        /// <param name="items">the items to filter</param>
        /// <param name="min">the minimum bound</param>
        /// <param name="max">the maximum bound</param>
        /// <returns>the items between the minimum and maximum bounds of calories</returns>
        public IEnumerable<Pokemon> FilterByTotal(IEnumerable<Pokemon> items, uint? min, uint? max)
        {
            if (min == null && max == null) return items;
            var results = new List<Pokemon>();

            // only a maximum specified
            if (min == null)
            {
                foreach (Pokemon item in items)
                {
                    if (item.Total <= max) results.Add(item);
                }
                return results;
            }

            // only a minimum specified
            if (max == null)
            {
                foreach (Pokemon item in items)
                {
                    if (item.Total >= min) results.Add(item);
                }
                return results;
            }

            // Both minimum and maximum specified
            foreach (Pokemon item in items)
            {
                if (item.Total >= min && item.Total <= max)
                {
                    results.Add(item);
                }
            }
            return results;
        }

        /// <summary>
        /// Filters by the specified element
        /// </summary>
        /// <param name="items">the items to filter</param>
        /// <param name="element">the element wanted</param>
        /// <returns>the items with the given element</returns>
        public IEnumerable<Pokemon> FilterByElement(IEnumerable<Pokemon> items, ElementType? element)
        {
            if (element == null) return items;
            var results = new List<Pokemon>();

            foreach (Pokemon item in items)
            {
                if (item.Pelem == element) results.Add(item);
                else if (item.Selem == element) results.Add(item);
            }
            return results;

        }
    }
}
