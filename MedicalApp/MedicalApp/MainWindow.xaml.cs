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

namespace MedicalApp
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

        private void ListViewItem_Click(object sender, MouseButtonEventArgs e)
        {

            var menu = (FrameworkElement)sender;
            switch (menu.Name)
            {
                case "home_menu":
                    home_uc.Visibility = Visibility.Visible;
                    sales_uc.Visibility = Visibility.Hidden;
                    product_uc.Visibility = Visibility.Hidden;
                    customer_uc.Visibility = Visibility.Hidden;
                    break;
                case "sales_menu":
                    home_uc.Visibility = Visibility.Hidden;
                    sales_uc.Visibility = Visibility.Visible;
                    product_uc.Visibility = Visibility.Hidden;
                    customer_uc.Visibility = Visibility.Hidden;
                    break;
                case "product_menu":
                    home_uc.Visibility = Visibility.Hidden;
                    sales_uc.Visibility = Visibility.Hidden;
                    product_uc.Visibility = Visibility.Visible;
                    customer_uc.Visibility = Visibility.Hidden;
                    break;
                case "customer_menu":
                    home_uc.Visibility = Visibility.Hidden;
                    sales_uc.Visibility = Visibility.Hidden;
                    product_uc.Visibility = Visibility.Hidden;
                    customer_uc.Visibility = Visibility.Visible;
                    break;
            }

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {

            var windows = Application.Current.Windows;

            if (windows.Count == 0)
                return;

            for (int i = 0; i < windows.Count; i++)
                windows[i].Close();

        }
    }
}
