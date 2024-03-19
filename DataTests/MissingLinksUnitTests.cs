using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// The unit tests for the MissingLinks class
    /// </summary>
    public class MissingLinksUnitTests
    {
        #region default values
        /// <summary>
        /// Checks that an unaltered Missing Links has 2 sausages
        /// </summary>
        [Fact]
        public void DefaultCountShouldBeTwoSausages()
        {
            MissingLinks ml = new();
            Assert.Equal(2u, ml.Count);
        }

        #endregion

        #region state changes
        /// <summary>
        /// This test checks that even as the MissingLink's state mutates, the name does not change
        /// </summary>
        /// <param name="count">The number of sausage links included</param>
        [Theory]
        [InlineData(6)]
        [InlineData(0)]
        [InlineData(12)]
        [InlineData(11)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(8)]
        [InlineData(1)]
        public void NameShouldAlwaysBeMissingLinks(uint count)
        {
            MissingLinks ml = new()
            {
                Count = count
            };
            Assert.Equal("Missing Links", ml.Name);
        }
        /// <summary>
        /// This test checks that even as the MissingLink's state mutates, the ToString does not change
        /// </summary>
        /// <param name="count">The number of sausage links included</param>
        [Theory]
        [InlineData(6)]
        [InlineData(0)]
        [InlineData(12)]
        [InlineData(11)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(8)]
        [InlineData(1)]
        public void ToStringShouldAlwaysBeMissingLinks(uint count)
        {
            MissingLinks ml = new()
            {
                Count = count
            };
            Assert.Equal("Missing Links", ml.ToString());
        }

        /// <summary>
        /// This test verifies that a MissingLink's count cannot exceed 8, and 
        /// if it is attempted, the StackSize will be set to 8.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetCountAboveEight()
        {
            MissingLinks ml = new();
            ml.Count = 13;
            Assert.Equal(8u, ml.Count);
        }

        /// <summary>
        /// This test verifies that a MissingLink's count cannot be 0, and 
        /// if it is attempted, the count will be set to 1.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetCountBelowOne()
        {
            MissingLinks ml = new();
            ml.Count = 0;
            Assert.Equal(1u, ml.Count);
        }


        /// <summary>
        /// This test checks that even as the MissingLink's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="count">The number of sausage links included</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(1, 391 * 1)]
        [InlineData(0, 391 * 1)]
        [InlineData(2, 391 * 2)]
        [InlineData(8, 391 * 8)]
        [InlineData(6, 391 * 6)]
        [InlineData(3, 391 * 3)]
        [InlineData(11, 391 * 8)] //edge case you can only have 8 max
        [InlineData(4, 391 * 4)]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            MissingLinks ml = new()
            {
                Count = count
            };
            Assert.Equal(calories, ml.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the MissingLinks
        /// </summary>
        /// <param name="count">The number of sausage links</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(2, new string[] { })]
        [InlineData(4, new string[] { "4 links" })]
        public void SpecialInstructionsRelfectsState(uint count, string[] instructions)
        {
            MissingLinks ml = new()
            {
                Count = count
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, ml.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, ml.SpecialInstructions.Count());
        }

        /// <summary>
        /// This test checks that even as the MissingLinks's state mutates, the price reflect that state
        /// </summary>
        /// <param name="count">The number of sausage links included</param>
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
        [InlineData(8, 1 * 8)]
        [InlineData(3, 1 * 3)]
        [InlineData(10, 1 * 8)]
        [InlineData(0, 1 * 1)]
        public void PriceShouldBeCorrect(uint count, decimal price)
        {
            MissingLinks ml = new()
            {
                Count = count
            };
            Assert.Equal(price, ml.Price);

        }
        #endregion

        #region IMenuItem Tests

        /// <summary>
        /// Tests to make sure the class can be cast to an IMenuItem
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToIMenuItem()
        {
            MissingLinks ml = new();
            Assert.IsAssignableFrom<IMenuItem>(ml);
        }

        #endregion

        #region Abstract Base Class tests

        /// <summary>
        /// Tests to make sure the class can be cast to a base class
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToBaseClass()
        {
            MissingLinks ml = new();
            Assert.IsAssignableFrom<Side>(ml);
        }

        #endregion

        #region Property Changed Unit Tests
        /// <summary>
        /// tests that this class implements the INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            MissingLinks ml = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(ml);
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
            MissingLinks ml = new();
            Assert.PropertyChanged(ml, propertyName, () => {
                ml.Count = count;
            });
        }
        #endregion
    }
}
