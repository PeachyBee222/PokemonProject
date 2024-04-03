using System.ComponentModel;

namespace PokemonProjectPokemonProject.DataTests
{
    /// <summary>
    /// Unit tests for the FlyingSaucer class
    /// </summary>
    public class FlyingSaucerUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that an unaltered Flying Saucer has 6 panacakes
        /// </summary>
        [Fact]
        public void DefaultStackSizeShouldBeSixPancakes()
        {
            FlyingSaucer fs = new();
            Assert.Equal(6u, fs.StackSize);
        }

        /// <summary>
        /// Checks that a unaltered Flying Saucer is served with syrup 
        /// </summary>
        [Fact]
        public void DefaultServedWithSyrup()
        {
            FlyingSaucer fs = new();
            Assert.True(fs.Syrup);
        }

        /// <summary>
        /// Checks that an unaltered Flying Saucer is served with berries
        /// </summary>
        [Fact]
        public void DefaultServedWithBerries()
        {
            FlyingSaucer fs = new();
            Assert.True(fs.Berries);
        }

        /// <summary>
        /// Checks that an unmodified Flying Saucer is served with whipped cream
        /// </summary>
        [Fact]
        public void DefaultServedWithWhippedCream()
        {
            FlyingSaucer fs = new();
            Assert.True(fs.WhippedCream);
        }

        /// <summary>
        /// Tests to make sure the description is set properly
        /// </summary>
        [Fact]
        public void DescriptionShouldBeCorrect()
        {
            FlyingSaucer fs = new FlyingSaucer();
            Assert.Equal("A stack of six pancakes, smothered in rich maple syrup, and topped with mixed berries and whipped cream.", fs.Description);
        }
        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the FlyingSaucer's state mutates, the name does not change
        /// </summary>
        /// <param name="stackSize">The number of panacakes included</param>
        /// <param name="syrup">If the Flying Saucer will be served with syrup</param>
        /// <param name="whippedCream">If the Flying Saucer will be served with whipped cream</param>
        /// <param name="berries">If the Flying Saucer will be served with berries</param>
        /// <remarks>There are more than 8 possible permutations of state, so we pick a subset to test against</remarks>
        [Theory]
        [InlineData(6, true, true, true)]
        [InlineData(0, true, true, true)]
        [InlineData(12, true, true, true)]
        [InlineData(6, true, false, true)]
        [InlineData(6, false, false, true)]
        [InlineData(3, true, false, false)]
        [InlineData(8, false, false, false)]
        [InlineData(11, true, true, false)]
        public void NameShouldAlwaysBeFlyingSaucer(uint stackSize, bool syrup, bool whippedCream, bool berries)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                WhippedCream = whippedCream,
                Berries = berries
            };
            Assert.Equal("Flying Saucer", fs.Name);
        }

        /// <summary>
        /// This test checks that even as the FlyingSaucer's state mutates, the ToString does not change
        /// </summary>
        /// <param name="stackSize">The number of panacakes included</param>
        /// <param name="syrup">If the Flying Saucer will be served with syrup</param>
        /// <param name="whippedCream">If the Flying Saucer will be served with whipped cream</param>
        /// <param name="berries">If the Flying Saucer will be served with berries</param>
        /// <remarks>There are more than 8 possible permutations of state, so we pick a subset to test against</remarks>
        [Theory]
        [InlineData(6, true, true, true)]
        [InlineData(0, true, true, true)]
        [InlineData(12, true, true, true)]
        [InlineData(6, true, false, true)]
        [InlineData(6, false, false, true)]
        [InlineData(3, true, false, false)]
        [InlineData(8, false, false, false)]
        [InlineData(11, true, true, false)]
        public void ToStringShouldAlwaysBeFlyingSaucer(uint stackSize, bool syrup, bool whippedCream, bool berries)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                WhippedCream = whippedCream,
                Berries = berries
            };
            Assert.Equal("Flying Saucer", fs.ToString());
        }

        /// <summary>
        /// This test verifies that a FlyingSaucer's StackSize cannot exceed 12, and 
        /// if it is attempted, the StackSize will be set to 12.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetStackSizeAboveTwelve()
        {
            FlyingSaucer fs = new();
            fs.StackSize = 13;
            Assert.Equal(12u, fs.StackSize);
        }

        /// <summary>
        /// This test checks that even as the FlyingSaucer's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="stackSize">The number of panacakes included</param>
        /// <param name="syrup">If the Flying Saucer will be served with syrup</param>
        /// <param name="whippedCream">If the Flying Saucer will be served with whipped cream</param>
        /// <param name="berries">If the Flying Saucer will be served with berries</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(6, true, true, true, 64 * 6 + 32 + 414 + 89)]
        [InlineData(0, true, true, true, 64 * 0 + 32 + 414 + 89)]
        [InlineData(12, true, true, true, 64 * 12 + 32 + 414 + 89)]
        [InlineData(6, true, false, true, 64 * 6 + 32 + 0 + 89)]
        [InlineData(6, false, false, true, 64 * 6 + 0 + 0 + 89)]
        [InlineData(3, true, false, false, 64 * 3 + 32 + 0 + 0)]
        [InlineData(8, false, false, false, 64 * 8 + 0 + 0 + 0)]
        [InlineData(11, true, true, false, 64 * 11 + 32 + 414 + 0)]
        public void CaloriesShouldBeCorrect(uint stackSize, bool syrup, bool whippedCream, bool berries, uint calories)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                WhippedCream = whippedCream,
                Berries = berries
            };
            Assert.Equal(calories, fs.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Flying Saucer
        /// </summary>
        /// <param name="stackSize">The number of panacakes</param>
        /// <param name="syrup">If served with syrup</param>
        /// <param name="whippedCream">If served with whipped cream</param>
        /// <param name="berries">If served with berries</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(6, true, true, true, new string[] { })]
        [InlineData(4, true, true, true, new string[] { "4 Pancakes" })]
        public void SpecialInstructionsRelfectsState(uint stackSize, bool syrup, bool whippedCream, bool berries, string[] instructions)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                WhippedCream = whippedCream,
                Berries = berries
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, fs.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, fs.SpecialInstructions.Count());
        }

        /// <summary>
        /// This test checks that even as the FlyingSaucer's state mutates, the price reflect that state
        /// </summary>
        /// <param name="stackSize">The number of panacakes included</param>
        /// <param name="price">The expected price, given the specified state</param>
        /// <remarks>
        /// We supply the expected price as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected price are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(6, 8.5)]
        [InlineData(5, 8.5 - .5)]
        [InlineData(10, 8.5 + 4 * .5)]
        [InlineData(9, 8.5 + 3 * .5)]
        [InlineData(8, 8.5 + 2 * .5)]
        [InlineData(7, 8.5 + .5)]
        [InlineData(12, 8.5 + 6 * .5)]
        [InlineData(13, 8.5 + 6 * .5)] //edge case, not allowed to go over 12 pancakes
        public void PriceShouldBeCorrect(uint stackSize, decimal price)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize,
            };
            Assert.Equal(price, fs.Price);

        }
        #endregion

        #region IMenuItem Tests

        /// <summary>
        /// Tests to make sure the class can be cast to an IMenuItem
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToIMenuItem()
        {
            FlyingSaucer fs = new();
            Assert.IsAssignableFrom<IMenuItem>(fs);
        }

        #endregion

        #region Abstract Base Class tests

        /// <summary>
        /// Tests to make sure the class can be cast to a base class
        /// </summary>
        [Fact]
        public void ClassCorrectlyBeingCastToBaseClass()
        {
            FlyingSaucer fs = new();
            Assert.IsAssignableFrom<Entree>(fs);
        }

        #endregion

        #region Property Changed Unit Tests
        /// <summary>
        /// tests that this class implements the INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            FlyingSaucer fs = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(fs);
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
            FlyingSaucer fs = new();
            Assert.PropertyChanged(fs, propertyName, () =>
            {
                fs.StackSize = size;
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
            FlyingSaucer fs = new();
            Assert.PropertyChanged(fs, propertyName, () =>
            {
                fs.Syrup = value;
            });
        }

        /// <summary>
        /// Changing the whipped chream property should notify property changed
        /// </summary>
        /// <param name="value">whipped cream or not (default to true so no need to check)</param>
        /// <param name="propertyName">the property changing</param>
        [Theory]
        [InlineData(false, "Calories")]
        [InlineData(false, "WhippedCream")]
        [InlineData(false, "SpecialInstructions")]
        public void ChangingWhippedCreamShouldNotifyPropertyChanges(bool value, string propertyName)
        {
            FlyingSaucer fs = new();
            Assert.PropertyChanged(fs, propertyName, () =>
            {
                fs.WhippedCream = value;
            });
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
            FlyingSaucer fs = new();
            Assert.PropertyChanged(fs, propertyName, () =>
            {
                fs.Berries = value;
            });
        }
        #endregion

    }
}