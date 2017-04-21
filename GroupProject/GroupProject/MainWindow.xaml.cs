using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace GroupProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region ClassVariables
        Invoice CurrentInvoice;
        List<Product> newProducts;
        #endregion

        /// <summary>
        /// MainWindow constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            populateProductDropdown();
            CurrentInvoice = new Invoice();
        }

        private void showInvoiceInfo()
        {
            try
            {
                if (CurrentInvoice == null)
                    return;
                txtInvoiceID.Text = CurrentInvoice.ID.ToString();
                DatePickerDate.SelectedDate = CurrentInvoice.Date;
                stackPanelInvoiceProducts.Children.Clear();
                double totalCost = 0;
                foreach (var product in CurrentInvoice.products)
                {
                    ColumnDefinition productName = new ColumnDefinition();
                    ColumnDefinition productCost = new ColumnDefinition();
                    ColumnDefinition removeProduct = new ColumnDefinition();
                    Grid productGrid = new Grid();
                    productName.Width = new GridLength(4, GridUnitType.Star);
                    productCost.Width = new GridLength(2, GridUnitType.Star);
                    removeProduct.Width = new GridLength(1, GridUnitType.Star);

                    productGrid.ColumnDefinitions.Add(productName);
                    productGrid.ColumnDefinitions.Add(productCost);
                    //productGrid.ColumnDefinitions.Add(removeProduct);

                    Label lblProductDesc = new Label() { Content = product.ProductDescription };
                    Label lblProductCost = new Label() { Content = product.ProductCost };
                    Button btnDeleteProduct = new Button() { Content = "X" };

                    Grid.SetColumn(lblProductDesc, 0);
                    Grid.SetColumn(lblProductCost, 1);
                    //Grid.SetColumn(btnDeleteInvoice, 2);

                    productGrid.Children.Add(lblProductDesc);
                    productGrid.Children.Add(lblProductCost);
                    // productGrid.Children.Add(btnDeleteInvoice);

                    stackPanelInvoiceProducts.Children.Add(productGrid);
                    totalCost += product.ProductCost;
                }
                txtTotalCost.Text = "$" + totalCost;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + ":" +
                     MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }
        private void populateProductDropdown()
        {
            comboProductSelect.Items.Clear();
            foreach(Product product in BusCtrl.getProductList())
            {
                product.inDB = false;
                comboProductSelect.Items.Add(product);
            }
        }

        /// <summary>
        /// Opens the Invoice Search window.
        /// </summary>
        /// <param name="sender">The Search button.</param>
        /// <param name="e">The RoutedEventArgs.</param>
        private void btn_search_click(object sender, RoutedEventArgs e)
        {
            //this will open the search window. Will need a constructor on the search window that accepts
            //an out variable to be set to the id to populate in the main window

            try
            {
                //CurrentInvoice = BusCtrl.getInvoiceByID(5000);
                //showInvoiceInfo();
                //return;
                int lookUpId = new SearchWindow().ShowDialog();
                if (lookUpId == -1)
                    return;
                CurrentInvoice = BusCtrl.getInvoiceByID(lookUpId);
                showInvoiceInfo();
            }
            catch(Exception ex)
            {
                //handle error
            }
        }

        /// <summary>
        /// Opens the Product window.
        /// </summary>
        /// <param name="sender">The Product button.</param>
        /// <param name="e">The RoutedEventArgs.</param>
        private void btn_product_click(object sender, RoutedEventArgs e)
        {
            //no data will need to be passed between these two objects, but both should have access to the static manger
            //class that will hold the datastructures with the invoice and product data as well as 
            //comunicate with the db class
            new ProductWindow().ShowDialog();
        }

        /// <summary>
        /// Called on a click of the Add button. Inserts a new Invoice into the DB.
        /// </summary>
        /// <param name="sender">The Add button.</param>
        /// <param name="e">The RoutedEventArgs.</param>
        private void btn_add_invoice_click(object sender, RoutedEventArgs e)
        {
            try
            {
                int newId = BusCtrl.addInvoice(DatePickerDate.SelectedDate.Value, CurrentInvoice.products);
                //insert new invoiced data into the db. this will probably be done through a manager class to avoid work on the ui
                lblStatus.Content = "Invoice #" + newId + " added";
                CurrentInvoice = BusCtrl.getInvoiceByID(newId);
                showInvoiceInfo();
            }
            catch(Exception ex)
            {

            }

        }

        /// <summary>
        /// Called on a click of the Edit button. Edits the existing Invoice in the DB.
        /// </summary>
        /// <param name="sender">The Edit button.</param>
        /// <param name="e">The RoutedEventArgs.</param>
        private void btn_edit_invoice_click(object sender, RoutedEventArgs e)
        {
            try
            {
                BusCtrl.updateInvoice(CurrentInvoice, CurrentInvoice.products);
                lblStatus.Content = "Updated Invoice " + CurrentInvoice.ID;
            }
            catch(Exception ex)
            {

            }
            //update current invoice in db. This will proably be done by passing the relavant info into a manager class

        }

        /// <summary>
        /// Called on a click of the Delete button. Deletes the existing Invoice in the DB.
        /// </summary>
        /// <param name="sender">The Delete button.</param>
        /// <param name="e">The RoutedEventArgs.</param>
        private void btn_delete_invoice_click(object sender, RoutedEventArgs e)
        {
            try
            {
                BusCtrl.deleteInvoice(CurrentInvoice.ID);
                lblStatus.Content = "Invoice " + CurrentInvoice.ID + " Deleted";
            }
            catch(Exception ex)
            {
                
            }
            //delete the current invoice. this will probalby be done in some object manager class that you pass the id

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtInvoiceID.Text = "";
            DatePickerDate.SelectedDate = null;
            stackPanelInvoiceProducts.Children.Clear();
            CurrentInvoice = new Invoice();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            CurrentInvoice.products.Add(comboProductSelect.SelectedItem as Product);
            showInvoiceInfo();
        }
    }
}
