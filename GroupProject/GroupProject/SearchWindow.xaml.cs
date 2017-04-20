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
        }

        /// <summary>
        /// Closes the window and makes sure the selected invoice's ID# is returned to the Main Window.
        /// </summary>
        /// <param name="sender">The Select button.</param>
        /// <param name="e">The RoutedEventArgs.</param>
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            //Close the window and make sure the selected invoice's ID# is returned to the Main Window.
        }

        /// <summary>
        /// Closes the window. Doesn't return an invoice ID# to the main window.
        /// </summary>
        /// <param name="sender">The Cancel button.</param>
        /// <param name="e">The RoutedEventArgs.</param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //Close the window. Don't return an invoice ID# to the main window.
        }

        /// <summary>
        /// Resets all search filters to blank.
        /// </summary>
        /// <param name="sender">The Clear Filters button.</param>
        /// <param name="e">The RoutedEventArgs.</param>
        private void btnClearFilters_Click(object sender, RoutedEventArgs e)
        {
            //Reset all search filters to blank.
            cbIDNumber.SelectedIndex = -1;
            dpInvoiceDate.SelectedDate = null;
            cbInvoiceTotal.SelectedIndex = -1;
        }

        /// <summary>
        /// Called on SelectionChanged event for the ID# ComboBox in the search filters. Updates the DataGrid.
        /// </summary>
        /// <param name="sender">The ID# ComboBox.</param>
        /// <param name="e">The SelectionChangedEventArgs.</param>
        private void cbIDNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Update the DataGrid displaying invoices.
            updateResultsGrid();
        }

        /// <summary>
        /// Called on SelectedDateChanged event for the date picker in the search filters. Updates the DataGrid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //Update the DataGrid displaying invoices.
            updateResultsGrid();
        }

        /// <summary>
        /// Called on SelectionChanged event for the Invoice $ Total ComboBox in the search filters. Updates the DataGrid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbInvoiceTotal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Update the DataGrid displaying invoices.
            updateResultsGrid();
        }

        public new int ShowDialog()
        {
            base.ShowDialog();
            return invoiceID;
        }

        private void updateResultsGrid()
        {
            //Set search variables
            int invoiceID = cbIDNumber.SelectedIndex == -1 ? cbIDNumber.SelectedIndex : (int)cbIDNumber.SelectedItem;
            DateTime? invoiceDate = dpInvoiceDate.SelectedDate;
            double invoiceCharge = cbInvoiceTotal.SelectedIndex == -1 ? cbInvoiceTotal.SelectedIndex : (double)cbInvoiceTotal.SelectedItem;

            //bind to results data grid
            dgResults.ItemsSource = BusCtrl.getInvoiceList(invoiceID, invoiceDate, invoiceCharge).Tables[0].DefaultView;

            //test
        }
    }
}
