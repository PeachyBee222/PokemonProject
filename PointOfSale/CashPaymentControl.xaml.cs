using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.Pkcs;
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
using RoundRegister;
using TheFlyingSaucer.Data;

namespace TheFlyingSaucer.PointOfSale
{
    /// <summary>
    /// Interaction logic for CashPaymentControl.xaml
    /// </summary>
    public partial class CashPaymentControl : UserControl
    {
        /// <summary>
        /// The control for cash payment
        /// </summary>
        public CashPaymentControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// the change owed
        /// </summary>
        private decimal _changeOwed { get; set; } = 0;

        /// <summary>
        /// Finalizes the order button click
        /// </summary>
        /// <param name="sender">the sender of the event</param>
        /// <param name="e">the event being called</param>
        public void FinalizeOrderClick(object sender, RoutedEventArgs e)
        {
            DependencyObject parent = this;
            do
            {
                parent = LogicalTreeHelper.GetParent(parent);
            }
            while (!(parent is null || parent is MainWindow));
            if (parent != null)
            {
                MainWindow main = (MainWindow)parent;
                ReceiptPrinter.PrintLine(main.order.Number.ToString());
                ReceiptPrinter.PrintLine(main.order.PlacedAt.ToString());
                foreach (IMenuItem item in main.order)
                {
                    ReceiptPrinter.PrintLine(item.Name + " " + item.Price.ToString("C2", new CultureInfo("en-US")));
                    foreach (var thing in item.SpecialInstructions)
                    {
                        ReceiptPrinter.PrintLine("\t"+thing);
                    }
                }
                ReceiptPrinter.PrintLine("Subtotal: " + main.order.Subtotal.ToString("C2", new CultureInfo("en-US")));
                ReceiptPrinter.PrintLine("Tax: " + main.order.Tax.ToString("C2", new CultureInfo("en-US")));
                ReceiptPrinter.PrintLine("Total: " + main.order.Total.ToString("C2", new CultureInfo("en-US")));
                ReceiptPrinter.PrintLine("Cash");
                ReceiptPrinter.PrintLine("Change Owed: "+ _changeOwed.ToString("C2", new CultureInfo("en-US")));
                ReceiptPrinter.CutTape();

                main.order = new Order();
                main.DataContext = main.order;
                main.Border.Child = new MenuItemSelectionControl();
            }


        }

        public void ChangeButtonClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is CashDrawerViewModel viewModel)
            {
                viewModel.FinalizeTransaction();
                _changeOwed = viewModel.ChangeOwed;
            }
            if(_changeOwed >=0)
            {
                finalizeSale.IsEnabled = true;
            }
        }
    }
}
