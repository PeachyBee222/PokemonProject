using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests Example. DELETE UPON COMPLETION
    /// </summary>
    public class CrashedSaucerUnitTests
    {
        /*
        #region default values

        /// <summary>
        /// Checks that an unaltered Crashed Saucer has 6 fench toast
        /// </summary>
        [Fact]
        public void DefaultStackSizeShouldBeTwoFrenchToast()
        {
            CrashedSaucer cs = new();
            Assert.Equal(2u, cs.StackSize);
        }

        /// <summary>
        /// Checks that a unaltered Crashed Saucer is served with syrup 
        /// </summary>
        [Fact]
        public void DefaultServedWithSyrup()
        {
            CrashedSaucer cs = new();
            Assert.True(cs.Syrup);
        }

        /// <summary>
        /// Checks that an unaltered Crashed Saucer is served with butter
        /// </summary>
        [Fact]
        public void DefaultServedWithButter()
        {
            CrashedSaucer cs = new();
            Assert.True(cs.Butter);
        }

        /// <summary>
        /// This test checks that even as the CrashedSaucer's state mutates, the ToString does not change
        /// </summary>
        /// <param name="stackSize">The number of french toast included</param>
        /// <param name="syrup">If the Crashed Saucer will be served with syrup</param>
        /// <param name="butter">If the Crashed Saucer will be served with butter</param>
        [Theory]
        [InlineData(6, true, true)]
        [InlineData(0, true, true)]
        [InlineData(12, true, true)]
        [InlineData(6, true, false)]
        [InlineData(6, false, false)]
        [InlineData(3, true, false)]
        [InlineData(8, false, false)]
        [InlineData(11, true, true)]
        public void ToStringShouldAlwaysBeCrashedSaucer(uint stackSize, bool syrup, bool butter)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter
            };
            Assert.Equal("Crashed Saucer", cs.ToString());
        }
        /// <summary>
        /// Tests to make sure the description is set properly
        /// </summary>
        [Fact]
        public void DescriptionShouldBeCorrect()
        {
            CrashedSaucer cs = new CrashedSaucer();
            Assert.Equal("A stack of crispy french toast smothered in syrup and topped with a pat of butter.", cs.Description);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the CrashedSaucer's state mutates, the name does not change
        /// </summary>
        /// <param name="stackSize">The number of french toast included</param>
        /// <param name="syrup">If the Crashed Saucer will be served with syrup</param>
        /// <param name="butter">If the Crashed Saucer will be served with butter</param>
        [Theory]
        [InlineData(6, true, true)]
        [InlineData(0, true, true)]
        [InlineData(12, true, true)]
        [InlineData(6, true, false)]
        [InlineData(6, false, false)]
        [InlineData(3, true, false)]
        [InlineData(8, false, false)]
        [InlineData(11, true, true)]
        public void NameShouldAlwaysBeCrashedSaucer(uint stackSize, bool syrup, bool butter)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter
            };
            Assert.Equal("Crashed Saucer", cs.Name);
        }

        /// <summary>
        /// This test verifies that a CrashedSaucer's StackSize cannot exceed 6, and 
        /// if it is attempted, the StackSize will be set to 6.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetStackSizeAboveSix()
        {
            CrashedSaucer cs = new();
            cs.StackSize = 13;
            Assert.Equal(6u, cs.StackSize);
        }

        /// <summary>
        /// This test checks that even as the CrashedSaucer's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="stackSize">The number of fench toast included</param>
        /// <param name="syrup">If the Crashed Saucer will be served with syrup</param>
        /// <param name="butter">If the Crashed Saucer will be served with butter</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(6, true, true, 149 * 6 + 52 + 35)]
        [InlineData(0, true, true, 149 * 0 + 52 + 35)]
        [InlineData(2, true, true, 149 * 2 + 52 + 35)]
        [InlineData(6, true, false, 149 * 6 + 52 + 0)]
        [InlineData(6, false, false, 149 * 6 + 0 + 0)]
        [InlineData(3, true, false, 149 * 3 + 52 + 0)]
        [InlineData(7, false, false, 149 * 6 + 0 + 0)] //edge case you can only have 6 at max
        [InlineData(4, true, true, 149 * 4 + 52 + 35)]
        public void CaloriesShouldBeCorrect(uint stackSize, bool syrup, bool butter, uint calories)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter,
            };
            Assert.Equal(calories, cs.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Crashed Saucer
        /// </summary>
        /// <param name="stackSize">The number of french toast</param>
        /// <param name="syrup">If served with syrup</param>
        /// <param name="butter">If served with butter</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(2, true, true, new string[] { })]
        [InlineData(4, true, true, new string[] { "4 Slices" })]
        [InlineData(2, true, false, new string[] { "Hold Butter" })]
        [InlineData(4, true, false, new string[] {"4 Slices", "Hold Butter"})]
        public void SpecialInstructionsRelfectsState(uint stackSize, bool syrup, bool butter, string[] instructions)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, cs.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, cs.SpecialInstructions.Count());
        }

        /// <summary>
        /// This test checks that even as the CrashedSaucer's state mutates, the price reflect that state
        /// </summary>
        /// <param name="stackSize">The number of french toast included</param>
        /// <param name="price">The expected price, given the specified state</param>
        [Theory]
        [InlineData(2, 6.45)]
        [InlineData(1, 6.45)]
        [InlineData(6,6.45 + (4*1.5))]
        [InlineData(5, 6.45 + (3 * 1.5))]
        [InlineData(4, 6.45 + (2 * 1.5))]
        [InlineData(3, 6.45 + 1.5)]
        [InlineData(10, 6.45 + (4 * 1.5))]
        [InlineData(0, 6.45 + (0 * 0))]
        public void PriceShouldBeCorrect(uint stackSize, decimal price)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
            };
            Assert.Equal(price, cs.Price);

        }
        #endregion region

        #region IMenuItem Tests

        /// <summary>
        /// Tests to make sure the class can be cast to an IMenuItem
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToIMenuItem()
        {
            CrashedSaucer cs = new();
            Assert.IsAssignableFrom<IMenuItem>(cs);
        }

        #endregion

        #region Abstract Base Class tests

        /// <summary>
        /// Tests to make sure the class can be cast to a base class
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToBaseClass()
        {
            CrashedSaucer cs = new();
            Assert.IsAssignableFrom<Entree>(cs);
        }

        #endregion

        #region Property Changed Unit Tests
        /// <summary>
        /// tests that this class implements the INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            CrashedSaucer cs = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(cs);
        }

        /// <summary>
        /// ensures changing the size changes all of the properties it should change
        /// </summary>
        /// <param name="size">the size to change it to (default is small so no need to test it)</param>
        /// <param name="propertyName">the name of the property that will change</param>
        [Theory]
        [InlineData(1, "StackSize")]
        [InlineData(3, "StackSize")]
        [InlineData(5, "StackSize")]
        [InlineData(7, "StackSize")]
        [InlineData(1, "Price")]
        [InlineData(3, "Price")]
        [InlineData(5, "Price")]
        [InlineData(7, "Price")]
        [InlineData(1, "Calories")]
        [InlineData(3, "Calories")]
        [InlineData(5, "Calories")]
        [InlineData(7, "Calories")]
        [InlineData(1, "SpecialInstructions")]
        [InlineData(3, "SpecialInstructions")]
        [InlineData(5, "SpecialInstructions")]
        [InlineData(7, "SpecialInstructions")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(uint size, string propertyName)
        {
            CrashedSaucer cs = new();
            Assert.PropertyChanged(cs, propertyName, () =>
            {
                cs.StackSize = size;
            });
        }

        /// <summary>
        /// Changing the syrup property should notify property changed
        /// </summary>
        /// <param name="value">syrup or not (default to true so no need to check)</param>
        /// <param name="propertyName">the property changing</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "Syrup")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingSyrupShouldNotifyPropertyChanges(bool value, string propertyName)
        {
            CrashedSaucer cs = new();
            Assert.PropertyChanged(cs, propertyName, () =>
            {
                cs.Syrup = value;
            });
        }

        /// <summary>
        /// Changing the butter property should notify property changed
        /// </summary>
        /// <param name="value">butter or not (default to true so no need to check)</param>
        /// <param name="propertyName">the property changing</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "Butter")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingButterShouldNotifyPropertyChanges(bool value, string propertyName)
        {
            CrashedSaucer cs = new();
            Assert.PropertyChanged(cs, propertyName, () =>
            {
                cs.Butter = value;
            });
        }

        #endregion
        */
    }
}
