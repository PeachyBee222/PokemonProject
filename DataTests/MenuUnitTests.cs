using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonProject.Data;

namespace PokemonProject.DataTests
{
    /// <summary>
    /// The unit tests for the menu class
    /// </summary>
    public class MenuUnitTests
    {
        /// <summary>
        /// the count of entrees is correct
        /// </summary>
        [Fact]
        public void CountOfEntreesIsCorrect()
        {
            Assert.Equal(4, Menu.Entrees.Count());
        }
        /// <summary>
        /// the count of sides is correct
        /// </summary>
        [Fact]
        public void CountOfSidesIsCorrect()
        {
            Assert.Equal(6, Menu.Sides.Count());
        }
        /// <summary>
        /// the count of drinks is correct
        /// </summary>
        [Fact]
        public void CountOfDrinksIsCorrect()
        {
            Assert.Equal(9, Menu.Drinks.Count());
        }
        /// <summary>
        /// tests to make sure each entree is in the menu.entrees
        /// </summary>
        [Fact]
        public void EachCombinationExistsInEntrees()
        {
            List<IMenuItem> list = new List<IMenuItem>();
            list.Add(new CrashedSaucer());
            list.Add(new FlyingSaucer());
            list.Add(new LivestockMutilation());
            list.Add(new OuterOmelette());
            foreach (IMenuItem item in Menu.Entrees)
            {
                Assert.Contains(Menu.Entrees, (x) =>
                {
                    return item.GetType() == x.GetType();
                });
            }
        }
        /// <summary>
        /// tests to make sure each side is in the menu.sides
        /// </summary>
        [Fact]
        public void EachCombinationExistsInSides()
        {
            List<IMenuItem> list = new List<IMenuItem>();
            list.Add(new CropCircle());
            list.Add(new EvisceratedEggs());
            list.Add(new GlowingHaystack());
            list.Add(new MissingLinks());
            list.Add(new TakenBacon());
            list.Add(new YouAreToast());
            foreach (IMenuItem item in Menu.Sides)
            {
                Assert.Contains(Menu.Sides, (x) =>
                {
                    return item.GetType() == x.GetType();
                });
            }
        }
        /// <summary>
        /// tests to make sure each drink is in the menu.drinks
        /// </summary>
        [Fact]
        public void EachCombinationExistsInDrinks()
        {
            List<IMenuItem> list = new List<IMenuItem>();
            list.Add(new InorganicSubstance() { Size = ServingSize.Small });
            list.Add(new InorganicSubstance() { Size = ServingSize.Medium });
            list.Add(new InorganicSubstance() { Size = ServingSize.Large });
            list.Add(new LiquifiedVegetation() { Size = ServingSize.Small });
            list.Add(new LiquifiedVegetation() { Size = ServingSize.Medium });
            list.Add(new LiquifiedVegetation() { Size = ServingSize.Large });
            list.Add(new SaucerFuel() { Size = ServingSize.Small });
            list.Add(new SaucerFuel() { Size = ServingSize.Medium });
            list.Add(new SaucerFuel() { Size = ServingSize.Large });
            foreach (IMenuItem item in Menu.Drinks)
            {
                Assert.Contains(Menu.Drinks, (x) =>
                {
                    return item.GetType() == x.GetType();
                });
            }
        }
    }
}
