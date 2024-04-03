using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProject.Data
{
    /// <summary>
    /// The details for the EvisceratedEggs side dish
    /// </summary>
    public class EvisceratedEggs : Side , IMenuItem
    {
        /// <summary>
        /// The name of the EvisceratedEggs instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Eviscerated Eggs";

        /// <summary>
        /// The description of the EvisceratedEggs instance
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description => "Eggs prepared the way you like.";

        /// <summary>
        /// Private backing variable for style
        /// </summary>
        private EggStyle _style = EggStyle.OverEasy;
        /// <summary>
        /// The way the eggs should be cooked
        /// </summary>
        public EggStyle Style
        {
            get
            {
                return _style;
            }
            set
            {
                _style = value;
                OnPropertyChanged("Style");
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// The private backing field for the Count property
        /// </summary>
        private uint _count = 2;

        /// <summary>
        /// The number of eggs in this instance of a Eviscerated Eggs
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
                else if(value > 6)
                {
                    _count = 6;
                }
                else
                {
                    _count = 1;
                }
                OnPropertyChanged("Count");
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// The price of the EvisceratedEggs instance
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal basePrice = 1.00m * _count;
                return basePrice;
            }
        }

        /// <summary>
        /// The calories of the EvisceratedEggs instance
        /// </summary>
        /// <remarks>
        /// This is a get-only property whose value is derived from the other properties of the class.
        /// </remarks>
        public override uint Calories
        {
            get
            {
                uint calories = 78u * _count;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this EvisceratedEggs
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if(Style == EggStyle.SoftBoiled) instructions.Add($"Soft Boiled");
                if (Style == EggStyle.Hardboiled) instructions.Add($"Hard Boiled");
                if (Style == EggStyle.OverEasy) instructions.Add($"Over Easy");
                if (Style == EggStyle.SunnySideUp) instructions.Add($"Sunny Side Up");
                if(Style == EggStyle.Scrambled) instructions.Add($"{Style}");
                if(Style == EggStyle.Poached) instructions.Add($"{Style}");
                if (Count != 2) instructions.Add($"{Count} eggs");
                return instructions;
            }
        }
    }
}
