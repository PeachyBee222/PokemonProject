using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// The description for the MissingLinks side dish
    /// </summary>
    public class MissingLinks : Side, IMenuItem
    {
        /// <summary>
        /// The name of the MissingLinks instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Missing Links";

        /// <summary>
        /// The description of the MissingLinks instance
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description => "Sizzling pork sausage links.";

        /// <summary>
        /// The private backing field for the Count property
        /// </summary>
        private uint _count = 2;

        /// <summary>
        /// The number of sausage links in this instance of a Missing Links
        /// </summary>
        public uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value <= 8 && value > 0)
                {
                    _count = value;
                }
                else if (value >8)
                {
                    _count = 8;
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
        /// The price of the MissingLinks instance
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
        /// The calories of the Missing Links instance
        /// </summary>
        /// <remarks>
        /// This is a get-only property whose value is derived from the other properties of the class.
        /// </remarks>
        public override uint Calories
        {
            get
            {
                uint calories = 391u * _count;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this MissingLinks
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (Count != 2) instructions.Add($"{Count} links");
                return instructions;
            }
        }
    }
}
