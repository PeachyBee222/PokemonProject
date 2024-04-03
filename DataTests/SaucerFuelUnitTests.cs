using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonProject.Data;

namespace PokemonProject.DataTests
{
    /// <summary>
    /// The unit tests for the saucer fuel class
    /// </summary>
    public class SaucerFuelUnitTests
    {
        #region default values

        /// <summary>
        /// Checks that an unaltered Saucer fuel is serving size small
        /// </summary>
        [Fact]
        public void DefaultServingSizeShouldBeSmall()
        {
            SaucerFuel sf = new();
            Assert.Equal(ServingSize.Small, sf.Size);
        }

        /// <summary>
        /// Checks that a unaltered Saucer fuel is served without decaf 
        /// </summary>
        [Fact]
        public void DefaultServedWithoutDecaf()
        {
            SaucerFuel sf = new();
            Assert.True(!sf.Decaf);
        }

        /// <summary>
        /// Checks that an unaltered Saucer fuel is served without cream
        /// </summary>
        [Fact]
        public void DefaultServedWithoutCream()
        {
            SaucerFuel sf = new();
            Assert.True(!sf.Cream);
        }

        /// <summary>
        /// Tests to make sure the description is set properly
        /// </summary>
        [Fact]
        public void DescriptionShouldBeCorrect()
        {
            SaucerFuel sf = new SaucerFuel();
            Assert.Equal("A steaming cup of coffee.", sf.Description);
        }

        #endregion

        #region state changes


        /// <summary>
        /// This test checks that even as the SaurcerFuel's state mutates, the ToString does not change
        /// </summary>
        /// <param name="serving">The serving size</param>
        /// <param name="decaf">If the Saucer fuel will be served with decaf</param>
        /// <param name="cream">If the Saucer fuel will be served with cream</param>
        [Theory]
        [InlineData(ServingSize.Small, true, true)]
        [InlineData(ServingSize.Medium, true, true)]
        [InlineData(ServingSize.Large, true, true)]
        [InlineData(ServingSize.Small, true, false)]
        [InlineData(ServingSize.Small, false, false)]
        [InlineData(ServingSize.Medium, true, false)]
        [InlineData(ServingSize.Medium, false, false)]
        [InlineData(ServingSize.Large, true, false)]
        public void ToStringShouldAlwaysBeSaucerFuel(ServingSize serving, bool decaf, bool cream)
        {
            SaucerFuel sf = new()
            {
                Size = serving,
                Decaf = decaf,
                Cream = cream
            };
            if (!sf.Decaf)
            {
                Assert.Equal("Saucer Fuel", sf.ToString());
            }
            else
            {
                Assert.Equal("Decaf Saucer Fuel", sf.ToString());
            }
        }

        /// <summary>
        /// This test checks that even as the SaurcerFuel's state mutates, the name does not change
        /// </summary>
        /// <param name="serving">The serving size</param>
        /// <param name="decaf">If the Saucer fuel will be served with decaf</param>
        /// <param name="cream">If the Saucer fuel will be served with cream</param>
        [Theory]
        [InlineData(ServingSize.Small, true, true)]
        [InlineData(ServingSize.Medium, true, true)]
        [InlineData(ServingSize.Large, true, true)]
        [InlineData(ServingSize.Small, true, false)]
        [InlineData(ServingSize.Small, false, false)]
        [InlineData(ServingSize.Medium, true, false)]
        [InlineData(ServingSize.Medium, false, false)]
        [InlineData(ServingSize.Large, true, false)]
        public void NameShouldAlwaysBeSaucerFuel(ServingSize serving, bool decaf, bool cream)
        {
            SaucerFuel sf = new()
            {
                Size = serving,
                Decaf = decaf,
                Cream = cream
            };
            if (!sf.Decaf)
            {
                Assert.Equal("Saucer Fuel", sf.Name);
            }
            else
            {
                Assert.Equal("Decaf Saucer Fuel", sf.Name);
            }
        }

        /// <summary>
        /// This test checks that even as the SaucerFuel's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="serving">The serving size</param>
        /// <param name="decaf">If the Saucer fuel will be served decaf</param>
        /// <param name="cream">If the Saucer fuel will be served with cream</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(ServingSize.Small, true, true, 1 + 29)]
        [InlineData(ServingSize.Medium, true, true, 2 + 29)]
        [InlineData(ServingSize.Large, true, true, 3 + 29)]
        [InlineData(ServingSize.Small, true, false, 1)]
        [InlineData(ServingSize.Small, false, false, 1)]
        [InlineData(ServingSize.Medium, true, false, 2)]
        [InlineData(ServingSize.Medium, false, false, 2)]
        [InlineData(ServingSize.Large, true, false, 3)]
        public void CaloriesShouldBeCorrect(ServingSize serving, bool decaf, bool cream, uint calories)
        {
            SaucerFuel sf = new()
            {
                Size = serving,
                Decaf = decaf,
                Cream = cream
            };
            Assert.Equal(calories, sf.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Saucer fuel
        /// </summary>
        /// <param name="serving">The serving size</param>
        /// <param name="decaf">If the Saucer fuel will be served decaf</param>
        /// <param name="cream">If the Saucer fuel will be served with cream</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(ServingSize.Small, true, false, new string[] { })]
        [InlineData(ServingSize.Medium, true, true, new string[] { "With Cream", "Medium" })]
        [InlineData(ServingSize.Large, true, false, new string[] { "Large"})]
        public void SpecialInstructionsRelfectsState(ServingSize serving, bool decaf, bool cream, string[] instructions)
        {
            SaucerFuel sf = new()
            {
                Size = serving,
                Decaf = decaf,
                Cream = cream
            };
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, sf.SpecialInstructions);
            }
            Assert.Equal(instructions.Length, sf.SpecialInstructions.Count());
        }

        /// <summary>
        /// This test checks that even as the Saucer Fuel's state mutates, the price reflect that state
        /// </summary>
        /// <param name="serving">The serving size</param>
        /// <param name="price">The expected price, given the specified state</param>
        [Theory]
        [InlineData(ServingSize.Small, 1.00)]
        [InlineData(ServingSize.Medium, 1.50)]
        [InlineData(ServingSize.Large, 2.00)]
        public void PriceShouldBeCorrect(ServingSize serving, decimal price)
        {
            SaucerFuel sf = new()
            {
                Size = serving
            };
            Assert.Equal(price, sf.Price);

        }
        #endregion region

        #region IMenuItem Tests

        /// <summary>
        /// Tests to make sure the class can be cast to an IMenuItem
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToIMenuItem()
        {
            SaucerFuel sf = new();
            Assert.IsAssignableFrom<IMenuItem>(sf);
        }

        #endregion

        #region Abstract Base Class tests

        /// <summary>
        /// Tests to make sure the class can be cast to a base class
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToBaseClass()
        {
            SaucerFuel sf = new();
            Assert.IsAssignableFrom<Drink>(sf);
        }

        #endregion

        #region Property Changes Tests
        /// <summary>
        /// tests that this class implements the INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            SaucerFuel saucerFuel = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(saucerFuel);
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
        [InlineData(ServingSize.Medium, "SpecialInstructions")]
        [InlineData(ServingSize.Large, "SpecialInstructions")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(ServingSize size, string propertyName)
        {
            SaucerFuel saucerFuel = new();
            Assert.PropertyChanged(saucerFuel, propertyName, () =>
            {
                saucerFuel.Size = size;
            });
        }

        /// <summary>
        /// Changing the decaf property should notify property changed
        /// </summary>
        [Fact]
        public void ChangingDecafShouldNotifyPropertyChanges()
        {
            SaucerFuel saucerFuel = new();
            Assert.PropertyChanged(saucerFuel, "Decaf", () =>
            {
                saucerFuel.Decaf = true;
            });
            Assert.PropertyChanged(saucerFuel, "Decaf", () =>
            {
                saucerFuel.Decaf = false;
            });
        }

        /// <summary>
        /// Changing the cream property should notify property changed
        /// </summary>
        [Fact]
        public void ChangingCreamShouldNotifyPropertyChanges()
        {
            SaucerFuel saucerFuel = new();
            Assert.PropertyChanged(saucerFuel, "Cream", () =>
            {
                saucerFuel.Cream = true;
            });
            Assert.PropertyChanged(saucerFuel, "Cream", () =>
            {
                saucerFuel.Cream = false;
            });
        }

        #endregion
    }
}
