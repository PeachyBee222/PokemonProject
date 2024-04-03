using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PokemonProject.Data;
using Website.Pages;

namespace PokemonProjectPokemonProject.DataTests
{
    /*
    /// <summary>
    /// the unit tests for our search and filtering in the index page
    /// </summary>
    public class IndexPageUnitTests
    {
        /// <summary>
        /// tests to make sure you can get the about page
        /// </summary>
        [Fact]
        public void GetAboutPage()
        {
            var model = new TimeModel();
            model.OnGet();
        }

        /// <summary>
        /// tests to make sure you can get the about page
        /// </summary>
        [Fact]
        public void GetIndexPage()
        {
            var model = new IndexModel();
            model.OnGet(null, true, true, true, null, null, null, null);
            Assert.Equal(Menu.FullMenu.Count(), model.MenuItems.Count());
            Assert.Equal(Menu.Entrees.Count(), model.Entrees.Count());
            Assert.Equal(Menu.Sides.Count(), model.Sides.Count());
            Assert.Equal(Menu.Drinks.Count(), model.Drinks.Count());
        }

        /// <summary>
        /// tests to make sure you can get the about page
        /// </summary>
        [Fact]
        public void GetPrivacyPage()
        {
            var model = new PrivacyModel();
            model.OnGet();
        }

        /// <summary>
        /// Tests the onget method
        /// </summary>
        /// <param name="terms">the search terms</param>
        /// <param name="entree">true if show entrees</param>
        /// <param name="side">true if show sides</param>
        /// <param name="drink">true if show drinks</param>
        /// <param name="cmax"> max for calories is set</param>
        /// <param name="cmin">min for calories</param>
        /// <param name="pmax">max for price</param>
        /// <param name="pmin">min for price</param>
        /// <param name="entrees">entree expected count</param>
        /// <param name="sides">side expected count</param>
        /// <param name="drinks">drink expected count</param>
        [Theory]
        [InlineData("Saucer", true, true, true, null, null, null, null, 2, 0, 3)]
        [InlineData(null, true, true, true, null, 200u, null, null, 4, 4, 1)]
        [InlineData(null, true, true, true, 200u, null, null, null, 0, 3, 8)]
        public void TestIndexPageOnGet(string terms, bool entree, bool side, bool drink, uint? cmax, uint? cmin, decimal? pmax, decimal? pmin, int entrees, int sides, int drinks )
        {
            var model = new IndexModel();
            model.OnGet(terms, entree, side, drink, cmin, cmax, pmin, pmax);

            Assert.Equal(entrees, model.Entrees.Count());
            Assert.Equal(sides, model.Sides.Count());
            Assert.Equal(drinks, model.Drinks.Count());
        }

        /// <summary>
        /// Tests the checkbox functionality for entree sides and drinks
        /// </summary>
        [Fact]
        public void TestsCheckboxes()
        {
            var model = new IndexModel();
            model.OnGet(null, false, true, true, null, null, null, null);
            Assert.True(model.IncludeSides);
            Assert.True(model.IncludeDrinks);
            Assert.False(model.IncludeEntrees);
        }
        /// <summary>
        /// tests the price filters properly
        /// </summary>
        [Fact]
        public void TestsPriceMaxBounds()
        {
            var model = new IndexModel();
            decimal? max = 6;
            model.OnGet(null, true, true, true, null, null, null, max);
            Assert.Equal(0, model.Entrees.Count());
            Assert.Equal(6, model.Sides.Count());
            Assert.Equal(9, model.Drinks.Count());
        }

        /// <summary>
        /// tests the price filters properly
        /// </summary>
        [Fact]
        public void TestsPriceMinBounds()
        {
            var model = new IndexModel();
            decimal? min = 6;
            model.OnGet(null, true, true, true, null, null, min, null);
            Assert.Equal(4, model.Entrees.Count());
            Assert.Equal(0, model.Sides.Count());
            Assert.Equal(0, model.Drinks.Count());
        }
    }
    */
}
