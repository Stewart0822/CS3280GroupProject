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
    public partial class Product : Window
    {
        /// <summary>
        /// New window that that allows user to enter data for new product item
        /// </summary>
        Window wndAddProduct;
        /// <summary>
        /// New window that that allows user to edit data for a product item
        /// </summary>
        Window wndEditProduct;

        public Product()
        {
            InitializeComponent();
            wndAddProduct = new ProductAdd();
            wndEditProduct = new ProductEdit();
        }

        /// <summary>
        /// Open a dialog box allowing a user to add new product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProdAdd_Click(object sender, RoutedEventArgs e)
        {
            wndAddProduct.ShowDialog();
        }

        /// <summary>
        /// Opens a dialog box with current selection from the dataGrid to be updated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProdEdt_Click(object sender, RoutedEventArgs e)
        {
            wndEditProduct.ShowDialog();
            //This window's text fields will also be auto populated with the data selected in the dataGrid
        }

        /// <summary>
        /// Deletes the current selection in the dataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProdDel_Click(object sender, RoutedEventArgs e)
        {
            //This will DELETE the current selections from the dataGrid/Database
        }
    }
}
