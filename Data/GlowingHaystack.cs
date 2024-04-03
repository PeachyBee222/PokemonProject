using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProject.Data
{
    /// <summary>
    /// The details for the glowing harstack side dish
    /// </summary>
    public class GlowingHaystack : Side, IMenuItem
    {
        /// <summary>
        /// The name of the Glowing Haystack instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Glowing Haystack";

        /// <summary>
        /// The description of the GlowingHaystack instance
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description => "Hash browns smothered in green chile sauce, sour cream, and topped with tomatoes.";
        /// <summary>
        /// Private backing field for sour cream
        /// </summary>
        private bool _sourCream = true;
        /// <summary>
        /// If the Glowing Haystack instance is served with sour cream
        /// </summary>
        /// <remarks>
        /// Here we have an autoproperty with both getter and setter, 
        /// and a default value
        /// </remarks>
        public bool SourCream
        {
            get
            {
                return _sourCream;
            }
            set
            {
                _sourCream = value;
                OnPropertyChanged("SourCream");
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }
        /// <summary>
        /// private backing field for green chile sauce
        /// </summary>
        private bool _greenChileSauce = true;
        /// <summary>
        /// If the Glowing Haystack instance is served with green chile sauce
        /// </summary>
        /// <remarks>
        /// Here we have an autoproperty with both getter and setter, 
        /// and a default value
        /// </remarks>
        public bool GreenChileSauce
        {
            get
            {
                return _greenChileSauce;
            }
            set
            {
                _greenChileSauce = value;
                OnPropertyChanged("GreenChileSauce");
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }
        /// <summary>
        /// private backing field for tomatoes
        /// </summary>
        private bool _tomatoes = true;
        /// <summary>
        /// If the Glowing Haystack instance is served with tomatoes
        /// </summary>
        /// <remarks>
        /// Here we have an autoproperty with both getter and setter, 
        /// and a default value
        /// </remarks>
        public bool Tomatoes
        {
            get
            {
                return _tomatoes;
            }
            set
            {
                _tomatoes = value;
                OnPropertyChanged("Tomatoes");
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// The price of the GlowingHaystack instance
        /// </summary>
        public override decimal Price { get; } = 2.00m;

        /// <summary>
        /// The calories of the GlowingHaystack instance
        /// </summary>
        /// <remarks>
        /// This is a get-only property whose value is derived from the other properties of the class.
        /// </remarks>
        public override uint Calories
        {
            get
            {
                uint calories = 470u;
                if (GreenChileSauce) calories += 15u;
                if (SourCream) calories += 23;
                if (Tomatoes) calories += 22;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this Glowing Haystack
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!GreenChileSauce) instructions.Add("Hold Green Chile Sauce");
                if (!SourCream) instructions.Add("Hold Sour Cream");
                if (!Tomatoes) instructions.Add("Hold Tomatoes");
                return instructions;
            }
        }
    }
}
