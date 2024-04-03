using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProject.Data
{
    /// <summary>
    /// Class representing properties of all menu items
    /// </summary>
    public interface IMenuItem
    {
        /// <summary>
        /// The name of this menu item
        /// </summary>
        string Name { get; }

        /// <summary>
        /// the description of this menu item
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The price of this menu item
        /// </summary>
        decimal Price { get; }

        /// <summary>
        /// the calories of this menu item
        /// </summary>
        uint Calories { get; }

        /// <summary>
        /// The special instructions of this menu item
        /// </summary>
        IEnumerable<string> SpecialInstructions { get; }

        /// <summary>
        /// calls the event for a property change
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
