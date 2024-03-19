using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    public static class Menu
    {
        /// <summary>
        /// has instances of all avalible entrees in their default settings
        /// </summary>
        public static IEnumerable<IMenuItem> Entrees
        {
            get
            {
                List<IMenuItem> list = new List<IMenuItem>();
                list.Add(new CrashedSaucer());
                list.Add(new FlyingSaucer());
                list.Add(new LivestockMutilation());
                list.Add(new OuterOmelette());
                return list;
            }
        }
        /// <summary>
        /// has an instance of all avalible sides
        /// </summary>
        public static IEnumerable<IMenuItem> Sides
        {
            get
            {
                List<IMenuItem> list = new List<IMenuItem>();
                list.Add(new CropCircle());
                list.Add(new EvisceratedEggs());
                list.Add(new GlowingHaystack());
                list.Add(new MissingLinks());
                list.Add(new TakenBacon());
                list.Add(new YouAreToast());
                return list;
            }
        }
        /// <summary>
        /// contains an instance of all avalible drinks in all of the different sizes
        /// </summary>
        public static IEnumerable<IMenuItem> Drinks
        {
            get
            {
                List<IMenuItem> list = new List<IMenuItem>();
                list.Add(new InorganicSubstance() { Size = ServingSize.Small});
                list.Add(new LiquifiedVegetation() { Size = ServingSize.Small });
                list.Add(new SaucerFuel() { Size = ServingSize.Small });
                return list;
            }
        }
        /// <summary>
        /// all of the avalible items on the menu.
        /// </summary>
        public static IEnumerable<IMenuItem> FullMenu
        {
            get
            {
                List<IMenuItem> list = new List<IMenuItem>();
                list.Add(new InorganicSubstance() { Size = ServingSize.Small });
                list.Add(new LiquifiedVegetation() { Size = ServingSize.Small });
                list.Add(new SaucerFuel() { Size = ServingSize.Small });
                list.Add(new CropCircle());
                list.Add(new EvisceratedEggs());
                list.Add(new GlowingHaystack());
                list.Add(new MissingLinks());
                list.Add(new TakenBacon());
                list.Add(new YouAreToast());
                list.Add(new CrashedSaucer());
                list.Add(new FlyingSaucer());
                list.Add(new LivestockMutilation());
                list.Add(new OuterOmelette());
                return list;
            }
        }

    }
}
