using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProject.DataTests
{
    /// <summary>
    /// The unit tests for the YouAreToast tests
    /// </summary>
    public class YouAreToastUnitTests
    {
        #region default values
        /// <summary>
        /// Checks that an unaltered Crashed Saucer has 6 fench toast
        /// </summary>
        [Fact]
        public void DefaultCountShouldBeTwoTexasToast()
        {
            YouAreToast yat = new();
            Assert.Equal(2u, yat.Count);
        }

        /// <summary>
        /// Tests to make sure the description is set properly
        /// </summary>
        [Fact]
        public void DescriptionShouldBeCorrect()
        {
            YouAreToast yat = new YouAreToast();
            Assert.Equal("Texas toast", yat.Description);
        }
        #endregion

        #region state changes
        /// <summary>
        /// This test checks that even as the YouAreToast's state mutates, the name does not change
        /// </summary>
        /// <param name="count">The number of texas toast included</param>
        [Theory]
        [InlineData(6)]
        [InlineData(0)]
        [InlineData(12)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(3)]
        [InlineData(8)]
        [InlineData(13)]
        public void NameShouldAlwaysBeYouAreToast(uint count)
        {
            YouAreToast yat = new()
            {
                Count = count
            };
            Assert.Equal("You're Toast", yat.Name);
        }

        /// <summary>
        /// This test verifies that a YouAreToast's count cannot exceed 12, and 
        /// if it is attempted, the count will be set to 12.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetCountAboveTwelve() {
            YouAreToast yat = new();
            yat.Count = 13;
            Assert.Equal(12u, yat.Count);
        }

        /// <summary>
        /// This test verifies that a YouAreToast's count cannot be below 1, and 
        /// if it is attempted, the count will be set to 1.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetCountBelowOne()
        {
            YouAreToast yat = new();
            yat.Count = 0;
            Assert.Equal(1u, yat.Count);
        }

        /// <summary>
        /// This test checks that even as the YouAreToast's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="count">The number of texas toast included</param>
        /// <param name="calories">The number of calories for texas toast</param>

        [Theory]
        [InlineData(6,100 * 6)]
        [InlineData(0, 100 * 1)]
        [InlineData(2, 100 *2)]
        [InlineData(1, 100 * 1)]
        [InlineData(5, 100 * 5)]
        [InlineData(3, 100 * 3)]
        [InlineData(13, 100 * 12)] //edge case you can only have 12 at max
        [InlineData(4, 100 * 4)]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            YouAreToast yat = new()
            {
                Count = count
            };
            Assert.Equal(calories, yat.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the You are Toast
        /// </summary>
        /// <param name="count">The number of texas toast</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(2, new string[] { })]
        [InlineData(4, new string[] { "4 slices" })]
        public void SpecialInstructionsRelfectsState(uint count, string[] instructions)
        {
            YouAreToast yat = new()
            {
                Count = count
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, yat.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, yat.SpecialInstructions.Count());
        }

        /// <summary>
        /// This test checks that even as the YouAreToast's state mutates, the price reflect that state
        /// </summary>
        /// <param name="count">The number of texas toast included</param>
        /// <param name="price">The expected price, given the specified state</param>
        /// <remarks>
        /// We supply the expected price as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected price are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(2, 1 * 2)]
        [InlineData(1, 1 * 1)]
        [InlineData(6, 1 * 6)]
        [InlineData(5, 1 * 5)]
        [InlineData(4, 1 * 4)]
        [InlineData(13, 1 * 12)] //edge case since the max is 12
        [InlineData(10, 1 * 10)]
        [InlineData(0, 1 * 1)]
        public void PriceShouldBeCorrect(uint count, decimal price)
        {
            YouAreToast yat = new()
            {
                Count = count,
            };
            Assert.Equal(price, yat.Price);

        }

        /// <summary>
        /// This test checks that even as the TakenBacon's state mutates, the ToString does not change
        /// </summary>
        /// <param name="count">The number of bacon strips</param>
        [Theory]
        [InlineData(6)]
        [InlineData(2)]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(7)]
        [InlineData(8)]
        public void ToStringShouldAlwaysBeYouAreToast(uint count)
        {
            YouAreToast yat = new()
            {
                Count = count
            };
            Assert.Equal("You're Toast", yat.ToString());
        }

        #endregion

        #region IMenuItem Tests

        /// <summary>
        /// Tests to make sure the class can be cast to an IMenuItem
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToIMenuItem()
        {
            YouAreToast yat = new();
            Assert.IsAssignableFrom<IMenuItem>(yat);
        }

        #endregion

        #region Abstract Base Class tests

        /// <summary>
        /// Tests to make sure the class can be cast to a base class
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToBaseClass()
        {
            YouAreToast yat = new();
            Assert.IsAssignableFrom<Side>(yat);
        }

        #endregion

        #region Property Changed Unit Tests
        /// <summary>
        /// tests that this class implements the INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            YouAreToast yat = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(yat);
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
        [InlineData(1, "SpecialInstructions")]
        [InlineData(3, "SpecialInstructions")]
        [InlineData(5, "SpecialInstructions")]
        public void ChangingCountShouldNotifyOfPropertyChanges(uint count, string propertyName)
        {
            YouAreToast yat = new();
            Assert.PropertyChanged(yat, propertyName, () => {
                yat.Count = count;
            });
        }
        #endregion
    }
}
