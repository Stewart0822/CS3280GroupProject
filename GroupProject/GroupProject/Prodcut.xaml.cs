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
using System.Windows.Shapes;

namespace GroupProject
{
    /// <summary>
    /// Interaction logic for Prodcut.xaml
    /// </summary>
    public partial class Prodcut : Window
    {
        /// <summary>
        /// New window that that allows user to enter data for new product item
        /// </summary>
        Window wndAddProduct;
        /// <summary>
        /// New window that that allows user to edit data for a product item
        /// </summary>
        Window wndEditProduct;

        public Prodcut()
        {
            InitializeComponent();
            wndAddProduct = new ProductAdd();
            wndEditProduct = new ProductEdit();
        }

        /// <summary>
        /// handles the onClick event of the add button on wndProduct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProdAdd_Click(object sender, RoutedEventArgs e)
        {
            wndAddProduct.ShowDialog();//Opens the window to add new product items
        }

        /// <summary>
        /// handles the onClick event of the edit button on wndProduct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProdEdt_Click(object sender, RoutedEventArgs e)
        {
            wndEditProduct.ShowDialog();//Opens the window to edit the current selection in the dataGrid on wndProduct
            //This window's text fields will also be auto populated with the data selected in the dataGrid
        }

        /// <summary>
        /// handles the onClick event of the delect button on wndProduct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProdDel_Click(object sender, RoutedEventArgs e)
        {
            //This will DELETE the current selections in the dataGrid from the dataGrid/Database
        }
    }
}
