using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProject.Data
{
    /// <summary>
    /// The instance of the inorganic substance drink
    /// </summary>
    public class InorganicSubstance : Drink, IMenuItem
    {
        /// <summary>
        /// The name of the drink
        /// </summary>
        public override string Name { get; } = "Inorganic Substance";

        /// <summary>
        /// The description of the inorganic substance drink
        /// </summary>
        public override string Description { get; } = "A cold glass of ice water.";
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
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }
        /// <summary>
        /// private backing field to ice
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
                return 0m;
            }
        }

        /// <summary>
        /// The calories for this instance of the drink
        /// </summary>
        public override uint Calories
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this inorganic substance
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!Ice) instructions.Add($"No Ice");
                if(Size != ServingSize.Small)instructions.Add(Size.ToString());
                return instructions;
            }
        }
    }
}
