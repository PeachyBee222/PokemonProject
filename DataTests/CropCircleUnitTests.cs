using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// The unit tests for the CropCircle class
    /// </summary>
    public class CropCircleUnitTests
    {
        #region default values

        /// <summary>
        /// Checks that a unaltered Crop Circle is served with berries 
        /// </summary>
        [Fact]
        public void DefaultServedWithBerries()
        {
            CropCircle cc = new();
            Assert.True(cc.Berries);
        }
        /// <summary>
        /// Tests to make sure the description is set properly
        /// </summary>
        [Fact]
        public void DescriptionShouldBeCorrect()
        {
            CropCircle cc = new CropCircle();
            Assert.Equal("Oatmeal topped with mixed berries.", cc.Description);
        }
        #endregion

        #region state changes
        /// <summary>
        /// This test checks that even as the CropCircle's state mutates, the name does not change
        /// </summary>
        /// <param name="berries">If the Crop Circle will be served with berries</param>
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void NameShouldAlwaysBeCropCircle(bool berries)
        {
            CropCircle cc = new()
            {
                Berries = berries
            };
            Assert.Equal("Crop Circle", cc.Name);
        }

        /// <summary>
        /// This test checks that even as the CropCircle's state mutates, the ToString does not change
        /// </summary>
        /// <param name="berries">If the Crop Circle will be served with berries</param>
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void ToStringShouldAlwaysBeCropCircle(bool berries)
        {
            CropCircle cc = new()
            {
                Berries = berries
            };
            Assert.Equal("Crop Circle", cc.ToString());
        }

        /// <summary>
        /// This test checks that even as the Crop Circle's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="berries">If the Crop Circle will be served with berries</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(true, 158 +89)]
        [InlineData( false, 158 + 0)]
        public void CaloriesShouldBeCorrect(bool berries, uint calories)
        {
            CropCircle cc = new()
            {
                Berries = berries
            };
            Assert.Equal(calories, cc.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Crop Circle
        /// </summary>
        /// <param name="berries">If served with berries</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, new string[] { })]
        [InlineData(false, new string[] { "Hold Berries" })]
        public void SpecialInstructionsRelfectsState(bool berries, string[] instructions)
        {
            CropCircle cc = new()
            {
                Berries = berries
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, cc.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, cc.SpecialInstructions.Count());
        }

        /// <summary>
        /// This test checks that even as the CropCircle's state mutates, the price reflect that state
        /// </summary>
        /// <param name="price">The expected price, given the specified state</param>
        [Theory]
        [InlineData(2)]
        public void PriceShouldBeCorrect(decimal price)
        {
            CropCircle cc = new();
            Assert.Equal(price, cc.Price);

        }
        #endregion

        #region IMenuItem Tests

        /// <summary>
        /// Tests to make sure the class can be cast to an IMenuItem
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToIMenuItem()
        {
            CropCircle cc = new();
            Assert.IsAssignableFrom<IMenuItem>(cc);
        }

        #endregion

        #region Abstract Base Class tests

        /// <summary>
        /// Tests to make sure the class can be cast to a base class
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToBaseClass()
        {
            CropCircle cc = new();
            Assert.IsAssignableFrom<Side>(cc);
        }

        #endregion
        #region Property Changed Unit Tests
        /// <summary>
        /// tests that this class implements the INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            CropCircle cc = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(cc);

        }

        /// <summary>
        /// Changing the berries property should notify property changed
        /// </summary>
        /// <param name="value">berries or not (default to true so no need to check)</param>
        /// <param name="propertyName">the property changing</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "Berries")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingBerriesShouldNotifyPropertyChanges(bool value, string propertyName)
        {
            CropCircle cc = new();
            Assert.PropertyChanged(cc, propertyName, () =>
            {
                cc.Berries = value;
            });
        }
        #endregion
    }
}
