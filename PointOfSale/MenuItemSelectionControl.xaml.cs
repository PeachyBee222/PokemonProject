using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheFlyingSaucer.Data;

namespace TheFlyingSaucer.PointOfSale
{
    /// <summary>
    /// Interaction logic for MenuItemSelectionControl.xaml
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {
        public MenuItemSelectionControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Returns the mainwindow
        /// </summary>
        public MainWindow MainWindowInstance
        {
            get
            {
                DependencyObject parent = this;
                do
                {
                    parent = LogicalTreeHelper.GetParent(parent);
                }
                while (!(parent is null || parent is MainWindow));
                return (MainWindow)parent;
            }
        }

        /// <summary>
        /// Handles the event of the flying saucer menu item being added/clicked
        /// </summary>
        /// <param name="sender">sender of this event</param>
        /// <param name="e">metadata for the event</param>
        void FlyingSaucerClick(object sender, RoutedEventArgs e)
        {
            IMenuItem item = new FlyingSaucer();

            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(item);
            }
            FlyingSaucerCustomization flyingSaucerCustomizations = new FlyingSaucerCustomization();
            flyingSaucerCustomizations.DataContext = item;
            MainWindowInstance.BackToMenu.IsEnabled = true;
            MainWindowInstance.Border.Child = flyingSaucerCustomizations;
        }

        /// <summary>
        /// Handles the event of the crashed saucer menu item being added/clicked
        /// </summary>
        /// <param name="sender">sender of this event</param>
        /// <param name="e">metadata for the event</param>
        private void CrashedSaucerClick(object sender, RoutedEventArgs e)
        {
            IMenuItem item = new CrashedSaucer();

            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(item);
            }

            CrashedSaucerCustomization saucerCustomization = new CrashedSaucerCustomization();
            saucerCustomization.DataContext = item;
            MainWindowInstance.BackToMenu.IsEnabled = true;
            MainWindowInstance.Border.Child = saucerCustomization;
            
        }

        /// <summary>
        /// Handles the event of the livestock mutilation menu item being added/clicked
        /// </summary>
        /// <param name="sender">sender of this event</param>
        /// <param name="e">metadata for the event</param>
        private void LivestockMutilationClick(object sender, RoutedEventArgs e)
        {
            IMenuItem item = new LivestockMutilation();

            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(item);
            }
            LivestockMutilationCustomization customization = new LivestockMutilationCustomization();
            customization.DataContext = item;
            MainWindowInstance.BackToMenu.IsEnabled = true;
            MainWindowInstance.Border.Child = customization;
    
        }

        /// <summary>
        /// Handles the event of the outer omelette menu item being added/clicked
        /// </summary>
        /// <param name="sender">sender of this event</param>
        /// <param name="e">metadata for the event</param>
        private void OuterOmeletteClick(object sender, RoutedEventArgs e)
        {
            IMenuItem item = new OuterOmelette();

            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(item);
            }
            OuterOmletteCustomization customization = new OuterOmletteCustomization();
            customization.DataContext = item;
            MainWindowInstance.BackToMenu.IsEnabled = true;
            MainWindowInstance.Border.Child = customization;

        }
        /// <summary>
        /// Handles the event of the crop circle menu item being added/clicked
        /// </summary>
        /// <param name="sender">sender of this event</param>
        /// <param name="e">metadata for the event</param>
        private void CropCircleClick(object sender, RoutedEventArgs e)
        {
            IMenuItem item = new CropCircle();

            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(item);
            }
            CropCircleCustomization customization = new CropCircleCustomization();
            customization.DataContext = item;
            MainWindowInstance.BackToMenu.IsEnabled = true;
            MainWindowInstance.Border.Child = customization;

        }
        /// <summary>
        /// Handles the event of the glowing haystack menu item being added/clicked
        /// </summary>
        /// <param name="sender">sender of this event</param>
        /// <param name="e">metadata for the event</param>
        private void GlowingHaystackClick(object sender, RoutedEventArgs e)
        {
            IMenuItem item = new GlowingHaystack();

            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(item);
            }

            GlowingHaystackCustomization customization = new GlowingHaystackCustomization();
            customization.DataContext = item;
            MainWindowInstance.BackToMenu.IsEnabled = true;
            MainWindowInstance.Border.Child = customization;

        }
        /// <summary>
        /// Handles the event of the eviscerated eggs menu item being added/clicked
        /// </summary>
        /// <param name="sender">sender of this event</param>
        /// <param name="e">metadata for the event</param>
        private void EvisceratedEggsClick(object sender, RoutedEventArgs e)
        {
            IMenuItem item = new EvisceratedEggs();

            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(item);
            }
            EvisceratedEggsCustomization customization = new EvisceratedEggsCustomization();
            customization.DataContext = item;
            MainWindowInstance.BackToMenu.IsEnabled = true;
            MainWindowInstance.Border.Child = customization;

        }
        /// <summary>
        /// Handles the event of the missing links menu item being added/clicked
        /// </summary>
        /// <param name="sender">sender of this event</param>
        /// <param name="e">metadata for the event</param>
        private void MissingLinksClick(object sender, RoutedEventArgs e)
        {
            IMenuItem item = new MissingLinks();

            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(item);
            }
            MissingLinksCustomization customization = new MissingLinksCustomization();
            customization.DataContext = item;
            MainWindowInstance.BackToMenu.IsEnabled = true;
            MainWindowInstance.Border.Child = customization;

        }
        /// <summary>
        /// Handles the event of the taken bacon menu item being added/clicked
        /// </summary>
        /// <param name="sender">sender of this event</param>
        /// <param name="e">metadata for the event</param>
        private void TakenBaconClick(object sender, RoutedEventArgs e)
        {
            IMenuItem item = new TakenBacon();

            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(item);
            }
            TakenBaconCustomization customization = new TakenBaconCustomization();
            customization.DataContext = item;
            MainWindowInstance.BackToMenu.IsEnabled = true;
            MainWindowInstance.Border.Child = customization;

        }
        /// <summary>
        /// Handles the event of the you're toast menu item being added/clicked
        /// </summary>
        /// <param name="sender">sender of this event</param>
        /// <param name="e">metadata for the event</param>
        private void YouAreToastClick(object sender, RoutedEventArgs e)
        {
            IMenuItem item = new YouAreToast();

            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(item);
            }
            YouAreToastCustomization customization = new YouAreToastCustomization();
            customization.DataContext = item;
            MainWindowInstance.BackToMenu.IsEnabled = true;
            MainWindowInstance.Border.Child = customization;

        }
        /// <summary>
        /// Handles the event of the liquified vegetation menu item being added/clicked
        /// </summary>
        /// <param name="sender">sender of this event</param>
        /// <param name="e">metadata for the event</param>
        private void LiquifiedVegetationClick(object sender, RoutedEventArgs e)
        {
            IMenuItem item = new LiquifiedVegetation();

            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(item);
            }

            LiquifiedVegetationCustomization customization = new LiquifiedVegetationCustomization();
            customization.DataContext = item;
            MainWindowInstance.BackToMenu.IsEnabled = true;
            MainWindowInstance.Border.Child = customization;

        }
        /// <summary>
        /// Handles the event of the saucer fuel menu item being added/clicked
        /// </summary>
        /// <param name="sender">sender of this event</param>
        /// <param name="e">metadata for the event</param>
        private void SaucerFuelClick(object sender, RoutedEventArgs e)
        {
            IMenuItem item = new SaucerFuel();

            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(item);
            }
            SaucerFuelCustomization customization = new SaucerFuelCustomization();
            customization.DataContext = item;
            MainWindowInstance.BackToMenu.IsEnabled = true;
            MainWindowInstance.Border.Child = customization;

        }

        /// <summary>
        /// Handles the event of the inorganic substance menu item being added/clicked
        /// </summary>
        /// <param name="sender">sender of this event</param>
        /// <param name="e">metadata for the event</param>
        private void InorganicSubstanceClick(object sender, RoutedEventArgs e)
        {
            IMenuItem item = new InorganicSubstance();

            if (DataContext is ICollection<IMenuItem> list)
            {
                list.Add(item);
            }
            InorganicSubstanceCustomization customization = new InorganicSubstanceCustomization();
            customization.DataContext = item;
            MainWindowInstance.BackToMenu.IsEnabled = true;
            MainWindowInstance.Border.Child = customization;

        }
    }
}
