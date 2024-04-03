using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProjectPokemonProject.DataTests
{
    /// <summary>
    /// Unit tests for OuterOmlette class
    /// </summary>
    public class OuterOmletteUnitTests
    {
        #region default values
        /// <summary>
        /// Checks that a unaltered Outer Omlette is served with cheddar cheese 
        /// </summary>
        [Fact]
        public void DefaultServedWithCheddarCheese()
        {
            OuterOmelette oo = new();
            Assert.True(oo.CheddarCheese);
        }

        /// <summary>
        /// Checks that a unaltered Outer Omlette is served with peppers
        /// </summary>
        [Fact]
        public void DefaultServedWithPeppers()
        {
            OuterOmelette oo = new();
            Assert.True(oo.Peppers);
        }

        /// <summary>
        /// Checks that a unaltered Outer Omlette is served with mushrooms
        /// </summary>
        [Fact]
        public void DefaultServedWithMushrooms()
        {
            OuterOmelette oo = new();
            Assert.True(oo.Mushrooms);
        }

        /// <summary>
        /// Checks that a unaltered Outer Omlette is served with tomatoes
        /// </summary>
        [Fact]
        public void DefaultServedWithTomatoes()
        {
            OuterOmelette oo = new();
            Assert.True(oo.Tomatoes);
        }

        /// <summary>
        /// Checks that a unaltered Outer Omlette is served with onions 
        /// </summary>
        [Fact]
        public void DefaultServedWithOnions()
        {
            OuterOmelette oo = new();
            Assert.True(oo.Onions);
        }

        /// <summary>
        /// Tests to make sure the description is set properly
        /// </summary>
        [Fact]
        public void DescriptionShouldBeCorrect()
        {
            OuterOmelette oo = new OuterOmelette();
            Assert.Equal("A fully loaded Omelette.", oo.Description);
        }
        #endregion

        #region state changes
        /// <summary>
        /// This test checks that even as the Outter Omlettes's state mutates, the name does not change
        /// </summary>
        /// <param name="cheese">If the Outter Omlette will be served with cheese</param>
        /// <param name="peppers">If the Outter Omlette will be served with peppers</param>
        /// <param name="mushrooms">If the Outter Omlette will be served with mushrooms</param>
        /// <param name="tomatoes">If the Outter Omlette will be served with tomatoes</param>
        /// <param name="onions">If the Outter Omlette will be served with onions</param>
        [Theory]
        [InlineData(true, true, true, true, true)]
        [InlineData(false, true, true, true, true)]
        [InlineData(true, false, true, true, true)]
        [InlineData(true, true, false, true, true)]
        [InlineData(true, true, true, false, true)]
        [InlineData(true, true, true, true, false)]
        [InlineData(true, false, false, true, true)]
        [InlineData(true, true, true, false, false)]
        public void NameShouldAlwaysBeOuterOmlette(bool cheese, bool peppers, bool mushrooms, bool tomatoes, bool onions)
        {
            OuterOmelette oo = new()
            {
                CheddarCheese = cheese,
                Peppers = peppers,
                Mushrooms = mushrooms,
                Tomatoes = tomatoes,
                Onions = onions
            };
            Assert.Equal("Outer Omlette", oo.Name);
        }

        /// <summary>
        /// This test checks that even as the Outter Omlettes's state mutates, the ToString does not change
        /// </summary>
        /// <param name="cheese">If the Outter Omlette will be served with cheese</param>
        /// <param name="peppers">If the Outter Omlette will be served with peppers</param>
        /// <param name="mushrooms">If the Outter Omlette will be served with mushrooms</param>
        /// <param name="tomatoes">If the Outter Omlette will be served with tomatoes</param>
        /// <param name="onions">If the Outter Omlette will be served with onions</param>
        [Theory]
        [InlineData(true, true, true, true, true)]
        [InlineData(false, true, true, true, true)]
        [InlineData(true, false, true, true, true)]
        [InlineData(true, true, false, true, true)]
        [InlineData(true, true, true, false, true)]
        [InlineData(true, true, true, true, false)]
        [InlineData(true, false, false, true, true)]
        [InlineData(true, true, true, false, false)]
        public void ToStringShouldAlwaysBeOuterOmlette(bool cheese, bool peppers, bool mushrooms, bool tomatoes, bool onions)
        {
            OuterOmelette oo = new()
            {
                CheddarCheese = cheese,
                Peppers = peppers,
                Mushrooms = mushrooms,
                Tomatoes = tomatoes,
                Onions = onions
            };
            Assert.Equal("Outer Omlette", oo.ToString());
        }

        /// <summary>
        /// This test checks that even as the OuterOmlette's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="cheese">If the Outter Omlette will be served with cheese</param>
        /// <param name="peppers">If the Outter Omlette will be served with peppers</param>
        /// <param name="mushrooms">If the Outter Omlette will be served with mushrooms</param>
        /// <param name="tomatoes">If the Outter Omlette will be served with tomatoes</param>
        /// <param name="onions">If the Outter Omlette will be served with onions</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(true, true, true, true, true, 94 + 113 + 24 + 4 + 22 + 22)]
        [InlineData(false, true, true, true, true, 94 + 0 + 24 + 4 + 22 + 22)]
        [InlineData(true, false, true, true, true, 94 + 113 + 0 + 4 + 22 + 22)]
        [InlineData(true, true, false, true, true, 94 + 113 + 24 + 0 + 22 + 22)]
        [InlineData(true, true, true, false, true, 94 + 113 + 24 + 4 + 0 + 22)]
        [InlineData(true, true, true, true, false, 94 + 113 + 24 + 4 + 22 + 0)]
        [InlineData(true, false, false, true, true, 94 + 113 + 0 + 0 + 22 + 22)]
        [InlineData(true, true, true, false, false, 94 + 113 + 24 + 4 + 0 + 0)]
        public void CaloriesShouldBeCorrect(bool cheese, bool peppers, bool mushrooms, bool tomatoes, bool onions, uint calories)
        {
            OuterOmelette oo = new()
            {
                CheddarCheese = cheese,
                Peppers = peppers,
                Mushrooms = mushrooms,
                Tomatoes = tomatoes,
                Onions = onions
            };
            Assert.Equal(calories, oo.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Outer Omlette
        /// </summary>
        /// <param name="cheese">If the Outter Omlette will be served with cheese</param>
        /// <param name="peppers">If the Outter Omlette will be served with peppers</param>
        /// <param name="mushrooms">If the Outter Omlette will be served with mushrooms</param>
        /// <param name="tomatoes">If the Outter Omlette will be served with tomatoes</param>
        /// <param name="onions">If the Outter Omlette will be served with onions</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, true, true, true, true, new string[] { })]
        [InlineData(false, true, true, true, true, new string[] { "Hold Cheddar Cheese" })]
        public void SpecialInstructionsRelfectsState(bool cheese, bool peppers, bool mushrooms, bool tomatoes, bool onions, string[] instructions)
        {
            OuterOmelette oo = new()
            {
                CheddarCheese = cheese,
                Peppers = peppers,
                Mushrooms = mushrooms,
                Tomatoes = tomatoes,
                Onions = onions
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, oo.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, oo.SpecialInstructions.Count());
        }

        /// <summary>
        /// This test checks that even as the CrashedSaucer's state mutates, the price reflect that state
        /// </summary>
        /// <param name="price">The expected price, given the specified state</param>
        /// <remarks>
        /// We supply the expected price as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected price are matched to inputs 
        /// </remarks>
        [Fact]
        public void PriceShouldBeCorrect()
        {
            OuterOmelette oo = new();
            Assert.Equal(7.45m, oo.Price);

        }
        #endregion

        #region IMenuItem Tests

        /// <summary>
        /// Tests to make sure the class can be cast to an IMenuItem
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToIMenuItem()
        {
            OuterOmelette oo = new();
            Assert.IsAssignableFrom<IMenuItem>(oo);
        }

        #endregion

        #region Abstract Base Class tests

        /// <summary>
        /// Tests to make sure the class can be cast to a base class
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToBaseClass()
        {
            OuterOmelette oo = new();
            Assert.IsAssignableFrom<Entree>(oo);
        }

        #endregion

        #region Property Changed Unit Tests
        /// <summary>
        /// tests that this class implements the INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            OuterOmelette oo = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(oo);
        }

        /// <summary>
        /// Changing the tomatoes property should notify property changed
        /// </summary>
        /// <param name="value">tomatoes or not (default to true so no need to check)</param>
        /// <param name="propertyName">the property changing</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "Tomatoes")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingTomatoesShouldNotifyPropertyChanges(bool value, string propertyName)
        {
            OuterOmelette oo = new();
            Assert.PropertyChanged(oo, propertyName, () =>
            {
                oo.Tomatoes = value;
            });
        }

        /// <summary>
        /// Changing the cheddar cheese property should notify property changed
        /// </summary>
        /// <param name="value">cheese or not (default to true so no need to check)</param>
        /// <param name="propertyName">the property changing</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "CheddarCheese")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingCheeseShouldNotifyPropertyChanges(bool value, string propertyName)
        {
            OuterOmelette oo = new();
            Assert.PropertyChanged(oo, propertyName, () =>
            {
                oo.CheddarCheese = value;
            });
        }

        /// <summary>
        /// Changing the peppers property should notify property changed
        /// </summary>
        /// <param name="value">peppers or not (default to true so no need to check)</param>
        /// <param name="propertyName">the property changing</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "Peppers")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingPeppersShouldNotifyPropertyChanges(bool value, string propertyName)
        {
            OuterOmelette oo = new();
            Assert.PropertyChanged(oo, propertyName, () =>
            {
                oo.Peppers = value;
            });
        }

        /// <summary>
        /// Changing the mushrooms property should notify property changed
        /// </summary>
        /// <param name="value">mushrooms or not (default to true so no need to check)</param>
        /// <param name="propertyName">the property changing</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "Mushrooms")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingMushroomsShouldNotifyPropertyChanges(bool value, string propertyName)
        {
            OuterOmelette oo = new();
            Assert.PropertyChanged(oo, propertyName, () =>
            {
                oo.Mushrooms = value;
            });
        }

        /// <summary>
        /// Changing the onions property should notify property changed
        /// </summary>
        /// <param name="value">onions or not (default to true so no need to check)</param>
        /// <param name="propertyName">the property changing</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "Onions")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingOnionsShouldNotifyPropertyChanges(bool value, string propertyName)
        {
            OuterOmelette oo = new();
            Assert.PropertyChanged(oo, propertyName, () =>
            {
                oo.Onions = value;
            });
        }
        #endregion
    }
}
