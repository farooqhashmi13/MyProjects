using MedicalApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for Product_UserControl.xaml
    /// </summary>
    public partial class Sales_UserControl : UserControl
    {
        public Sales_UserControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var context = new MedicalContext();
                var productList = context.Products.ToList();

                foreach (var product in productList)
                {
                    product_datagrid.Items.Add(new 
                    { 
                        Id = product.Id, 
                        ProductName = product.Name, 
                        BuyPrice = product.BuyPrice, 
                        SellPrice = product.SellPrice, 
                        Stock = product.Stock, 
                        ExpDate = product.ExpDate 
                    });
                }

                //product_datagrid.ItemsSource = productList;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
