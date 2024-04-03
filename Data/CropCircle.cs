using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProject.Data
{
    /// <summary>
    /// The discription for the crop circle side entree
    /// </summary>
    public class CropCircle : Side, IMenuItem
    {
        /// <summary>
        /// The name of the CropCircle instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Crop Circle";

        /// <summary>
        /// The description of the CropCircle instance
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description => "Oatmeal topped with mixed berries.";
        /// <summary>
        /// private backing field for berries
        /// </summary>
        private bool _berries = true;
        /// <summary>
        /// If the Crop Circle instance is served with Berries
        /// </summary>
        /// <remarks>
        /// Here we have an autoproperty with both getter and setter, 
        /// and a default value
        /// </remarks>
        public bool Berries
        {
            get
            {
                return _berries;
            }
            set
            {
                _berries = value;
                OnPropertyChanged("Berries");
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// The price of the CropCircle instance
        /// </summary>
        public override decimal Price { get; } = 2.00m;

        /// <summary>
        /// The calories of the Crop Circle instance
        /// </summary>
        /// <remarks>
        /// This is a get-only property whose value is derived from the other properties of the class.
        /// </remarks>
        public override uint Calories
        {
            get
            {
                uint calories = 158u;
                if (Berries) calories += 89u;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this Crop Circle
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!Berries) instructions.Add("Hold Berries");
                return instructions;
            }
        }
    }
}
