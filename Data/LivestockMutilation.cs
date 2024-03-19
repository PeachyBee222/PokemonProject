using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Details for the dish Livestock Mutilation
    /// </summary>
    public class LivestockMutilation : Entree, IMenuItem
    {
        /// <summary>
        /// The name of the LivestockMutilation instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Livestock Mutilation";

        /// <summary>
        /// The description of the Livestock Mutilation instance
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description => "A hearty serving of biscuits, smothered in sausage-laden gravy.";

        /// <summary>
        /// The private backing field for the Biscuits property
        /// </summary>
        private uint _biscuits = 3;

        /// <summary>
        /// The number of biscuits in this instance of a Livestock Mutilation
        /// </summary>
        /// <remarks>
        /// Note the set limits the stack size to a maximum of 8 biscuits 
        /// </remarks>
        public uint Biscuits
        {
            get
            {
                return _biscuits;
            }
            set
            {
                if (value <= 8)
                {
                    _biscuits = value;
                }
                else
                {
                    _biscuits = 8;
                }
                OnPropertyChanged("Biscuits");
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }
        /// <summary>
        /// private backing field for gravy
        /// </summary>
        private bool _gravy = true;
        /// <summary>
        /// If the Livestock Mutilation instance is served with maple syrup
        /// </summary>
        /// <remarks>
        /// Here we have an autoproperty with both getter and setter, 
        /// and a default value
        /// </remarks>
        public bool Gravy
        {
            get
            {
                return _gravy;
            }
            set
            {
                _gravy = value;
                OnPropertyChanged("Gravy");
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// The price of the Livestock Mutilation instance
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal basePrice = 7.25m;
                if (_biscuits > 3)
                {
                    basePrice += 1.00m * (_biscuits - 3);
                }
                return basePrice;
            }
        }

        /// <summary>
        /// The calories of the Livestock Mutilation instance
        /// </summary>
        /// <remarks>
        /// This is a get-only property whose value is derived from the other properties of the class.
        /// </remarks>
        public override uint Calories
        {
            get
            {
                uint calories = 49u * Biscuits;
                if (Gravy) calories += 140u;
                return calories;
            }
        }
        /// <summary>
        /// Special instructions for the preparation of this Livestock Mutilation
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (Biscuits != 3) instructions.Add($"{Biscuits} biscuits");
                if (!Gravy) instructions.Add("Hold Gravy");
                return instructions;
            }
        }
    }
}
