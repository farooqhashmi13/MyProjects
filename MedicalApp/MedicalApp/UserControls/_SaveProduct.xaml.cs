using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicalApp.UserControls
{
    /// <summary>
    /// Interaction logic for _SaveProduct.xaml
    /// </summary>
    public partial class _SaveProduct : UserControl
    {
        public _SaveProduct()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            var windows = Application.Current.Windows;

            if (windows.Count == 0)
                return;

            var saveProductWindow = new Window();

            for (int i = 0; i < windows.Count; i++)
                if (windows[i].Name == "SaveProductsWindow")
                    saveProductWindow = windows[i];

            saveProductWindow.Close();
        }
    }
}
