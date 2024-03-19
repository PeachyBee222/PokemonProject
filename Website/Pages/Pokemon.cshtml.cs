using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheFlyingSaucer.Data;

namespace Website.Pages
{
    public class MenuModel : PageModel
    {
        /*
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        */

        /// <summary>
        /// Starts the webpage
        /// </summary>
        /// <param name="SearchTerms">the terms to look for</param>
        /// <param name="IncludeEntrees">if they should have entrees displayed</param>
        /// <param name="IncludeSides">if they should have sides displayed</param>
        /// <param name="IncludeDrinks">if they should have drinks displayed</param>
        /// <param name="CaloriesMin">the calories minimum restriction</param>
        /// <param name="CaloriesMax">the calories maximum restriction</param>
        /// <param name="PriceMin">the price minimum restriction</param>
        /// <param name="PriceMax">the price maximum restriction</param>
        public void OnGet(string SearchTerms, bool IncludeEntrees, bool IncludeSides, bool IncludeDrinks, uint? CaloriesMin, uint? CaloriesMax, decimal? PriceMin, decimal? PriceMax)
        {
            MenuItems = Menu.FullMenu;
            Sides = Menu.Sides;
            Entrees = Menu.Entrees;
            Drinks = Menu.Drinks;

            this.IncludeEntrees = IncludeEntrees;
            this.IncludeDrinks = IncludeDrinks;
            this.IncludeSides = IncludeSides;

            this.SearchTerms = SearchTerms;
            this.PriceMax = PriceMax;
            this.PriceMin = PriceMin;
            this.CaloriesMax = CaloriesMax;
            this.CaloriesMin = CaloriesMin;

            MenuItems = Search(SearchTerms);

            MenuItems = FilterByCalories(MenuItems, CaloriesMin, CaloriesMax);
            MenuItems = FilterByPrice(MenuItems, PriceMin, PriceMax);

            Drinks = FilterByDrink(MenuItems,true);
            Sides = FilterBySide(MenuItems,true);
            Entrees = FilterByEntree(MenuItems,true);

        }
        /// <summary>
        /// the maximum bound for the price
        /// </summary>
        public decimal? PriceMax { get; set; }
        /// <summary>
        /// the minimum bound for the price
        /// </summary>
        public decimal? PriceMin { get; set; }
        /// <summary>
        /// the maximum bound for the calories
        /// </summary>
        public uint? CaloriesMax { get; set; }
        /// <summary>
        /// the minimum bound for the calories
        /// </summary>
        public uint? CaloriesMin { get; set; }

        /// <summary>
        /// The filter for the sides
        /// </summary>
        public bool IncludeSides { get; set; } = true;

        /// <summary>
        /// The filter for the drinks
        /// </summary>
        public bool IncludeDrinks { get; set; } = true;

        /// <summary>
        /// The filter for the entrees
        /// </summary>
        public bool IncludeEntrees { get; set; } = true;

        /// <summary>
        /// The full list of menu items
        /// </summary>
        public IEnumerable<IMenuItem>? MenuItems
        {
            get; protected set;
        }
        /// <summary>
        /// list of all the sides
        /// </summary>
        public IEnumerable<IMenuItem>? Sides
        {
            get; protected set;
        }
        /// <summary>
        /// list of all the entrees
        /// </summary>
        public IEnumerable<IMenuItem>? Entrees
        {
            get; protected set;
        }
        /// <summary>
        /// list of all the drinks
        /// </summary>
        public IEnumerable<IMenuItem>? Drinks
        {
            get; protected set;
        }

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
        public IEnumerable<IMenuItem> Search(string terms)
        {
            List<IMenuItem> results = new List<IMenuItem>();
            if(terms == null)
            {
                return MenuItems;
            }
            string[] temp = terms.Split();
            foreach (IMenuItem item in MenuItems)
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
        /// Filters the menu items by entree
        /// </summary>
        /// <param name="items">the menu items</param>
        /// <param name="filter">if it should be filtered by entree or not</param>
        /// <returns>the list of menu items filtered</returns>
        public IEnumerable<IMenuItem> FilterByEntree(IEnumerable<IMenuItem> items, bool filter)
        {
            if (filter == false) return items;
            List<IMenuItem> result = new List<IMenuItem>();
            foreach(IMenuItem item in items)
            {
                if(item is Entree)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        /// <summary>
        /// Filters the menu items by side
        /// </summary>
        /// <param name="items">the menu items</param>
        /// <param name="filter">if they should be filtered or not</param>
        /// <returns>the list of menu items filtered</returns>
        public IEnumerable<IMenuItem> FilterBySide(IEnumerable<IMenuItem> items, bool filter)
        {
            if (filter == false) return items;
            List<IMenuItem> result = new List<IMenuItem>();
            foreach (IMenuItem item in items)
            {
                if (item is Side)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        /// <summary>
        /// Filters the menu items by drink
        /// </summary>
        /// <param name="items">the menu items</param>
        /// <param name="filter">true if the items should be filtered</param>
        /// <returns>the filtered items</returns>
        public IEnumerable<IMenuItem> FilterByDrink(IEnumerable<IMenuItem> items, bool filter)
        {
            if (filter == false) return items;
            List<IMenuItem> result = new List<IMenuItem>();
            foreach (IMenuItem item in items)
            {
                if (item is Drink)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        /// <summary>
        /// Filters by the specified calories
        /// </summary>
        /// <param name="items">the items to filter</param>
        /// <param name="min">the minimum bound</param>
        /// <param name="max">the maximum bound</param>
        /// <returns>the items between the minimum and maximum bounds of calories</returns>
        public IEnumerable<IMenuItem> FilterByCalories(IEnumerable<IMenuItem> items, uint? min, uint? max)
        {
            if (min == null && max == null) return items;
            var results = new List<IMenuItem>();

            // only a maximum specified
            if (min == null)
            {
                foreach (IMenuItem item in items)
                {
                    if (item.Calories <= max) results.Add(item);
                }
                return results;
            }

            // only a minimum specified
            if (max == null)
            {
                foreach (IMenuItem item in items)
                {
                    if (item.Calories >= min) results.Add(item);
                }
                return results;
            }

            // Both minimum and maximum specified
            foreach (IMenuItem item in items)
            {
                if (item.Calories >= min && item.Calories <= max)
                {
                    results.Add(item);
                }
            }
            return results;
        }

        /// <summary>
        /// Filters by the specified prices
        /// </summary>
        /// <param name="items">the items to filter</param>
        /// <param name="min">the minimum bound</param>
        /// <param name="max">the maximum bound</param>
        /// <returns>the items between the minimum and maximum bounds of price</returns>
        public IEnumerable<IMenuItem> FilterByPrice(IEnumerable<IMenuItem> items, decimal? min, decimal? max)
        {
            if (min == null && max == null) return items;
            var results = new List<IMenuItem>();

            // only a maximum specified
            if (min == null)
            {
                foreach (IMenuItem item in items)
                {
                    if (item.Price <= max) results.Add(item);
                }
                return results;
            }

            // only a minimum specified
            if (max == null)
            {
                foreach (IMenuItem item in items)
                {
                    if (item.Price >= min) results.Add(item);
                }
                return results;
            }

            // Both minimum and maximum specified
            foreach (IMenuItem item in items)
            {
                if (item.Price >= min && item.Price <= max)
                {
                    results.Add(item);
                }
            }
            return results;
        }
    }
}