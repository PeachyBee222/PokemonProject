using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProject.Data
{
    /// <summary>
    /// A class representing drinks 
    /// </summary>
    public abstract class Drink : IMenuItem, INotifyPropertyChanged
    {

        /// <summary>
        /// Represents the name of the drink
        /// </summary>
        /// <returns>The name of the drink</returns>
        public abstract string Name { get; }

        /// <summary>
        /// Represents the description of the drink
        /// </summary>
        /// <returns>The description of the drink</returns>
        public abstract string Description { get; }

        /// <summary>
        /// Represents the calories of the drink
        /// </summary>
        /// <returns>the calories of the drink</returns>
        public abstract uint Calories { get; }

        /// <summary>
        /// Represents the price of the drink
        /// </summary>
        /// <returns>the price of the drink</returns>
        public abstract decimal Price { get; }

        /// <summary>
        /// Represents the special instructions of the drink
        /// </summary>
        /// <returns>the special instructions for the drink</returns>
        public abstract IEnumerable<string> SpecialInstructions { get; }

        /// <summary>
        /// represents the size of the drink
        /// </summary>
        /// <returns>the size of the drink</returns>
        public abstract ServingSize Size { get; set; }


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
