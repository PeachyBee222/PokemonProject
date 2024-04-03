using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProjectPokemonProject.DataTests
{
    /// <summary>
    /// The unit tests for the class Liquified Vegitation
    /// </summary>
    public class LiquifiedVegetationUnitTests
    {
        /// <summary>
        /// The unit tests for the liquified vegetation class
        /// </summary>
        public class SaucerFuelUnitTests
        {
            #region default values

            /// <summary>
            /// Checks that an unaltered liquified vegetation is serving size small
            /// </summary>
            [Fact]
            public void DefaultServingSizeShouldBeSmall()
            {
                LiquifiedVegetation lv = new();
                Assert.Equal(ServingSize.Small, lv.Size);
            }

            /// <summary>
            /// Checks that a unaltered Liquified Vegetation is served with ice
            /// </summary>
            [Fact]
            public void DefaultServedWithIce()
            {
                LiquifiedVegetation lv = new();
                Assert.True(lv.Ice);
            }

            /// <summary>
            /// Tests to make sure the description is set properly
            /// </summary>
            [Fact]
            public void DescriptionShouldBeCorrect()
            {
                LiquifiedVegetation lv = new LiquifiedVegetation();
                Assert.Equal("A cold glass of blended vegetable juice.", lv.Description);
            }

            #endregion

            #region state changes

            /// <summary>
            /// This test checks that even as the Liquified Vegetation's state mutates, the name does not change
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
                LiquifiedVegetation lv = new()
                {
                    Size = serving,
                    Ice = ice
                };

                Assert.Equal("Liquified Vegetation", lv.Name);
            }


            /// <summary>
            /// This test checks that even as the Liquified Vegetation's state mutates, the ToString does not change
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
                LiquifiedVegetation lv = new()
                {
                    Size = serving,
                    Ice = ice
                };

                Assert.Equal("Liquified Vegetation", lv.ToString());
            }

            /// <summary>
            /// This test checks that even as the Liquified Vegetation's state mutates, the calories reflect that state
            /// </summary>
            /// <param name="serving">The serving size</param>
            /// <param name="ice">If the drink will be served with ice</param>
            /// <param name="calories">The expected calories, given the specified state</param>
            [Theory]
            [InlineData(ServingSize.Small, true, 72)]
            [InlineData(ServingSize.Medium, true, 144)]
            [InlineData(ServingSize.Large, true, 216)]
            [InlineData(ServingSize.Small, false, 72)]
            [InlineData(ServingSize.Medium, false, 144)]
            [InlineData(ServingSize.Large, false, 216)]
            public void CaloriesShouldBeCorrect(ServingSize serving, bool ice, uint calories)
            {
                LiquifiedVegetation lv = new()
                {
                    Size = serving,
                    Ice = ice
                };
                Assert.Equal(calories, lv.Calories);

            }

            /// <summary>
            /// Checks that the special instructions reflect the current state of the Liquid vegetation
            /// </summary>
            /// <param name="serving">The serving size</param>
            /// <param name="ice">If the drink will be served with ice</param>
            /// <param name="instructions">The expected special instructions</param>
            [Theory]
            [InlineData(ServingSize.Small, true, new string[] { })]
            [InlineData(ServingSize.Medium, false, new string[] { "No Ice", "Medium" })]
            [InlineData(ServingSize.Large, true, new string[] { "Large" })]
            public void SpecialInstructionsRelfectsState(ServingSize serving, bool ice, string[] instructions)
            {
                LiquifiedVegetation lv = new()
                {
                    Size = serving,
                    Ice = ice
                };
                foreach (string instruction in instructions)
                {
                    Assert.Contains(instruction, lv.SpecialInstructions);
                }
                Assert.Equal(instructions.Length, lv.SpecialInstructions.Count());
            }

            /// <summary>
            /// This test checks that even as the Liquified vegetation's state mutates, the price reflect that state
            /// </summary>
            /// <param name="serving">The serving size</param>
            /// <param name="price">The expected price, given the specified state</param>
            [Theory]
            [InlineData(ServingSize.Small, 1.00)]
            [InlineData(ServingSize.Medium, 1.50)]
            [InlineData(ServingSize.Large, 2.00)]
            public void PriceShouldBeCorrect(ServingSize serving, decimal price)
            {
                LiquifiedVegetation lv = new()
                {
                    Size = serving
                };
                Assert.Equal(price, lv.Price);

            }
            #endregion region

            #region IMenuItem Tests

            /// <summary>
            /// Tests to make sure the class can be cast to an IMenuItem
            /// </summary>
            [Fact]
            public void ClassCorrectlyBeingCastToIMenuItem()
            {
                LiquifiedVegetation lv = new();
                Assert.IsAssignableFrom<IMenuItem>(lv);
            }

            #endregion

            #region Abstract Base Class tests

            /// <summary>
            /// Tests to make sure the class can be cast to a base class
            /// </summary>
            [Fact]
            public void ClassCorrectlyBeingCastToBaseClass()
            {
                LiquifiedVegetation lv = new();
                Assert.IsAssignableFrom<Drink>(lv);
            }

            #endregion

            #region Property Changed Unit Tests
            /// <summary>
            /// tests that this class implements the INotifyPropertyChanged
            /// </summary>
            [Fact]
            public void ShouldImplementINotifyChanged()
            {
                LiquifiedVegetation lv = new();
                Assert.IsAssignableFrom<INotifyPropertyChanged>(lv);
            }

            /// <summary>
            /// ensures changing the size changes all of the properties it should change
            /// </summary>
            /// <param name="size">the size to change it to (default is small so no need to test it)</param>
            /// <param name="propertyName">the name of the property that will change</param>
            [Theory]
            [InlineData(ServingSize.Medium, "Size")]
            [InlineData(ServingSize.Large, "Size")]
            [InlineData(ServingSize.Medium, "Price")]
            [InlineData(ServingSize.Large, "Price")]
            [InlineData(ServingSize.Medium, "Calories")]
            [InlineData(ServingSize.Large, "Calories")]
            public void ChangingSizeShouldNotifyOfPropertyChanges(ServingSize size, string propertyName)
            {
                LiquifiedVegetation lv = new();
                Assert.PropertyChanged(lv, propertyName, () =>
                {
                    lv.Size = size;
                });
            }

            /// <summary>
            /// Changing the ice property should notify property changed
            /// </summary>
            [Fact]
            public void ChangingIceShouldNotifyPropertyChanges()
            {
                LiquifiedVegetation lv = new();
                Assert.PropertyChanged(lv, "Ice", () =>
                {
                    lv.Ice = false;
                });
                Assert.PropertyChanged(lv, "Ice", () =>
                {
                    lv.Ice = true;
                });
            }
            #endregion
        }
    }
}
