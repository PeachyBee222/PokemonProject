using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProject.Data
{
    /// <summary>
    /// Specfies the details for the Outer Omelette dish
    /// </summary>
    public class OuterOmelette : Entree, IMenuItem
    {
        /// <summary>
        /// The name of the OuterOmlette instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Outer Omlette";

        /// <summary>
        /// The description of the OutterOmlet instance
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description => "A fully loaded Omelette.";
        /// <summary>
        /// private backing field
        /// </summary>
        private bool _cheddarCheese = true;
        /// <summary>
        /// If the Outer Omlette instance is served with cheddar cheese
        /// </summary>
        /// <remarks>
        /// Here we have an autoproperty with both getter and setter, 
        /// and a default value
        /// </remarks>
        public bool CheddarCheese
        {
            get
            {
                return _cheddarCheese;
            }
            set
            {
                _cheddarCheese = value;
                OnPropertyChanged("CheddarCheese");
                OnPropertyChanged(nameof(SpecialInstructions));
                OnPropertyChanged(nameof(Calories));

            }
        }
        /// <summary>
        /// private backing field for peppers
        /// </summary>
        private bool _peppers = true;
        /// <summary>
        /// If the Outer Omlette instance is served with peppers
        /// </summary>
        /// <remarks>
        /// Here we have an autoproperty with both getter and setter, 
        /// and a default value
        /// </remarks>
        public bool Peppers
        {
            get
            {
                return _peppers;
            }
            set
            {
                _peppers = value;
                OnPropertyChanged("Peppers");
                OnPropertyChanged(nameof(SpecialInstructions));
                OnPropertyChanged(nameof(Calories));

            }
        }
        /// <summary>
        /// private backing field for mushrooms
        /// </summary>
        private bool _mushrooms = true;
        /// <summary>
        /// If the Outer Omlette instance is served with mushrooms
        /// </summary>
        /// <remarks>
        /// Here we have an autoproperty with both getter and setter, 
        /// and a default value
        /// </remarks>
        public bool Mushrooms
        {
            get
            {
                return _mushrooms;
            }
            set
            {
                _mushrooms = value;
                OnPropertyChanged("Mushrooms");
                OnPropertyChanged(nameof(SpecialInstructions));
                OnPropertyChanged(nameof(Calories));
            }
        }
        /// <summary>
        /// private backing field for tomatoes
        /// </summary>
        private bool _tomatoes = true;
        /// <summary>
        /// If the Outer Omlette instance is served with tomatoes
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
                OnPropertyChanged(nameof(SpecialInstructions));
                OnPropertyChanged(nameof(Calories));
            }
        }
        /// <summary>
        /// Private backing field for onions
        /// </summary>
        private bool _onions = true;
        /// <summary>
        /// If the Outer Omlette instance is served with onions
        /// </summary>
        /// <remarks>
        /// Here we have an autoproperty with both getter and setter, 
        /// and a default value
        /// </remarks>
        public bool Onions
        {
            get
            {
                return _onions;
            }
            set
            {
                _onions = value;
                OnPropertyChanged("Onions");
                OnPropertyChanged(nameof(SpecialInstructions));
                OnPropertyChanged(nameof(Calories));
            }
        }


        /// <summary>
        /// The price of the OuterOmlette instance
        /// </summary>
        public override decimal Price { get; } = 7.45m;

        /// <summary>
        /// The calories of the Outer Omlette instance
        /// </summary>
        /// <remarks>
        /// This is a get-only property whose value is derived from the other properties of the class.
        /// </remarks>
        public override uint Calories
        {
            get
            {
                uint calories = 94u;
                if (CheddarCheese) calories += 113u; //fixme, had to update this, need to check test cases
                if (Peppers) calories += 24u;
                if (Mushrooms) calories += 4;
                if (Tomatoes) calories += 22;
                if (Onions) calories += 22;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this Outer Omlette
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!CheddarCheese) instructions.Add("Hold Cheddar Cheese");
                if (!Peppers) instructions.Add("Hold Peppers");
                if (!Mushrooms) instructions.Add("Hold Mushrooms");
                if (!Tomatoes) instructions.Add("Hold Tomatoes");
                if (!Onions) instructions.Add("Hold Onions");
                return instructions;
            }
        }
    }
}
