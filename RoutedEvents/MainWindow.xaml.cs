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

namespace RoutedEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SP_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Tbl_Output.Text += (sender as StackPanel).Name + " Preview/Tunnel\n";

            if ((sender as StackPanel).Name == "Gelb") e.Handled = true;
        }

        private void SP_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Tbl_Output.Text += (sender as StackPanel).Name + " Bubble\n";
        }
    }
}
