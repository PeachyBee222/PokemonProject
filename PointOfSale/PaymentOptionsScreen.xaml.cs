using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
using RoundRegister;
using System.Globalization;

namespace TheFlyingSaucer.PointOfSale
{
    /// <summary>
    /// Interaction logic for PaymentOptionsScreen.xaml
    /// </summary>
    public partial class PaymentOptionsScreen : UserControl
    {
        public PaymentOptionsScreen()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Initializes the click for credit or debit payments
        /// </summary>
        /// <param name="sender">the sender of the event</param>
        /// <param name="e">the event being passed in</param>
        public void CreditOrDebitClick(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is Order order)
            {
                var result = CardReader.RunCard((double)order.Total);

                if (result == CardTransactionResult.Approved)
                {
                    //starts a new order
                    DependencyObject parent = this;
                    do
                    {
                        parent = LogicalTreeHelper.GetParent(parent);
                    }
                    while (!(parent is null || parent is MainWindow));
                    if (parent != null)
                    {
                        MainWindow main = (MainWindow)parent;

                        ReceiptPrinter.PrintLine("Order: "+main.order.Number.ToString());
                        ReceiptPrinter.PrintLine(main.order.PlacedAt.ToString());
                        foreach (IMenuItem item in main.order)
                        {
                            ReceiptPrinter.PrintLine(item.Name + " " + item.Price.ToString("C2", new CultureInfo("en-US")));
                            foreach(string thing in item.SpecialInstructions){
                                ReceiptPrinter.PrintLine("\t"+thing);
                            }
                        }
                        ReceiptPrinter.PrintLine("Subtotal: " + main.order.Subtotal.ToString("C2", new CultureInfo("en-US")));
                        ReceiptPrinter.PrintLine("Tax: " + main.order.Tax.ToString("C2", new CultureInfo("en-US")));
                        ReceiptPrinter.PrintLine("Total: " + main.order.Total.ToString("C2", new CultureInfo("en-US")));
                        ReceiptPrinter.PrintLine("Card");
                        ReceiptPrinter.CutTape();

                        main.order = new Order();
                        main.DataContext = main.order;
                        main.Border.Child = new MenuItemSelectionControl();
                    }
                }
                else if(result == CardTransactionResult.Declined)
                {
                    MessageBox.Show("Card was declined.");
                }
                else if (result == CardTransactionResult.ReadError)
                {
                    MessageBox.Show("Card had a read error. Please try again.");
                }
                else if (result == CardTransactionResult.InsufficientFunds)
                {
                    MessageBox.Show("Card has insufficient funds.");
                }
                else if (result == CardTransactionResult.IncorrectPin)
                {
                    MessageBox.Show("Cards pin was incorrect.");
                }
            }

        }
        /// <summary>
        /// Initializes the click for cash
        /// </summary>
        /// <param name="sender">the sender of the event</param>
        /// <param name="e">the event being passed in</param>
        public void CashClick(object sender, RoutedEventArgs e)
        {
            //should send in another GUI for taking a cash payment
            DependencyObject parent = this;
            do
            {
                parent = LogicalTreeHelper.GetParent(parent);
            } 
            while (!(parent is null || parent is MainWindow));
            if(parent != null)
            {
                MainWindow main = (MainWindow)parent;
                CashDrawerViewModel viewModel = new CashDrawerViewModel() { Total = main.order.Total};
                CashPaymentControl payment = new CashPaymentControl() { DataContext = viewModel};
                main.Border.Child = payment;
            }

        }

    }
}
