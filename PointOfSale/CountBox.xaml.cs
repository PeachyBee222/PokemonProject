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
    /// Interaction logic for Count.xaml
    /// </summary>
    public partial class CountBox : UserControl
    {
        /// <summary>
        /// Initializes this component
        /// </summary>
        public CountBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The dependency property of count that allows us to use count in the xaml
        /// </summary>
        public static readonly DependencyProperty CountProperty = DependencyProperty.Register(
            nameof(Count),
            typeof(uint),
            typeof(CountBox),
            new FrameworkPropertyMetadata(0u, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// The number of this instance of an item that is wanted
        /// </summary>
        public uint Count
        {
            get { return (uint)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }

        /// <summary>
        /// the + button is pressed handler
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the event occuring</param>
        private void HandleIncrement(object sender, RoutedEventArgs e)
        {
            if (Count != uint.MaxValue) { Count++; }
            e.Handled = true;

        }

        /// <summary>
        /// the - button is pressed handler
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the event occuring</param>
        private void HandleDecrement(object sender, RoutedEventArgs e)
        {
            if (Count != 0)
            {
                Count--;
            }
            e.Handled = true;
        }
    }
}
