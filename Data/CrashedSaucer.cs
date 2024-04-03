using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProject.Data
{
    /// <summary>
    /// Details for the dish Crashed Saucer
    /// </summary>
    public class CrashedSaucer : Entree, IMenuItem
    {
        /// <summary>
        /// The name of the CrashedSaucer instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Crashed Saucer";

        /// <summary>
        /// The description of the CrashedSaucer instance
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description => "A stack of crispy french toast smothered in syrup and topped with a pat of butter.";

        /// <summary>
        /// The private backing field for the StackSize property
        /// </summary>
        private uint _stackSize = 2;

        /// <summary>
        /// The number of french toast in this instance of a Crashed Saucer
        /// </summary>
        /// <remarks>
        /// Note the set limits the stack size to a maximum of 6 french toast
        /// </remarks>
        public uint StackSize
        {
            get
            {
                return _stackSize;
            }
            set
            {
                if (value <= 6)
                {
                    _stackSize = value;
                }
                else
                {
                    _stackSize = 6;
                }
                OnPropertyChanged("StackSize");
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }
        /// <summary>
        /// private backing variable for syrup
        /// </summary>
        private bool _syrup = true;
        /// <summary>
        /// If the Crashed Saucer instance is served with maple syrup
        /// </summary>
        /// <remarks>
        /// Here we have an autoproperty with both getter and setter, 
        /// and a default value
        /// </remarks>
        public bool Syrup
        {
            get
            {
                return _syrup;
            }
            set
            {
                _syrup = value;
                OnPropertyChanged("Syrup");
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }
        /// <summary>
        /// private backing field for syrup
        /// </summary>
        private bool _butter = true;
        /// <summary>
        /// If the Crashed Saucer instance is served with butter
        /// </summary>
        /// <remarks>
        /// Here we have an autoproperty with both getter and setter, 
        /// and a default value
        /// </remarks>
        public bool Butter
        {
            get
            {
                return _butter;
            }
            set
            {
                _butter = value;
                OnPropertyChanged("Butter");
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// The price of the Crashed Saucer instance
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal basePrice = 6.45m;
                if (_stackSize > 2)
                {
                    basePrice += 1.50m * (_stackSize - 2);
                }
                return basePrice;
            }
        }

        /// <summary>
        /// The calories of the Crashed Saucer instance
        /// </summary>
        /// <remarks>
        /// This is a get-only property whose value is derived from the other properties of the class.
        /// </remarks>
        public override uint Calories
        {
            get
            {
                uint calories = 149u * StackSize;
                if (Syrup) calories += 52u;
                if (Butter) calories += 35u;
                return calories;
            }
        }
        /// <summary>
        /// Special instructions for the preparation of this Crashed Saucer
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (StackSize != 2) instructions.Add($"{StackSize} Slices");
                if (!Butter) instructions.Add("Hold Butter");
                if (!Syrup) instructions.Add("Hold Syrup");
                return instructions;
            }
        }
    }
}
