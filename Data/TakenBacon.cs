using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProject.Data
{
    /// <summary>
    /// The description for the TakenBacon side dish
    /// </summary>
    public class TakenBacon : Side, IMenuItem
    {
        /// <summary>
        /// The name of the TakenBacon instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Taken Bacon";

        /// <summary>
        /// The description of the TakenBacon instance
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description => "Crispy strips of bacon.";

        /// <summary>
        /// The private backing field for the Count property
        /// </summary>
        private uint _count = 2;

        /// <summary>
        /// The number of bacon strips in this instance of a Taken Bacon, must be between 1 and 6
        /// </summary>
        public uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value <= 6 && value > 0)
                {
                    _count = value;
                }
                else if(value < 1)
                {
                    _count = 1;
                }
                else
                {
                    _count = 6;
                }
                OnPropertyChanged("Count");
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// The price of the TakenBacon instance
        /// </summary>
        public override decimal Price {
            get
            {
                decimal basePrice = 1.00m * _count;
                return basePrice;
            }
        }

        /// <summary>
        /// The calories of the TakenBacon instance
        /// </summary>
        /// <remarks>
        /// This is a get-only property whose value is derived from the other properties of the class.
        /// </remarks>
        public override uint Calories
        {
            get
            {
                uint calories = 43u * _count;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this Taken Bacon
        /// </summary>
        public override  IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (Count != 2) instructions.Add($"{Count} strips");
                return instructions;
            }
        }
    }
}
