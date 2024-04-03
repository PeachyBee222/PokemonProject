using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProjectPokemonProject.DataTests
{
    /// <summary>
    /// The unit tests for the EvisceratedEggs class
    /// </summary>
    public class EvisceratedEggsUnitTests
    {
        #region state changes
        /// <summary>
        /// This test checks that even as the EvisceratedEggs's state mutates, the name does not change
        /// </summary>
        /// <param name="count">The number of eggs included</param>
        /// <param name="style">the style of the eggs</param>
        [Theory]
        [InlineData(1, EggStyle.Hardboiled)]
        [InlineData(0, EggStyle.OverEasy)]
        [InlineData(2, EggStyle.Poached)]
        [InlineData(3, EggStyle.Scrambled)]
        [InlineData(4, EggStyle.SoftBoiled)]
        [InlineData(5, EggStyle.SunnySideUp)]
        [InlineData(6, EggStyle.Hardboiled)]
        [InlineData(7, EggStyle.OverEasy)]
        public void NameShouldAlwaysBeEvisceratedEggs(uint count, EggStyle style)
        {
            EvisceratedEggs ee = new()
            {
                Count = count,
                Style = style
            };
            Assert.Equal("Eviscerated Eggs", ee.Name);
        }

        /// <summary>
        /// This test checks that even as the EvisceratedEggs's state mutates, the ToString does not change
        /// </summary>
        /// <param name="count">The number of eggs included</param>
        /// <param name="style">the style of the eggs</param>
        [Theory]
        [InlineData(1, EggStyle.Hardboiled)]
        [InlineData(0, EggStyle.OverEasy)]
        [InlineData(2, EggStyle.Poached)]
        [InlineData(3, EggStyle.Scrambled)]
        [InlineData(4, EggStyle.SoftBoiled)]
        [InlineData(5, EggStyle.SunnySideUp)]
        [InlineData(6, EggStyle.Hardboiled)]
        [InlineData(7, EggStyle.OverEasy)]
        public void ToStringShouldAlwaysBeEvisceratedEggs(uint count, EggStyle style)
        {
            EvisceratedEggs ee = new()
            {
                Count = count,
                Style = style
            };
            Assert.Equal("Eviscerated Eggs", ee.ToString());
        }

        /// <summary>
        /// This test verifies that a EvisceratedEggs's count cannot exceed 6, and 
        /// if it is attempted, the count will be set to 6.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetCountAboveSix()
        {
            EvisceratedEggs ee = new();
            ee.Count = 6;
            Assert.Equal(6u, ee.Count);
        }

        /// <summary>
        /// This test verifies that a EvisceratedEggs's count cannot be below 1, and 
        /// if it is attempted, the count will be set to 1.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetCountBelowOne()
        {
            EvisceratedEggs ee = new();
            ee.Count = 0;
            Assert.Equal(1u, ee.Count);
        }

        /// <summary>
        /// This test checks that even as the EvisceratedEggs's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="count">The number of eggs included</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(6, 78 * 6)]
        [InlineData(5, 78 * 5)]
        [InlineData(4, 78 * 4)]
        [InlineData(3, 78 * 3)]
        [InlineData(2, 78 * 2)]
        [InlineData(1, 78 * 1)]
        [InlineData(8, 78 * 6)]
        [InlineData(7, 78 * 6)]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            EvisceratedEggs ee = new()
            {
                Count = count
            };
            Assert.Equal(calories, ee.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the EvisceratedEggs
        /// </summary>
        /// <param name="count">The number of eggs</param>
        /// <param name="style">The style of eggs</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(2, EggStyle.OverEasy, new string[] { "Over Easy" })]
        [InlineData(4, EggStyle.OverEasy, new string[] { "Over Easy", "4 eggs" })]
        [InlineData(2, EggStyle.Hardboiled, new string[] { "Hard Boiled" })]
        [InlineData(4, EggStyle.Scrambled, new string[] { "Scrambled", "4 eggs" })]
        public void SpecialInstructionsRelfectsState(uint count, EggStyle style, string[] instructions)
        {
            EvisceratedEggs ee = new()
            {
                Count = count,
                Style = style
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, ee.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, ee.SpecialInstructions.Count());
        }

        /// <summary>
        /// This test checks that even as the EvisceratedEgg's state mutates, the price reflect that state
        /// </summary>
        /// <param name="count">The number of eggs included</param>
        /// <param name="price">The expected price, given the specified state</param>
        [Theory]
        [InlineData(2, 1 * 2)]
        [InlineData(1, 1 * 1)]
        [InlineData(6, 1 * 6)]
        [InlineData(5, 1 * 5)]
        [InlineData(4, 1 * 4)]
        [InlineData(3, 1 * 3)]
        [InlineData(7, 1 * 6)]
        public void PriceShouldBeCorrect(uint count, decimal price)
        {
            EvisceratedEggs ee = new()
            {
                Count = count
            };
            Assert.Equal(price, ee.Price);

        }

        #endregion

        #region default values

        /// <summary>
        /// Checks that an unaltered EvisceratedEggs has 2 eggs
        /// </summary>
        [Fact]
        public void DefaultStackSizeShouldBeTwoEggs()
        {
            EvisceratedEggs ee = new();
            Assert.Equal(2u, ee.Count);
        }

        /// <summary>
        /// Checks that a unaltered Eviscerated egg is over easy 
        /// </summary>
        [Fact]
        public void DefaultServedOverEasy()
        {
            EvisceratedEggs ee = new();
            Assert.Equal(EggStyle.OverEasy, ee.Style);
        }

        /// <summary>
        /// Tests to make sure the description is set properly
        /// </summary>
        [Fact]
        public void DescriptionShouldBeCorrect()
        {
            EvisceratedEggs ee = new EvisceratedEggs();
            Assert.Equal("Eggs prepared the way you like.", ee.Description);
        }

        #endregion

        #region IMenuItem Tests

        /// <summary>
        /// Tests to make sure the class can be cast to an IMenuItem
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToIMenuItem()
        {
            EvisceratedEggs ee = new();
            Assert.IsAssignableFrom<IMenuItem>(ee);
        }

        #endregion

        #region Abstract Base Class tests

        /// <summary>
        /// Tests to make sure the class can be cast to a base class
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToBaseClass()
        {
            EvisceratedEggs ee = new();
            Assert.IsAssignableFrom<Side>(ee);
        }

        #endregion

        #region Property Changed Unit Tests
        /// <summary>
        /// tests that this class implements the INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            EvisceratedEggs ee = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(ee);
        }

        /// <summary>
        /// Makes sure changing style notifies a property change
        /// </summary>
        /// <param name="style">the style changing (default is overeasy)</param>
        /// <param name="propertyName">the name of the property changing</param>
        [Theory]
        [InlineData(EggStyle.Hardboiled, "Style")]
        [InlineData(EggStyle.Scrambled, "Style")]
        [InlineData(EggStyle.Poached, "Style")]
        [InlineData(EggStyle.Poached, "SpecialInstructions")]
        [InlineData(EggStyle.Scrambled, "SpecialInstructions")]
        [InlineData(EggStyle.Hardboiled, "SpecialInstructions")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(EggStyle style, string propertyName)
        {
            EvisceratedEggs ee = new();
            Assert.PropertyChanged(ee, propertyName, () =>
            {
                ee.Style = style;
            });
        }

        /// <summary>
        /// Makes sure changing count notifies a property change
        /// </summary>
        /// <param name="count">the count changing (default is 2)</param>
        /// <param name="propertyName">the name of the property changing</param>
        [Theory]
        [InlineData(1, "Count")]
        [InlineData(3, "Count")]
        [InlineData(5, "Count")]
        [InlineData(7, "Count")]
        [InlineData(1, "Price")]
        [InlineData(3, "Price")]
        [InlineData(1, "Calories")]
        [InlineData(3, "Calories")]
        [InlineData(5, "Calories")]
        public void ChangingCountShouldNotifyOfPropertyChanges(uint count, string propertyName)
        {
            EvisceratedEggs ee = new();
            Assert.PropertyChanged(ee, propertyName, () =>
            {
                ee.Count = count;
            });
        }

        #endregion
    }
}
