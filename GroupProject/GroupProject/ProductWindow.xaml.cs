using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    public partial class ProductWindow : Window
    {
        ///// <summary>
        ///// New window that that allows user to enter data for new product item
        ///// </summary>
        int iRowCount;
        public ProductWindow()
        {
            InitializeComponent();
            iRowCount = 0;
            btnProdEdt.IsEnabled = false;
            btnProdDel.IsEnabled = false;
            loadDataGrid();
        }

        public void loadDataGrid()
        {
            dgProduct.ItemsSource = new DataView(BusCtrl.getProductDataSet(ref iRowCount).Tables[0]);
        }

        /// <summary>
        /// Open a dialog box allowing a user to add new product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProdAdd_Click(object sender, RoutedEventArgs e)
        {
            new ProductAddWindow().ShowDialog();
            loadDataGrid();
        }

        /// <summary>
        /// Opens a dialog box with current selection from the dataGrid to be updated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProdEdt_Click(object sender, RoutedEventArgs e)
        {
            
            string sItemCode = ((DataRowView)dgProduct.SelectedItem)[0].ToString();
            string sItemDesc = ((DataRowView)dgProduct.SelectedItem)[1].ToString();
            string sCost = ((DataRowView)dgProduct.SelectedItem)[2].ToString();
            new ProductEditWindow(sItemCode, sItemDesc, sCost).ShowDialog();
            loadDataGrid();
            //This window's text fields will also be auto populated with the data selected in the dataGrid
        }

        /// <summary>
        /// Deletes the current selection in the dataGrid from DB and refreshes the DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProdDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to DELETE this item?", "Question", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                //get product code
                string sItemCode = ((DataRowView)dgProduct.SelectedItem)[0].ToString();

                //get list of products currently in use
                List<string> prodsInUse = BusCtrl.getAllProductsInUse();

                //if selected product is in use, don't delete
                if (prodsInUse.Contains(sItemCode))
                {
                    //display modal with invoices using the product
                    List<int> invoicesIDs = BusCtrl.getAllInvoiceIDsByProduct(sItemCode);
                    string errorMessage = "";
                    foreach (int i in invoicesIDs)
                    {
                        errorMessage += i + " ";
                    }
                    MessageBox.Show("Item cannot be deleted. In use by InvoiceID(s): " + errorMessage, "Can't Delete Product", MessageBoxButton.OK);
                    return;
                }

                //otherwise, delete it
                BusCtrl.deleteProductLineItem(sItemCode);
                BusCtrl.deleteProductItemDesc(sItemCode);

                //refresh datagrid
                loadDataGrid();
            }

        }

        /// <summary>
        /// Enables button options if selection is made
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnProdEdt.IsEnabled = true;
            btnProdDel.IsEnabled = true;
        }
    }
}
