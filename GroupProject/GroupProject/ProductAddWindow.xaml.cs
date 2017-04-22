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
    /// Interaction logic for ProductAdd.xaml
    /// </summary>
    public partial class ProductAddWindow : Window
    {
        /// <summary>
        /// Initializes the window
        /// </summary>
        public ProductAddWindow()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Inserts the new item into the DataBase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSubmit_Click(object sender, RoutedEventArgs e)
        {
            double num;//parsded to double from txtAddPrice.Text
            bool parsed = double.TryParse(txtAddPrice.Text, out num);//attempts to parsde to double from txtAddPrice.Text
            if (txtAddId.Text == "" || txtAddDesc.Text == "" || txtAddPrice.Text == "")
            {
                MessageBox.Show("All fields must contain a value.", "Missing Data Alert", MessageBoxButton.OK);
            }
            else if (num < 0)
            {
                MessageBox.Show("You can't enter a negative value for Price.", "Negative Value Alert", MessageBoxButton.OK);
            }
            else if(!parsed)
            {
                MessageBox.Show("Price must only contain numbers and decimals.", "Invalid Format Alert", MessageBoxButton.OK);
            }
            else
            {
                if (BusCtrl.canInsert(txtAddId.Text))
                {
                    BusCtrl.addProduct(txtAddId.Text, txtAddDesc.Text, txtAddPrice.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ItemCode alredy exists, try again", "Alert", MessageBoxButton.OK);
                }
            }
                        
        }
        /// <summary>
        /// Closes the window on cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
