using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// The class representing the entrees
    /// </summary>
    public abstract class Entree : IMenuItem, INotifyPropertyChanged
    {
        /// <summary>
        /// Represents the name of the entree
        /// </summary>
        /// <returns></returns>
        public abstract string Name { get; }

        /// <summary>
        /// Represents the description of the entree
        /// </summary>
        /// <returns></returns>
        public abstract string Description { get; }

        /// <summary>
        /// Represents the calories of the entree
        /// </summary>
        /// <returns></returns>
        public abstract uint Calories { get; }

        /// <summary>
        /// Represents the price of the side
        /// </summary>
        /// <returns></returns>
        public abstract decimal Price { get; }

        /// <summary>
        /// Represents the special instructions of the entree
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<string> SpecialInstructions { get; }

        /// <summary>
        /// Property Changed event handler
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;


        /// <summary>
        /// Allows you to call a property changed event in the base classes
        /// </summary>
        /// <param name="propertyName">name of property changing</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        /// <summary>
        /// Returns the name of the item in this instance
        /// </summary>
        /// <returns>the name of the item</returns>
        public override string ToString()
        {
            return Name;
        }

    }
}
