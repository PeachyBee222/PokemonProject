using System;
using System.Collections.Generic;
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

namespace TheFlyingSaucer.PointOfSale
{
    /// <summary>
    /// Interaction logic for PaidAndOwedCountBox.xaml
    /// </summary>
    public partial class PaidAndOwedCountBox : UserControl
    {
        /// <summary>
        /// Initialize this component
        /// </summary>
        public PaidAndOwedCountBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The dependency property of count that allows us to use count in the xaml
        /// </summary>
        public static readonly DependencyProperty PaidProperty = DependencyProperty.Register(
            nameof(Paid),
            typeof(uint),
            typeof(PaidAndOwedCountBox),
            new FrameworkPropertyMetadata(0u, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// The number of this instance of an item that is wanted
        /// </summary>
        public uint Paid
        {
            get { return (uint)GetValue(PaidProperty); }
            set { SetValue(PaidProperty, value); }
        }

        /// <summary>
        /// The dependency property of change owed that allows us to use change in the xaml
        /// </summary>
        public static readonly DependencyProperty OwedProperty = DependencyProperty.Register(
            nameof(Owed),
            typeof(uint),
            typeof(PaidAndOwedCountBox),
            new FrameworkPropertyMetadata(0u, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// The number of this instance of an item that is wanted
        /// </summary>
        public uint Owed
        {
            get { return (uint)GetValue(OwedProperty); }
            set { SetValue(OwedProperty, value); }
        }

        /// <summary>
        /// the + button is pressed handler
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the event occuring</param>
        private void HandleIncrement(object sender, RoutedEventArgs e)
        {
            if (Paid != uint.MaxValue) { Paid++; }
            e.Handled = true;

        }

        /// <summary>
        /// the - button is pressed handler
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the event occuring</param>
        private void HandleDecrement(object sender, RoutedEventArgs e)
        {
            if (Paid != 0)
            {
                Paid--;
            }
            e.Handled = true;
        }
    }
}
