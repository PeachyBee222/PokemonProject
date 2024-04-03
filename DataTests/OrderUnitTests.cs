using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace PokemonProject.DataTests
{
    /// <summary>
    /// The unit tests for the order class
    /// </summary>
    public class OrderUnitTests
    {
        #region default unit tests

        /// <summary>
        /// Subtotal calculates correctly from sample items in the order
        /// </summary>
        [Fact]
        public void SubtotalShouldBeCorrectlyCalculated()
        {
            Order order = new Order();
            order.Add(new SampleMenuItem() { Price = 3.00m });
            order.Add(new SampleMenuItem() { Price = 3.50m });
            order.Add(new SampleMenuItem() { Price = 2.00m });
            Assert.Equal(8.50m, order.Subtotal);
        }

        /// <summary>
        /// Total price should be calculated correctly
        /// </summary>
        /// <param name="price1">price of the first item</param>
        /// <param name="price2">price of the second item</param>
        /// <param name="price3">price of the third item</param>
        /// <param name="taxRate">the specified tax rate</param>
        /// <param name="total">the correct total that should be calculated</param>
        [Theory]
        [InlineData(1,2,3,0.1,6.6)]
        [InlineData(1,3,2,0.1,6.6)]
        [InlineData(1,8,4,0.2,15.6)]
        [InlineData(2,3,6,0.2,13.2)]
        public void TotalShouldBeCorrectlyCalculated(decimal price1, decimal price2, decimal price3, decimal taxRate, decimal total)
        {
            Order order = new Order();
            order.Add(new SampleMenuItem() { Price = price1 });
            order.Add(new SampleMenuItem() { Price = price2 });
            order.Add(new SampleMenuItem() { Price = price3 });
            order.TaxRate = taxRate;
            Assert.Equal(total, order.Total);
        }

        /// <summary>
        /// Tax rate correctly calculates from sample items
        /// </summary>
        [Fact]
        public void TaxShouldBeCorrectlyCalculated()
        {
            Order order = new Order();
            order.Add(new SampleMenuItem() { Price = 3.00m });
            order.Add(new SampleMenuItem() { Price = 3.50m });
            order.Add(new SampleMenuItem() { Price = 2.50m });
            order.TaxRate = 0.20m;
            Assert.Equal(1.8m, order.Tax);
        }

        /// <summary>
        /// The order contains the correct names of the items and the correct number of items in the list and ensures items can be added
        /// </summary>
        [Fact]
        public void OrderContainsTheCorectItemsAdded()
        {
            Order order = new Order();
            order.Add(new SampleMenuItem() { Name = "1" });
            order.Add(new SampleMenuItem() { Name = "2" });
            order.Add(new SampleMenuItem() { Name = "3" });
            int i = 1;
            foreach(IMenuItem item in order)
            {
                Assert.Equal($"{i}", item.Name);
                i++;
            }
        }
        /// <summary>
        /// Tests to make sure the remove method removes specified item in the order
        /// </summary>
        [Fact]
        public void RemoveShouldRemoveItemInTheOrder()
        {
            Order order = new Order();
            SampleMenuItem sm = new SampleMenuItem();
            order.Add(sm);
            Assert.True(order.Remove(sm));
            Assert.DoesNotContain(sm, order);
        }

        /// <summary>
        /// Tests to make sure the contains method works properly
        /// </summary>
        [Fact]
        public void ContainsShouldBeTrueIfItemIsInTheOrder()
        {
            Order order = new Order();
            SampleMenuItem sm = new SampleMenuItem();
            order.Add(sm);
            Assert.True(order.Contains(sm));
            Assert.Contains<IMenuItem>(sm, order);
        }

        /// <summary>
        /// Tests to make sure the clear should remove all items in the order
        /// </summary>
        [Fact]
        public void ClearShouldRemoveAllItemsInTheOrder()
        {
            Order order = new Order();
            SampleMenuItem sm1 = new SampleMenuItem();
            SampleMenuItem sm2 = new SampleMenuItem();
            order.Add(sm1);
            order.Add(sm2);
            order.Clear();
            Assert.Equal(0, order.Count);
        }
        /// <summary>
        /// Tests to make sure the copyto method properly copies from the order to an array
        /// </summary>
        [Fact]
        public void CopyToMethodShouldCopyToAnArray()
        {
            Order order = new Order();
            IMenuItem[] array = new IMenuItem[2];
            SampleMenuItem sm1 = new SampleMenuItem();
            SampleMenuItem sm2 = new SampleMenuItem();
            order.Add(sm1);
            order.Add(sm2);
            order.CopyTo(array, 0);
            order.Clear();
            Assert.Contains<IMenuItem>(sm2, array);
            Assert.Contains<IMenuItem>(sm1, array);
        }

        /// <summary>
        /// Tax rate should be set correctly
        /// </summary>
        [Fact]
        public void TaxRateShouldBeCorrectlyCalculated()
        {
            Order order = new Order();
            order.TaxRate = 0.10m;
            Assert.Equal(0.10m, order.TaxRate);
        }
        #endregion

        #region ICollection Tests

        /// <summary>
        /// Tests to make sure changing the tax rate notifies the property it has changed
        /// </summary>
        [Fact]
        public void ChangingTaxRateShouldNotifyOfPropertyChange() //FIXME THIS IS FAILING
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "TaxRate", () => {
                order.TaxRate = 0.20m;
            });
        }

        /// <summary>
        /// Tests to ensure changing tax rate changes the calculated tax
        /// </summary>
        /// <param name="taxRate">the specified tax rate</param>
        /// <param name="subtotal">the specified subtotal</param>
        /// <param name="tax">the given tax</param>
        [Theory]
        [InlineData(0.15, 0.6)]
        [InlineData(0.2,0.8)]
        [InlineData(0,0)]
        [InlineData(.5, 2)]
        public void ChangingTaxRateShouldChangeTax(decimal taxRate, decimal tax)
        {
            Order order = new Order() { TaxRate = taxRate};
            order.Add(new CropCircle()); //2.00 is the price
            order.Add(new YouAreToast()); //2.00 is default price
            Assert.Equal(tax, order.Tax);
        }

        /// <summary>
        /// Tests to ensure making changes to the tax rate changes the calculated total
        /// </summary>
        /// <param name="taxRate">specified tax rate</param>
        /// <param name="total">what the total should be</param>
        [Theory]
        [InlineData(0.15,4.6)]
        [InlineData(0.2,4.8)]
        [InlineData(0,4)]
        [InlineData(0.5,6)]
        public void ChangingTaxRateShouldChangeTotal(decimal taxRate, decimal total)
        {
            Order order = new Order() { TaxRate = taxRate };
            order.Add(new CropCircle()); //2.00 is the price
            order.Add(new YouAreToast()); //2.00 is default price
            Assert.Equal(total, order.Total);
        }

        /// <summary>
        /// Tests that the order class impliments the INotifyPorpertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(order);
        }

        /// <summary>
        /// Checks if the collection changed when adding a menu item
        /// </summary>
        [Fact]
        public void AddingItemTriggersCollectionChanged()
        {
            Order order = new Order();
            IMenuItem item = new SampleMenuItem();
            MyAssert.NotifyCollectionChangedAdd(order, item, () => { order.Add(item); });
        }

        /// <summary>
        /// Checks if the collection changed when removing a menu item
        /// </summary>
        [Fact]
        public void RemovingItemTriggersCollectionChanged()
        {
            Order order = new Order();
            IMenuItem item = new SampleMenuItem();
            order.Add(item);
            MyAssert.NotifyCollectionChangedRemove(order, item, () => { order.Remove(item); });
        }

        /// <summary>
        /// tests to make sure the order can be cast to an INotifyCollectionChanged instance
        /// </summary>
        [Fact]
        public void OrderCanBeCastToINotifyCollectionChanged()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<INotifyCollectionChanged>(order);
        }

        /// <summary>
        /// Tests to make sure the order number increases by one each time a new order is made.
        /// </summary>
        [Fact]
        public void OrderNumberShouldUpdateByOneEachTime()
        {
            var order1 = new Order();
            var order2 = new Order();
            var order3 = new Order();

            Assert.Equal(order1.Number+1, order2.Number);
            Assert.Equal(order2.Number+1, order3.Number);
        }

        /// <summary>
        /// The date and time should equal the proper time aligning with when the order was made
        /// </summary>
        [Fact]
        public void PlacedAtShouldBeCorrectDateAndTime() 
        { 
            Assert.Equal(DateTime.Now, new Order().PlacedAt, new TimeSpan(0,0,1)); //called within one second of each other
        }

        /// <summary>
        /// Neither the number of the placed at property should change when they are called.
        /// </summary>
        [Fact]
        public void PropertiesDoNotChangeWhenRequestedTwice()
        {
            var order = new Order();
            var number = order.Number;
            var date = order.PlacedAt;
            Thread.Sleep(1000);
            Assert.Equal(date, order.PlacedAt);
            Assert.Equal(number, order.Number);
        }

        #endregion

        #region sample class
        /// <summary>
        /// A sample class for testing the order class
        /// </summary>
        internal class SampleMenuItem : IMenuItem
        {
            /// <summary>
            /// The name of the sample test
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// the description of the sample item
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// the price of the sample item
            /// </summary>
            public decimal Price { get; set; }

            /// <summary>
            /// the calories of the sample item
            /// </summary>
            public uint Calories { get; set; }

            /// <summary>
            /// the special instructions of the sample item
            /// </summary>
            public IEnumerable<string> SpecialInstructions { get; set; }

            public event PropertyChangedEventHandler? PropertyChanged;
        }

        #endregion
    }
}
