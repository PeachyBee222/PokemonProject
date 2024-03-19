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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = order;

        }

        /// <summary>
        /// The order for this specific main window
        /// </summary>
        public Order order = new Order();

        /// <summary>
        /// Enables the action for canceling the order and creating a new order
        /// </summary>
        /// <param name="sender">the sender of this event</param>
        /// <param name="e">the event causing this to occur</param>
        public void CancelClick(object sender, RoutedEventArgs e)
        {
            order = new Order();
            DataContext = order;
            this.Border.Child = new MenuItemSelectionControl();
            BackToMenu.IsEnabled = false;
        }
        /// <summary>
        /// The event for clicking the complete order button
        /// </summary>
        /// <param name="sender">the sender of this event</param>
        /// <param name="e">the event occuring</param>
        public void CompleteClick(object sender, RoutedEventArgs e)
        {
            //display payment options 
            PaymentOptionsScreen payment = new PaymentOptionsScreen();
            this.Border.Child = payment;
        }

        /// <summary>
        /// Handles the back to menu button click
        /// </summary>
        /// <param name="sender">the sender of this event</param>
        /// <param name="e">the event called</param>
        public void BackToMenuClick(object sender, RoutedEventArgs e)
        {
            MenuItemSelectionControl selectionControl = new MenuItemSelectionControl();
            Border.Child = selectionControl;
            
            BackToMenu.IsEnabled = false;
        }

        /// <summary>
        /// Handles when a button for edit or delete is clicked
        /// </summary>
        /// <param name="sender">the sender of the event</param>
        /// <param name="e">the event that triggers</param>
        public void DeleteOrEditClick(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button button)
            {
                e.Handled = true;
                if(button.Name == "Remove")
                {
                    order.Remove((IMenuItem)button.DataContext);
                    this.Border.Child = new MenuItemSelectionControl();
                }
                if(button.Name == "Edit")
                {
                    this.BackToMenu.IsEnabled = true;
                    var temp = (IMenuItem)button.DataContext;
                    switch (temp)
                    {
                        case CrashedSaucer: 
                            CrashedSaucerCustomization customization = new CrashedSaucerCustomization();
                            customization.DataContext = temp;
                            this.Border.Child = customization;
                            break;
                        case CropCircle:
                            CropCircleCustomization customization1 = new CropCircleCustomization();
                            customization1.DataContext = temp;
                            this.Border.Child = customization1;
                            break;
                        case EvisceratedEggs:
                            EvisceratedEggsCustomization customization2 = new EvisceratedEggsCustomization();
                            customization2.DataContext = temp;
                            this.Border.Child = customization2;
                            break;
                        case FlyingSaucer:
                            FlyingSaucerCustomization customization3 = new FlyingSaucerCustomization();
                            customization3.DataContext = temp;
                            this.Border.Child = customization3;
                            break;
                        case GlowingHaystack:
                            GlowingHaystackCustomization customization4 = new GlowingHaystackCustomization();
                            customization4.DataContext = temp;
                            this.Border.Child = customization4;
                            break;
                        case InorganicSubstance:
                            InorganicSubstanceCustomization customization5 = new InorganicSubstanceCustomization();
                            customization5.DataContext = temp;
                            this.Border.Child = customization5;
                            break;
                        case LiquifiedVegetation:
                            LiquifiedVegetationCustomization customization6 = new LiquifiedVegetationCustomization();
                            customization6.DataContext = temp;
                            this.Border.Child = customization6;
                            break;
                        case LivestockMutilation:
                            LivestockMutilationCustomization customization7 = new LivestockMutilationCustomization();
                            customization7.DataContext = temp;
                            this.Border.Child = customization7;
                            break;
                        case MissingLinks:
                            MissingLinksCustomization customization8 = new MissingLinksCustomization();
                            customization8.DataContext = temp;
                            this.Border.Child = customization8;
                            break;
                        case OuterOmelette:
                            OuterOmletteCustomization customization9 = new OuterOmletteCustomization();
                            customization9.DataContext = temp;
                            this.Border.Child = customization9;
                            break;
                        case SaucerFuel:
                            SaucerFuelCustomization customization10 = new SaucerFuelCustomization();
                            customization10.DataContext = temp;
                            this.Border.Child = customization10;
                            break;
                        case TakenBacon:
                            TakenBaconCustomization customization11 = new TakenBaconCustomization();
                            customization11.DataContext = temp;
                            this.Border.Child = customization11;
                            break;
                        case YouAreToast:
                            YouAreToastCustomization customization12 = new YouAreToastCustomization();
                            customization12.DataContext = temp;
                            this.Border.Child = customization12;
                            break;
                    }
                }
            }
        }
    }
}
