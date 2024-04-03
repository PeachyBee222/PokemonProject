using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProject.DataTests
{
    /// <summary>
    /// The unit tests for the inorganic substance class
    /// </summary>
    public class InorganicSubstanceUnitTests
    {
        #region default values

        /// <summary>
        /// Checks that an unaltered inorganic substance is serving size small
        /// </summary>
        [Fact]
        public void DefaultServingSizeShouldBeSmall()
        {
            InorganicSubstance ins = new();
            Assert.Equal(ServingSize.Small, ins.Size);
        }

        /// <summary>
        /// Checks that a unaltered inorganic substance is served with ice
        /// </summary>
        [Fact]
        public void DefaultServedWithIce()
        {
            InorganicSubstance ins = new();
            Assert.True(ins.Ice);
        }

        /// <summary>
        /// Tests to make sure the description is set properly
        /// </summary>
        [Fact]
        public void DescriptionShouldBeCorrect()
        {
            InorganicSubstance ins = new InorganicSubstance();
            Assert.Equal("A cold glass of ice water.", ins.Description);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the Inorganic Substance's state mutates, the name does not change
        /// </summary>
        /// <param name="serving">The serving size</param>
        /// <param name="ice">If the drink will be served with ice</param>
        [Theory]
        [InlineData(ServingSize.Small, true)]
        [InlineData(ServingSize.Medium, true)]
        [InlineData(ServingSize.Large, true)]
        [InlineData(ServingSize.Small, false)]
        [InlineData(ServingSize.Medium, false)]
        [InlineData(ServingSize.Large, false)]
        public void NameShouldAlwaysBeSaucerFuel(ServingSize serving, bool ice)
        {
            InorganicSubstance ins = new()
            {
                Size = serving,
                Ice = ice
            };

            Assert.Equal("Inorganic Substance", ins.Name);
        }

        /// <summary>
        /// This test checks that even as the Inorganic Substance's state mutates, the ToString does not change
        /// </summary>
        /// <param name="serving">The serving size</param>
        /// <param name="ice">If the drink will be served with ice</param>
        [Theory]
        [InlineData(ServingSize.Small, true)]
        [InlineData(ServingSize.Medium, true)]
        [InlineData(ServingSize.Large, true)]
        [InlineData(ServingSize.Small, false)]
        [InlineData(ServingSize.Medium, false)]
        [InlineData(ServingSize.Large, false)]
        public void ToStringShouldAlwaysBeSaucerFuel(ServingSize serving, bool ice)
        {
            InorganicSubstance ins = new()
            {
                Size = serving,
                Ice = ice
            };

            Assert.Equal("Inorganic Substance", ins.ToString());
        }

        /// <summary>
        /// This test checks that even as the Inorganic Substance's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="serving">The serving size</param>
        /// <param name="ice">If the drink will be served with ice</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(ServingSize.Small, true, 0)]
        [InlineData(ServingSize.Medium, true, 0)]
        [InlineData(ServingSize.Large, true, 0)]
        [InlineData(ServingSize.Small, false, 0)]
        [InlineData(ServingSize.Medium, false, 0)]
        [InlineData(ServingSize.Large, false, 0)]
        public void CaloriesShouldBeCorrect(ServingSize serving, bool ice, uint calories)
        {
            InorganicSubstance ins = new()
            {
                Size = serving,
                Ice = ice
            };
            Assert.Equal(calories, ins.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Inorganic Substance
        /// </summary>
        /// <param name="serving">The serving size</param>
        /// <param name="ice">If the drink will be served with ice</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(ServingSize.Small, true, new string[] { })]
        [InlineData(ServingSize.Medium, false, new string[] { "No Ice" , "Medium"})]
        [InlineData(ServingSize.Large, true, new string[] { "Large" })]
        public void SpecialInstructionsRelfectsState(ServingSize serving, bool ice, string[] instructions)
        {
            InorganicSubstance ins = new()
            {
                Size = serving,
                Ice = ice
            };
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, ins.SpecialInstructions);
            }
            Assert.Equal(instructions.Length, ins.SpecialInstructions.Count());
        }

        /// <summary>
        /// This test checks that even as the Inorganic Subatance's state mutates, the price reflect that state
        /// </summary>
        /// <param name="serving">The serving size</param>
        /// <param name="price">The expected price, given the specified state</param>
        [Theory]
        [InlineData(ServingSize.Small, 0)]
        [InlineData(ServingSize.Medium, 0)]
        [InlineData(ServingSize.Large, 0)]
        public void PriceShouldBeCorrect(ServingSize serving, decimal price)
        {
            InorganicSubstance ins = new()
            {
                Size = serving
            };
            Assert.Equal(price, ins.Price);

        }
        #endregion region

        #region IMenuItem Tests

        /// <summary>
        /// Tests to make sure the class can be cast to an IMenuItem
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToIMenuItem()
        {
            InorganicSubstance ins = new();
            Assert.IsAssignableFrom<IMenuItem>(ins);
        }

        #endregion

        #region Abstract Base Class tests

        /// <summary>
        /// Tests to make sure the class can be cast to a base class
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToBaseClass()
        {
            InorganicSubstance ins = new();
            Assert.IsAssignableFrom<Drink>(ins);
        }

        #endregion

        #region Property Changed Unit Tests
        /// <summary>
        /// tests that this class implements the INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            InorganicSubstance ins = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(ins);
        }

        /// <summary>
        /// ensures changing the size changes all of the properties it should change
        /// </summary>
        /// <param name="size">the size to change it to (default is small so no need to test it)</param>
        /// <param name="propertyName">the name of the property that will change</param>
        [Theory]
        [InlineData(ServingSize.Medium, "Size")]
        [InlineData(ServingSize.Large, "Size")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(ServingSize size, string propertyName)
        {
            InorganicSubstance ins = new();
            Assert.PropertyChanged(ins, propertyName, () =>
            {
                ins.Size = size;
            });
        }

        /// <summary>
        /// Changing the ice property should notify property changed
        /// </summary>
        [Fact]
        public void ChangingIceShouldNotifyPropertyChanges()
        {
            InorganicSubstance ins = new();
            Assert.PropertyChanged(ins, "Ice", () =>
            {
                ins.Ice = false;
            });
            Assert.PropertyChanged(ins, "Ice", () =>
            {
                ins.Ice = true;
            });
        }
        #endregion
    }
}
