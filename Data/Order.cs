using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProject.Data
{
    /// <summary>
    /// Represents an order of drinks, entrees, sides.
    /// </summary>
    public class Order : ICollection<IMenuItem>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        /// <summary>
        /// holds all items in the order
        /// </summary>
        private List<IMenuItem> _order = new List<IMenuItem>();

        /// <summary>
        /// Indicates a collection in this class has changed
        /// </summary>
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        /// <summary>
        /// Indivates a property in this class has been changed
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The number of items in the order
        /// </summary>
        public int Count => _order.Count;

        /// <summary>
        /// The price of all items in the order
        /// </summary>
        public decimal Subtotal
        {
            get
            {
                decimal price = 0;
                foreach (IMenuItem item in _order)
                {
                    price += item.Price;
                }
                return price;
            }
        }

        /// <summary>
        /// Private backing field for tax rate
        /// </summary>
        private decimal _taxRate = .15m;

        /// <summary>
        /// Represents the sales tax rate
        /// </summary>
        public decimal TaxRate 
        {
            get
            {
                return _taxRate;
            }
            set
            {
                _taxRate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TaxRate"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
            }
        }

        /// <summary>
        /// calculates and returns the price of the taxes
        /// </summary>
        public decimal Tax => Subtotal * TaxRate;

        /// <summary>
        /// The total cost of the order.
        /// </summary>
        public decimal Total => Subtotal + Tax;

        /// <summary>
        /// Private backing field for getting the next Number to be used
        /// </summary>
        private static int _nextNumber = 1;

        /// <summary>
        /// The order number, once set cannot be changed
        /// </summary>
        public int Number
        {
            get; init;
        }

        /// <summary>
        /// The date and time the order was placed
        /// </summary>
        public DateTime PlacedAt { get; init; }

        /// <summary>
        /// Constructor for the order class
        /// </summary>
        public Order()
        {
            PlacedAt = DateTime.Now;
            Number = _nextNumber;
            _nextNumber++;
        }

        #region ICollectionMethods

        /// <summary>
        /// This array is not read only because it is being modified
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Adds an menu item to the order
        /// </summary>
        /// <param name="item">the desired item to add to the order</param>
        public void Add(IMenuItem item)
        {
            _order.Add(item);

            item.PropertyChanged += HandleItemPropertyChanged;

            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
        }

        /// <summary>
        /// Clears the order
        /// </summary>
        public void Clear()
        {
            _order.Clear();

            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));

        }

        /// <summary>
        /// Checks if the order has the specified menu item in it
        /// </summary>
        /// <param name="item">the item to see if it is already in the order</param>
        /// <returns>true if the item is in the list</returns>
        public bool Contains(IMenuItem item)
        {
            return _order.Contains(item);
        }

        /// <summary>
        /// Copies the given list into the private array
        /// </summary>
        /// <param name="array">The array to copu</param>
        /// <param name="arrayIndex">the index to start at</param>
        public void CopyTo(IMenuItem[] array, int arrayIndex)
        {
            _order.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Object that enumerates the items in the list
        /// </summary>
        /// <returns>object that allows you to move through items in the list</returns>
        public IEnumerator<IMenuItem> GetEnumerator()
        {
            return _order.GetEnumerator();
        }

        /// <summary>
        /// Removes the given item from the order
        /// </summary>
        /// <param name="item">the desired item to remove</param>
        /// <returns>true if the item is removed</returns>
        public bool Remove(IMenuItem item)
        {
            int index = _order.IndexOf(item);
            if (index == -1) return false; //item is not in the list

            _order.Remove(item);

            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, index));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));

            item.PropertyChanged -= HandleItemPropertyChanged;

            return true;

        }

        /// <summary>
        /// Object that enumerates the items in the list
        /// </summary>
        /// <returns>object that allows you to move through items in the list</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _order.GetEnumerator();
        }

        #endregion

        /// <summary>
        /// Event listener for when the property of an item changes
        /// </summary>
        /// <param name="sender">where the message originated</param>
        /// <param name="e">the event that caused the change</param>
        private void HandleItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Price")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
            }
            if(e.PropertyName == "TaxRate")
            {
                // change property later milestone
            }
        }


    }
}