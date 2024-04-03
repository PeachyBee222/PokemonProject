using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProject.DataTests
{
    /// <summary>
    /// The unit tests for the class TakenBacon
    /// </summary>
    public class TakenBaconUnitTests
    {
        #region default values
        /// <summary>
        /// Checks that an unaltered Taken Bacon has 2 peices
        /// </summary>
        [Fact]
        public void DefaultCountShouldBeTwoPeices()
        {
            TakenBacon tb = new();
            Assert.Equal(2u, tb.Count);
        }

        /// <summary>
        /// Tests to make sure the description is set properly
        /// </summary>
        [Fact]
        public void DescriptionShouldBeCorrect()
        {
            TakenBacon tb = new TakenBacon();
            Assert.Equal("Crispy strips of bacon.", tb.Description);
        }
        #endregion

        #region state changes
        /// <summary>
        /// This test checks that even as the TakenBacon's state mutates, the name does not change
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
        public void NameShouldAlwaysBeTakenBacon(uint count)
        {
            TakenBacon tb = new()
            {
                Count = count
            };
            Assert.Equal("Taken Bacon", tb.Name);
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
        public void ToStringShouldAlwaysBeTakenBacon(uint count)
        {
            TakenBacon tb = new()
            {
                Count = count
            };
            Assert.Equal("Taken Bacon", tb.ToString());
        }

        /// <summary>
        /// This test verifies that a TakenBacon's count cannot exceed 6, and 
        /// if it is attempted, the count will be set to 6.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetCountAboveSix()
        {
            TakenBacon tb = new();
            tb.Count = 13;
            Assert.Equal(6u, tb.Count);
        }
        
        /// <summary>
        /// This test verifies that a TakenBacon's count cannot be below 1, and 
        /// if it is attempted, the count will be set to 1.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetCountBelowOne()
        {
            TakenBacon tb = new();
            tb.Count = 0;
            Assert.Equal(1u, tb.Count);
        }
        
        /// <summary>
        /// This test checks that even as the TakenBacon's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="count">The number of bacon strips included</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(6, 43 * 6)]
        [InlineData(0, 43 * 1)]
        [InlineData(2, 43 * 2)]
        [InlineData(8, 43 * 6)] //edge case can only have 6 strips
        [InlineData(1, 43 * 1)]
        [InlineData(3, 43 * 3)]
        [InlineData(5, 43 * 5)]
        [InlineData(4, 43 * 4)]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            TakenBacon tb = new()
            {
                Count = count
            };
            Assert.Equal(calories, tb.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Taken Bacon
        /// </summary>
        /// <param name="count">The number of bacon strips</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(2, new string[] { })]
        [InlineData(4, new string[] { "4 strips" })]
        public void SpecialInstructionsRelfectsState(uint count, string[] instructions)
        {
            TakenBacon tb = new()
            {
                Count = count
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, tb.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, tb.SpecialInstructions.Count());
        }

        /// <summary>
        /// This test checks that even as the TakenBacon's state mutates, the price reflect that state
        /// </summary>
        /// <param name="count">The number of bacon strips included</param>
        /// <param name="price">The expected price, given the specified state</param>
        [Theory]
        [InlineData(2, 1 * 2)]
        [InlineData(1, 1 * 1)]
        [InlineData(6, 1 * 6)]
        [InlineData(5, 1 * 5)]
        [InlineData(4, 1 * 4)]
        [InlineData(3, 1 * 3)]
        [InlineData(10, 1 * 6)]
        [InlineData(0, 1 * 1)]
        public void PriceShouldBeCorrect(uint count, decimal price)
        {
            TakenBacon tb = new()
            {
                Count = count
            };
            Assert.Equal(price, tb.Price);

        }
        #endregion

        #region IMenuItem Tests

        /// <summary>
        /// Tests to make sure the class can be cast to an IMenuItem
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToIMenuItem()
        {
            TakenBacon tb = new();
            Assert.IsAssignableFrom<IMenuItem>(tb);
        }

        #endregion

        #region Abstract Base Class tests

        /// <summary>
        /// Tests to make sure the class can be cast to a base class
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToBaseClass()
        {
            TakenBacon tb = new();
            Assert.IsAssignableFrom<Side>(tb);
        }

        #endregion

        #region Property Changed Unit Tests
        /// <summary>
        /// tests that this class implements the INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            TakenBacon tb = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(tb);
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
            TakenBacon tb = new();
            Assert.PropertyChanged(tb, propertyName, () => {
                tb.Count = count;
            });
        }
        #endregion
    }
}
