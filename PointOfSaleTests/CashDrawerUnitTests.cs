using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TheFlyingSaucer.PointOfSale;
using System.CodeDom.Compiler;

namespace TheFlyingSaucer.PointOfSale.UnitTests
{
    /// <summary>
    /// tests for the CashDrawerViewModel
    /// </summary>
    public class CashDrawerUnitTests
    {
        /// <summary>
        /// tests that this class implements the INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            RoundRegister.CashDrawer.Reset();
            CashDrawerViewModel thing = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(thing);
        }

        /// <summary>
        /// Makes sure changing the amount in the draweer notifies a property change
        /// </summary>
        /// <param name="amount">the amount changing</param>
        /// <param name="propertyName">the name of the property changing</param>
        [Theory]
        [InlineData(30, "PenniesInDrawer")]
        [InlineData(30, "DimesInDrawer")]
        [InlineData(30, "QuartersInDrawer")]
        [InlineData(30, "NicklesInDrawer")]
        [InlineData(30, "FivesInDrawer")]
        [InlineData(30, "OnesInDrawer")]
        [InlineData(30, "TensInDrawer")]
        [InlineData(30, "TwentiesInDrawer")]
        public void ChangingDrawerShouldNotifyOfPropertyChanges(uint amount, string propertyName)
        {
            RoundRegister.CashDrawer.Reset();
            CashDrawerViewModel c = new();
            Assert.PropertyChanged(c, propertyName, () => {
                var type = c.GetType();
                var property = type.GetProperty(propertyName);
                property?.SetValue(c, amount);
            });
        }

        /// <summary>
        /// Makes sure changing the money from the customer notifies a property change
        /// </summary>
        /// <param name="amount">the amount changing</param>
        /// <param name="propertyName">the name of the property changing</param>

        [Theory]
        [InlineData(1,"PenniesFromCustomer")]
        [InlineData(1, "DimesFromCustomer")]
        [InlineData(1, "QuartersFromCustomer")]
        [InlineData(1,"NicklesFromCustomer")]
        [InlineData(1,"FivesFromCustomer")]
        [InlineData(1,"OnesFromCustomer")]
        [InlineData(1, "TensFromCustomer")]
        [InlineData(1, "TwentiesFromTheCustomer")]
        public void ChangingCustomerPaidShouldNotifyOfPropertyChanges(uint amount, string propertyName)
        {
            RoundRegister.CashDrawer.Reset();
            CashDrawerViewModel c = new() { Total = 10 };
            Assert.PropertyChanged(c, propertyName, () => {
                var type = c.GetType();
                var property = type.GetProperty(propertyName);
                property?.SetValue(c, amount);
            });
        }

        /// <summary>
        /// Makes sure changing the amount in the draweer notifies a property change
        /// </summary>
        /// <param name="amount">the amount changing</param>
        /// <param name="propertyName">the name of the property changing</param>
        [Theory]
        [InlineData(30, "PenniesChange")]
        [InlineData(30, "DimesChange")]
        [InlineData(30, "QuartersChange")]
        [InlineData(30, "NicklesChange")]
        [InlineData(30, "FivesChange")]
        [InlineData(30, "OnesChange")]
        [InlineData(30, "TensChange")]
        [InlineData(30, "TwentiesChange")]
        public void ChangingChangeForCustomerShouldNotifyOfPropertyChanges(uint amount, string propertyName)
        {
            RoundRegister.CashDrawer.Reset();
            CashDrawerViewModel c = new();
            Assert.PropertyChanged(c, propertyName, () => {
                var type = c.GetType();
                var property = type.GetProperty(propertyName);
                property?.SetValue(c, amount);
            });
        }

        /// <summary>
        /// Total can be set properly
        /// </summary>
        /// <param name="amount">the amout of total</param>
        [Theory]
        [InlineData(10)]
        [InlineData(30)]
        [InlineData(1.01)]
        [InlineData(100)]
        [InlineData(19)]
        [InlineData(2.06)]
        public void TotalShouldBeAbleToBeSet(decimal amount)
        {
            RoundRegister.CashDrawer.Reset();
            CashDrawerViewModel c = new() { Total = amount};
            Assert.Equal(c.Total, amount);
        }

        /// <summary>
        /// Change owed can be set properly
        /// </summary>
        [Fact]
        public void ChangeOwedIsCorrectlyCalculating() 
        {
            RoundRegister.CashDrawer.Reset();
            CashDrawerViewModel c = new();
            c.OnesFromCustomer = 3;
            c.NicklesFromCustomer = 2;
            c.Total = 3;
            Assert.Equal(0.10m, c.ChangeOwed);
        }

        /// <summary>
        /// Tests if the negative amount due is set properly
        /// </summary>
        [Fact]
        public void NegativeAmountDueCorrectlyCalculating()
        {
            RoundRegister.CashDrawer.Reset();
            CashDrawerViewModel c = new();
            c.OnesFromCustomer = 3;
            c.NicklesFromCustomer = 2;
            c.Total = 3;
            Assert.Equal(-0.10m, c.NegativeAmountDue);
        }

        /// <summary>
        /// Tests if the amount due is set properly
        /// </summary>
        [Fact]
        public void AmountDueCorrectlyCalculating()
        {
            RoundRegister.CashDrawer.Reset();
            CashDrawerViewModel c = new();
            c.OnesFromCustomer = 3;
            c.NicklesFromCustomer = 2;
            c.Total = 4;
            Assert.Equal(0.9m, c.AmountDue);
        }

        /// <summary>
        /// tests that the change and drawer is correct when transaction is finalized
        /// </summary>
        [Fact]
        public void TransactionTestChangeZero()
        {
            RoundRegister.CashDrawer.Reset();
            decimal total = 36.5m;
            CashDrawerViewModel c = new() { Total = total};
            uint twenties = 4;
            uint tens = 10;
            uint fives = 8;
            uint ones = 20;
            uint quarters = 80;
            uint dimes = 100;
            uint nickles = 80;
            uint pennies = 100;
            c.TwentiesFromTheCustomer = 1;
            c.TensFromCustomer = 1;
            c.FivesFromCustomer = 1;
            c.OnesFromCustomer = 1;
            c.NicklesFromCustomer = 1;
            c.QuartersFromCustomer = 1;
            c.DimesFromCustomer = 1;
            c.PenniesFromCustomer = 1;
            Assert.Equal(0, c.ChangeOwed);
            c.FinalizeTransaction();
            Assert.Equal(twenties + 1, c.TwentiesInDrawer);
            Assert.Equal(tens + 1, c.TensInDrawer);
            Assert.Equal(fives + 1, c.FivesInDrawer);
            Assert.Equal(ones + 1, c.OnesInDrawer);
            Assert.Equal(quarters + 1, c.QuartersInDrawer);
            Assert.Equal(dimes + 1, c.DimesInDrawer);
            Assert.Equal(nickles + 1, c.NicklesInDrawer);
            Assert.Equal(pennies + 1, c.PenniesInDrawer);
        }

        /// <summary>
        /// tests that the change and drawer is correct when transaction is finalized
        /// </summary>
        [Fact]
        public void TransactionTestChangeDue()
        {
            RoundRegister.CashDrawer.Reset();
            decimal total = 10;
            CashDrawerViewModel c = new() { Total = total };
            var temp = c.TwentiesInDrawer;
            var tempten = c.TensInDrawer;
            c.TwentiesFromTheCustomer = 1;
            Assert.Equal(10, c.ChangeOwed);
            c.FinalizeTransaction();
            Assert.Equal(temp+1, c.TwentiesInDrawer);
            Assert.Equal(tempten - 1, c.TensInDrawer);
        }
    }
}
