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
    /// Interaction logic for ProductEdit.xaml
    /// </summary>
    public partial class ProductEditWindow : Window
    {
        /// <summary>
        /// Initializes a window with textfields populated based off of dataGrid Selction
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        public ProductEditWindow(string s1, string s2, string s3)
        {
            InitializeComponent();
            txtEditId.Text = s1;
            txtEditDesc.Text = s2;
            txtEditPrice.Text = s3;
        }
        /// <summary>
        /// Submits the changes to the DataBase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditSubmit_Click(object sender, RoutedEventArgs e)
        {
            double num;
            if (txtEditDesc.Text == "" || txtEditPrice.Text == "")
            {
                MessageBox.Show("All fields must contain a value.", "Alert", MessageBoxButton.OK);
            }
            else if (!double.TryParse(txtEditPrice.Text, out num))
            {
                MessageBox.Show("Price must only contain numbers and decimals.", "Alert", MessageBoxButton.OK);
            }
            else
            {
                BusCtrl.updateProductItemDesc(txtEditId.Text, txtEditDesc.Text, txtEditPrice.Text);
                this.Close();
            }
        }
        /// <summary>
        /// closes the window on cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
