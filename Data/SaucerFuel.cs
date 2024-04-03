using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PokemonProject.Data
{
    /// <summary>
    /// The instance of the Saurcer Fuel drink
    /// </summary>
    public class SaucerFuel : Drink, IMenuItem
    {
        /// <summary>
        /// The name of the drink
        /// </summary>
        public override string Name
        {
            get
            {
                if (!Decaf)
                {
                    return "Saucer Fuel";
                }
                else
                {
                    return "Decaf Saucer Fuel";
                }
            }
        }

        /// <summary>
        /// The description of the saucer fuel drink
        /// </summary>
        public override string Description { get; } = "A steaming cup of coffee.";
        /// <summary>
        /// Private backing field for size
        /// </summary>
        private ServingSize _size = ServingSize.Small;
        /// <summary>
        /// The size of the drink, defaults to small
        /// </summary>
        public override ServingSize Size {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                OnPropertyChanged("Size");
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(SpecialInstructions));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// Private backing field for decaf
        /// </summary>
        private bool _decaf = false;

        /// <summary>
        /// If this drink should be served decaf, defaults to false
        /// </summary>
        public bool Decaf 
        {
            get
            {
                return _decaf;
            }
            set
            {
                _decaf = value;
                OnPropertyChanged("Decaf");
                OnPropertyChanged(nameof(Name));
            }
        }
        
        /// <summary>
        /// private backing variable for cream
        /// </summary>
        private bool _cream = false;

        /// <summary>
        /// If this drink should be served with Cream, defaults to false
        /// </summary>
        public bool Cream {
            get
            {
                return _cream;
            }
            set
            {
                _cream = value;
                OnPropertyChanged("Cream");
                OnPropertyChanged(nameof(Calories));
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
                    if (Cream) return 1 + 29;
                    return 1;
                }
                else if (Size == ServingSize.Medium)
                {
                    if (Cream) return 2 + 29;
                    return 2;
                }
                else
                {
                    if (Cream) return 3 + 29;
                    return 3;
                }
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this Saucer Fuel
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (Cream) instructions.Add($"With Cream");
                if (Size != ServingSize.Small) instructions.Add(Size.ToString());
                return instructions;
            }
        }
    }
}
