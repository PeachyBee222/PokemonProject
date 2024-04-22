using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheFlyingSaucer.Data.Models;
using TheFlyingSaucer.Data;
using TheFlyingSaucer.Data.Models;

namespace Website.Pages
{
    //Be careful before editing name here, the HTML that uses this needs the .MenuModel
    public class PokemonModel : PageModel
    {
        /// <summary>
        /// Private backing  variable
        /// </summary>
        private readonly IPokemonRepository _pokemonRepository;

        /// <summary>
        /// links the pokemon repository to the page
        /// </summary>
        /// <param name="pokemonRepository"></param>
        public PokemonModel(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        /// <summary>
        ///  Starts the webpage
        /// </summary>
        /// <param name="SearchTerms">the terms to search for</param>
        /// <param name="TotalMin">for filtering total</param>
        /// <param name="TotalMax">for filtering total</param>
        /// <param name="ElementFilter"> for filtering elements</param>
        public void OnGet(string SearchTerms, uint? TotalMin, uint? TotalMax, string? ElementFilter)
        {
            //the following are for pokemon testing FIXME
            PokemonInfo = GetPokemon(); //may put this in the constructor if needed
            GenerationPop = TestGeneration();
            TopUserStat = TestStatBlockTotal();
            TopUserNumPokemon = TestNumPokemon();

            //This can go once we have our data in, its an example of how to get the data

            this.SearchTerms = SearchTerms;

            this.TotalMax = TotalMax;
            this.TotalMin = TotalMin;

            ElementType element;
            if(Enum.TryParse<ElementType>(ElementFilter,true, out element))
            {
                this.ElementFilter = element;
            }
            else
            {
                this.ElementFilter = null;
            }

            PokemonInfo = Search(SearchTerms);

            PokemonInfo = FilterByTotal(PokemonInfo, TotalMin, TotalMax);
            PokemonInfo = FilterByElement(PokemonInfo, element);

        }
        /// <summary>
        /// Gets a list of pokemon from SQL
        /// </summary>
        /// <returns>a list of all of the pokemon</returns>
        public List<Pokemon> GetPokemon()
        {
            //use the retrieve pokemon delegate
            List<Pokemon> allPokemon = _pokemonRepository.RetrievePokemons();
            return allPokemon;
        }
        /// <summary>
        /// gets a list of the top 3 generations
        /// </summary>
        /// <returns></returns> FIXME need this in the repository
        //public List<Generation> GetGeneration()
        //{
        //    List<Generation> generations = _pokemonRepository.GetGeneration;
        //}
        //public List<User> GetUserStat()
        //{
        //    List<User> users = _pokemonRepository.RetrieveUsersStat();
        //}
        //
        //public List<User> GetUserNumPokemon()
        //{
        //  List<User> users = _pokemonRepostiony.RetriveUserNumPokemon();
        //}


        /// <summary>
        /// Test for the pokemon database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Pokemon> TestPokemon()
        {
            List<Pokemon> testPokemon = new List<Pokemon>();

            for(int i = 1; i <= 50; i++)
            {
                Pokemon temp = new Pokemon(i, 1, "Some Pokemon", 1, 1, 1, 1, ElementType.fire, null, 0);
                testPokemon.Add(temp);
            }

            return testPokemon;
        }

        /// <summary>
        /// Test for the generation stats
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Generation> TestGeneration()
        {
            List<Generation> TestGen = new List<Generation>();
            Generation one = new Generation(1, 5);
            Generation two = new Generation(2, 10);
            Generation three = new Generation(3, 15);
            TestGen.Add(one);
            TestGen.Add(two);
            TestGen.Add(three);
            return TestGen;
        }
        /// <summary>
        /// This is for the top 3 users considering their average
        /// pokemons total (so total of all pokemon / num of all pokemon)
        /// </summary>
        /// <returns>Needs the user email and the number they have</returns>
        public IEnumerable<int> TestStatBlockTotal()
        {
            List<int> TestStat = new List<int>();
            TestStat.Add(10);
            TestStat.Add(20);
            TestStat.Add(30);
            return TestStat;
        }
        /// <summary>
        /// This is for the total number of pokemon the top 3 users own
        /// </summary>
        /// <returns>a list of the top 3 users</returns>
        public IEnumerable<int> TestNumPokemon()
        {
            List<int> testNum = new List<int>();
            testNum.Add(10);
            testNum.Add(20);
            testNum.Add(30);
            return testNum;
        }

        /// <summary>
        /// The list of pokemon for the database to display
        /// </summary>
        public IEnumerable<Pokemon>? PokemonInfo
        {
            get; protected set;
        }

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
        public IEnumerable<int>? TopUserStat
        {
            get; protected set;
        }

        /// <summary>
        /// a list of 3 users with the most pokemon
        /// </summary>
        public IEnumerable<int>? TopUserNumPokemon
        {
            get; protected set;
        }

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
        public string? SearchTerms
        {
            get;
            set;
        }
        /// <summary>
        /// Filters by the search words passed in
        /// </summary>
        /// <param name="terms">the words to search for</param>
        /// <returns>the list with items that have the terms in it</returns>
        public IEnumerable<Pokemon> Search(string terms)
        {
            List<Pokemon> results = new List<Pokemon>();
            if(terms == null)
            {
                return PokemonInfo;
            }
            string[] temp = terms.Split();
            foreach (Pokemon item in PokemonInfo)
            {
                for(int i = 0; i < temp.Length; i++)
                {
                    if (item.Name != null && item.Name.Contains(temp[i], StringComparison.CurrentCultureIgnoreCase))
                    {
                        results.Add(item);
                    }
                }
                
            }
            return results;
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