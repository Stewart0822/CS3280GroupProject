using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace GroupProject
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        int invoiceID = -1;

        /// <summary>
        /// The SearchWindow constructor.
        /// </summary>
        public SearchWindow()
        {
            InitializeComponent();
            populateFilters();
            updateResultsGrid();
        }

        /// <summary>
        /// Closes the window and makes sure the selected invoice's ID# is returned to the Main Window.
        /// </summary>
        /// <param name="sender">The Select button.</param>
        /// <param name="e">The RoutedEventArgs.</param>
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Close the window and make sure the selected invoice's ID# is returned to the Main Window.
                if (dgResults == null)
                {
                    invoiceID = -1;
                    return;
                }

                if (dgResults.SelectedIndex == -1)
                {
                    invoiceID = -1;
                    return;
                }

                invoiceID = Int32.Parse(((DataRowView)dgResults.SelectedItem)[0].ToString());
                Hide();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Closes the window. Doesn't return an invoice ID# to the main window.
        /// </summary>
        /// <param name="sender">The Cancel button.</param>
        /// <param name="e">The RoutedEventArgs.</param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Don't return an invoice ID# to the main window.
                invoiceID = -1;

                //Close the window
                Hide();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Resets all search filters to blank.
        /// </summary>
        /// <param name="sender">The Clear Filters button.</param>
        /// <param name="e">The RoutedEventArgs.</param>
        private void btnClearFilters_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Reset all search filters to blank.
                cbIDNumber.SelectedIndex = -1;
                dpInvoiceDate.SelectedDate = null;
                cbInvoiceTotal.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Called on SelectionChanged event for the ID# ComboBox in the search filters. Updates the DataGrid.
        /// </summary>
        /// <param name="sender">The ID# ComboBox.</param>
        /// <param name="e">The SelectionChangedEventArgs.</param>
        private void cbIDNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                updateResultsGrid();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Called on SelectedDateChanged event for the date picker in the search filters. Updates the DataGrid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                updateResultsGrid();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Called on SelectionChanged event for the Invoice $ Total ComboBox in the search filters. Updates the DataGrid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbInvoiceTotal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                updateResultsGrid();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Overwritten ShowDialog method that returns the ID of the selected invoice.
        /// </summary>
        /// <returns>The ID of the selected invoice, or -1 if nothing was selected.</returns>
        public new int ShowDialog()
        {
            base.ShowDialog();
            return invoiceID;
        }

        /// <summary>
        /// Private method to update the datagrid based on the value of the search filters.
        /// </summary>
        private void updateResultsGrid()
        {
            try
            {
                //Set search variables
                int invoiceID = cbIDNumber.SelectedIndex == -1 ? cbIDNumber.SelectedIndex : (int)cbIDNumber.SelectedItem;
                DateTime? invoiceDate = dpInvoiceDate.SelectedDate;
                double invoiceCharge = cbInvoiceTotal.SelectedIndex == -1 ? cbInvoiceTotal.SelectedIndex : (double)cbInvoiceTotal.SelectedItem;

                //bind to results data grid
                dgResults.ItemsSource = BusCtrl.getInvoiceList(invoiceID, invoiceDate, invoiceCharge).Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            
        }

        /// <summary>
        /// Private method to populate the search filters.
        /// </summary>
        private void populateFilters()
        {
            try
            {
                //populate invoice ID combobox
                cbIDNumber.ItemsSource = BusCtrl.getInvoiceIDs();

                //populate invoice Total combobox
                cbInvoiceTotal.ItemsSource = BusCtrl.getInvoiceTotals();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            
        }

        /// <summary>
        /// Exception handler that shows the error.
        /// </summary>
        /// <param name="sClass">the class</param>
        /// <param name="sMethod">the method</param>
        /// <param name="sMessage">the error message</param>
        static void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }
    }
}
