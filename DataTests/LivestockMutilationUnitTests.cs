using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProject.DataTests
{
    /// <summary>
    /// The unit tests for LivestockMutilation Class
    /// </summary>
    public class LivestockMutilationUnitTests
    {
        #region default values
        /// <summary>
        /// Checks that an unaltered LivestockMutilation has 3 biscuits
        /// </summary>
        [Fact]
        public void DefaultCountShouldBeThreeBiscuits()
        {
            LivestockMutilation lm = new();
            Assert.Equal(3u, lm.Biscuits);
        }

        /// <summary>
        /// Checks that a unaltered LivestockMutilation is served with gravy 
        /// </summary>
        [Fact]
        public void DefaultServedWithSyrup()
        {
            LivestockMutilation lm = new();
            Assert.True(lm.Gravy);
        }

        /// <summary>
        /// Tests to make sure the description is set properly
        /// </summary>
        [Fact]
        public void DescriptionShouldBeCorrect()
        {
            LivestockMutilation lm = new LivestockMutilation();
            Assert.Equal("A hearty serving of biscuits, smothered in sausage-laden gravy.", lm.Description);
        }

        #endregion

        #region state changes
        /// <summary>
        /// This test checks that even as the LivestockMutilation's state mutates, the name does not change
        /// </summary>
        /// <param name="count">The number of biscuits included</param>
        /// <param name="gravy">If the Livestock Mutilation will be served with gravy</param>
        [Theory]
        [InlineData(6, true)]
        [InlineData(0, true)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(8, false)]
        [InlineData(3, false)]
        [InlineData(1, false)]
        [InlineData(11, true)]
        public void NameShouldAlwaysBeLivestockMutation(uint count, bool gravy)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = count,
                Gravy = gravy
            };
            Assert.Equal("Livestock Mutilation", lm.Name);
        }

        /// <summary>
        /// This test checks that even as the LivestockMutilation's state mutates, the ToString does not change
        /// </summary>
        /// <param name="count">The number of biscuits included</param>
        /// <param name="gravy">If the Livestock Mutilation will be served with gravy</param>
        [Theory]
        [InlineData(6, true)]
        [InlineData(0, true)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(8, false)]
        [InlineData(3, false)]
        [InlineData(1, false)]
        [InlineData(11, true)]
        public void ToStringShouldAlwaysBeLivestockMutation(uint count, bool gravy)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = count,
                Gravy = gravy
            };
            Assert.Equal("Livestock Mutilation", lm.ToString());
        }

        /// <summary>
        /// This test verifies that a LivestockMutilation's count cannot exceed 8, and 
        /// if it is attempted, the count will be set to 8.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetCountAboveEight()
        {
            LivestockMutilation lm = new();
            lm.Biscuits = 13;
            Assert.Equal(8u, lm.Biscuits);
        }

        /// <summary>
        /// This test checks that even as the Livestock Mutilation's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="count">The number of biscuits included</param>
        /// <param name="gravy">If the Livestock Mutilation will be served with gravy</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(6, true, 49 * 6 + 140)]
        [InlineData(0, true, 49 * 0 + 140)]
        [InlineData(2, true, 49 * 2 + 140)]
        [InlineData(3, true, 49 * 3 + 140)]
        [InlineData(8, false, 49 * 8 + 0)]
        [InlineData(3, false, 49 * 3 + 0)]
        [InlineData(1, false, 49 * 1 + 0)]
        [InlineData(11, true, 49 * 8 + 140)]
        public void CaloriesShouldBeCorrect(uint count, bool gravy, uint calories)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = count,
                Gravy = gravy
            };
            Assert.Equal(calories, lm.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Livestock Mutilation
        /// </summary>
        /// <param name="count">The number of biscuits included</param>
        /// <param name="gravy">If the Livestock Mutilation will be served with gravy</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(3, true, new string[] { })]
        [InlineData(4, true, new string[] { "4 biscuits" })]
        [InlineData(3, false, new string[] { "Hold Gravy" })]
        [InlineData(4, false, new string[] { "Hold Gravy", "4 biscuits" })]
        public void SpecialInstructionsRelfectsState(uint count, bool gravy, string[] instructions)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = count,
                Gravy = gravy
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, lm.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, lm.SpecialInstructions.Count());
        }

        /// <summary>
        /// This test checks that even as the LivestockMutilation's state mutates, the price reflect that state
        /// </summary>
        /// <param name="count">The number of biscuits included</param>
        /// <param name="price">The expected price, given the specified state</param>
        [Theory]
        [InlineData(2, 7.25)]
        [InlineData(1, 7.25)]
        [InlineData(3, 7.25)]
        [InlineData(5, 7.25 + (2 * 1))]
        [InlineData(10, 7.25 + (5 * 1))]
        [InlineData(8, 7.25 + (5 * 1))]
        [InlineData(4, 7.25 + 1)]
        [InlineData(0, 7.25)]
        public void PriceShouldBeCorrect(uint count, decimal price)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = count
            };
            Assert.Equal(price, lm.Price);

        }
        #endregion

        #region IMenuItem Tests

        /// <summary>
        /// Tests to make sure the class can be cast to an IMenuItem
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToIMenuItem()
        {
            LivestockMutilation lm = new();
            Assert.IsAssignableFrom<IMenuItem>(lm);
        }

        #endregion

        #region Abstract Base Class tests

        /// <summary>
        /// Tests to make sure the class can be cast to a base class
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToBaseClass()
        {
            LivestockMutilation lm = new();
            Assert.IsAssignableFrom<Entree>(lm);
        }

        #endregion
        #region Property Changed Unit Tests
        /// <summary>
        /// tests that this class implements the INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            LivestockMutilation lm = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(lm);
        }

        /// <summary>
        /// ensures changing the size changes all of the properties it should change
        /// </summary>
        /// <param name="size">the size to change it to (default is small so no need to test it)</param>
        /// <param name="propertyName">the name of the property that will change</param>
        [Theory]
        [InlineData(1, "Biscuits")]
        [InlineData(2, "Biscuits")]
        [InlineData(5, "Biscuits")]
        [InlineData(7, "Biscuits")]
        [InlineData(1, "Price")]
        [InlineData(2, "Price")]
        [InlineData(5, "Price")]
        [InlineData(7, "Price")]
        [InlineData(1, "Calories")]
        [InlineData(2, "Calories")]
        [InlineData(5, "Calories")]
        [InlineData(7, "Calories")]
        [InlineData(1, "SpecialInstructions")]
        [InlineData(2, "SpecialInstructions")]
        [InlineData(5, "SpecialInstructions")]
        [InlineData(7, "SpecialInstructions")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(uint size, string propertyName)
        {
            LivestockMutilation lm = new();
            Assert.PropertyChanged(lm, propertyName, () =>
            {
                lm.Biscuits = size;
            });
        }

        /// <summary>
        /// Changing the gravy property should notify property changed
        /// </summary>
        /// <param name="value">gravy or not (default to true so no need to check)</param>
        /// <param name="propertyName">the property changing</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "Gravy")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingGravyShouldNotifyPropertyChanges(bool value, string propertyName)
        {
            LivestockMutilation lm = new();
            Assert.PropertyChanged(lm, propertyName, () =>
            {
                lm.Gravy = value;
            });
        }
        #endregion
    }
}
