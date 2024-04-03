using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProject.Data
{
    /// <summary>
    /// The instance of the Liquified Vegitation drink
    /// </summary>
    public class LiquifiedVegetation : Drink, IMenuItem
    {
        /// <summary>
        /// The name of the drink
        /// </summary>
        public override string Name{ get; } = "Liquified Vegetation";

        /// <summary>
        /// The description of the liquidied vegetation drink
        /// </summary>
        public override string Description { get; } = "A cold glass of blended vegetable juice.";

        /// <summary>
        /// Private backing field for size
        /// </summary>
        private ServingSize _size = ServingSize.Small;

        /// <summary>
        /// The size of the drink, defaults to small
        /// </summary>
        public override ServingSize Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                OnPropertyChanged("Size");
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }
        /// <summary>
        /// Private backing variable for ice
        /// </summary>
        private bool _ice = true;

        /// <summary>
        /// If this drink should be served with ice, defaults to true
        /// </summary>
        public bool Ice
        {
            get
            {
                return _ice;
            }
            set
            {
                _ice = value;
                OnPropertyChanged("Ice");
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// The price of the drink which depends on the specified size
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (Size == ServingSize.Small)
                {
                    return 1.00m;
                }
                else if (Size == ServingSize.Medium)
                {
                    return 1.50m;
                }
                else
                {
                    return 2.00m;
                }
            }
        }

        /// <summary>
        /// The calories for this instance of the drink
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (Size == ServingSize.Small)
                {
                    return 72;
                }
                else if (Size == ServingSize.Medium)
                {
                    return 144;
                }
                else
                {
                    return 216;
                }
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this Liquified Vegitation
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!Ice) instructions.Add($"No Ice");
                if (Size != ServingSize.Small) instructions.Add(Size.ToString());
                return instructions;
            }
        }
    }
}
