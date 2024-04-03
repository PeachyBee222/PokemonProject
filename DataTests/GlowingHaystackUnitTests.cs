using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProjectPokemonProject.DataTests
{
    /// <summary>
    /// Unit tests for glowing haystack
    /// </summary>
    public class GlowingHaystackUnitTests
    {
        #region default values
        /// <summary>
        /// Checks that a unaltered Glowing Haystack is served with sour cream 
        /// </summary>
        [Fact]
        public void DefaultServedWithSourCream()
        {
            GlowingHaystack gh = new();
            Assert.True(gh.SourCream);
        }
        /// <summary>
        /// Checks that a unaltered Glowing Haystack is served with green chile sauce 
        /// </summary>
        [Fact]
        public void DefaultServedWithGreenChileSauce()
        {
            GlowingHaystack gh = new();
            Assert.True(gh.GreenChileSauce);
        }

        /// <summary>
        /// Checks that a unaltered Glowing Haystack is served with tomatoes 
        /// </summary>
        [Fact]
        public void DefaultServedWithTomatoes()
        {
            GlowingHaystack gh = new();
            Assert.True(gh.Tomatoes);
        }

        /// <summary>
        /// Tests to make sure the description is set properly
        /// </summary>
        [Fact]
        public void DescriptionShouldBeCorrect()
        {
            GlowingHaystack gh = new GlowingHaystack();
            Assert.Equal("Hash browns smothered in green chile sauce, sour cream, and topped with tomatoes.", gh.Description);
        }

        #endregion

        #region state changes
        /// <summary>
        /// This test checks that even as the GlowingHaystack's state mutates, the name does not change
        /// </summary>
        /// <param name="sourCream">If the Glowing Haystack will be served with sour cream</param>
        /// <param name="greenChileSauce">If the Glowing Haystack will be served with green chile sauce</param>
        /// <param name="tomatoes">If the Glowing Haystack will be served with tomatoes</param>
        [Theory]
        [InlineData(true, true, true)]
        [InlineData(false, true, true)]
        [InlineData(true, false, true)]
        [InlineData(false, true, false)]
        [InlineData(true, false, false)]
        [InlineData(false, false, false)]
        [InlineData(true, true, false)]
        [InlineData(false, false, true)]
        public void NameShouldAlwaysBeGlowingHaystack(bool sourCream, bool greenChileSauce, bool tomatoes)
        {
            GlowingHaystack gh = new()
            {
                SourCream = sourCream,
                GreenChileSauce = greenChileSauce,
                Tomatoes = tomatoes
            };
            Assert.Equal("Glowing Haystack", gh.Name);
        }

        /// <summary>
        /// This test checks that even as the GlowingHaystack's state mutates, the ToString does not change
        /// </summary>
        /// <param name="sourCream">If the Glowing Haystack will be served with sour cream</param>
        /// <param name="greenChileSauce">If the Glowing Haystack will be served with green chile sauce</param>
        /// <param name="tomatoes">If the Glowing Haystack will be served with tomatoes</param>
        [Theory]
        [InlineData(true, true, true)]
        [InlineData(false, true, true)]
        [InlineData(true, false, true)]
        [InlineData(false, true, false)]
        [InlineData(true, false, false)]
        [InlineData(false, false, false)]
        [InlineData(true, true, false)]
        [InlineData(false, false, true)]
        public void ToStringShouldAlwaysBeGlowingHaystack(bool sourCream, bool greenChileSauce, bool tomatoes)
        {
            GlowingHaystack gh = new()
            {
                SourCream = sourCream,
                GreenChileSauce = greenChileSauce,
                Tomatoes = tomatoes
            };
            Assert.Equal("Glowing Haystack", gh.ToString());
        }

        /// <summary>
        /// This test checks that even as the GlowingHaystack's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="sourCream">If the Glowing Haystack will be served with sour cream</param>
        /// <param name="greenChileSauce">If the Glowing Haystack will be served with green chile sauce</param>
        /// <param name="tomatoes">If the Glowing Haystack will be served with tomatoes</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(true, true, true, 470 + 15 + 23 + 22)]
        [InlineData(false, true, true, 470 + 0 + 23 + 22)]
        [InlineData(true, false, true, 470 + 15 + 0 + 22)]
        [InlineData(false, true, false, 470 + 0 + 23 + 0)]
        [InlineData(true, false, false, 470 + 15 + 0 + 0)]
        [InlineData(false, false, false, 470 + 0 + 0 + 0)]
        [InlineData(true, true, false, 470 + 15 + 23 + 0)]
        [InlineData(false, false, true, 470 + 0 + 0 + 22)]
        public void CaloriesShouldBeCorrect(bool greenChileSauce, bool sourCream, bool tomatoes, uint calories)
        {
            GlowingHaystack gh = new()
            {
                SourCream = sourCream,
                GreenChileSauce = greenChileSauce,
                Tomatoes = tomatoes
            };
            Assert.Equal(calories, gh.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Glowing Haystack
        /// </summary>
        /// <param name="sourCream">If the Glowing Haystack will be served with sour cream</param>
        /// <param name="greenChileSauce">If the Glowing Haystack will be served with green chile sauce</param>
        /// <param name="tomatoes">If the Glowing Haystack will be served with tomatoes</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, true, true, new string[] { })]
        [InlineData(true, true, false, new string[] { "Hold Tomatoes" })]
        [InlineData(false, true, false, new string[] { "Hold Green Chile Sauce", "Hold Tomatoes" })]
        public void SpecialInstructionsRelfectsState(bool greenChileSauce, bool sourCream, bool tomatoes, string[] instructions)
        {
            GlowingHaystack gh = new()
            {
                SourCream = sourCream,
                GreenChileSauce = greenChileSauce,
                Tomatoes = tomatoes
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, gh.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, gh.SpecialInstructions.Count());
        }

        /// <summary>
        /// This test checks that even as the GlowingHaystack's state mutates, the price reflect that state
        /// </summary>
        /// <param name="price">The expected price, given the specified state</param>
        [Fact]
        public void PriceShouldBeCorrect()
        {
            GlowingHaystack gh = new();
            Assert.Equal(2, gh.Price);
        }
        #endregion

        #region IMenuItem Tests

        /// <summary>
        /// Tests to make sure the class can be cast to an IMenuItem
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToIMenuItem()
        {
            GlowingHaystack gh = new();
            Assert.IsAssignableFrom<IMenuItem>(gh);
        }

        #endregion

        #region Abstract Base Class tests

        /// <summary>
        /// Tests to make sure the class can be cast to a base class
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToBaseClass()
        {
            GlowingHaystack gh = new();
            Assert.IsAssignableFrom<Side>(gh);
        }

        #endregion

        #region Property Changed Unit Tests
        /// <summary>
        /// tests that this class implements the INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            GlowingHaystack gh = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(gh);
        }

        /// <summary>
        /// Changing the sour cream property should notify property changed
        /// </summary>
        /// <param name="value">sour cream or not (default to true so no need to check)</param>
        /// <param name="propertyName">the property changing</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "SourCream")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingSourCreamShouldNotifyPropertyChanges(bool value, string propertyName)
        {
            GlowingHaystack gh = new();
            Assert.PropertyChanged(gh, propertyName, () =>
            {
                gh.SourCream = value;
            });
        }

        /// <summary>
        /// Changing the green chile sauce property should notify property changed
        /// </summary>
        /// <param name="value">green chile sauce or not (default to true so no need to check)</param>
        /// <param name="propertyName">the property changing</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "GreenChileSauce")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingGreenChileSauceShouldNotifyPropertyChanges(bool value, string propertyName)
        {
            GlowingHaystack gh = new();
            Assert.PropertyChanged(gh, propertyName, () =>
            {
                gh.GreenChileSauce = value;
            });
        }

        /// <summary>
        /// Changing the tomatoes property should notify property changed
        /// </summary>
        /// <param name="value">tomatoes or not (default to true so no need to check)</param>
        /// <param name="propertyName">the property changing</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "Tomatoes")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingTomatoesShouldNotifyPropertyChanges(bool value, string propertyName)
        {
            GlowingHaystack gh = new();
            Assert.PropertyChanged(gh, propertyName, () =>
            {
                gh.Tomatoes = value;
            });
        }

        #endregion
    }
}
