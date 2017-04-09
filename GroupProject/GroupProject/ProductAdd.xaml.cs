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
    public partial class ProductAdd : Window
    {
        public ProductAdd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// handles the onClick event of the submit button on wndProductAdd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSubmit_Click(object sender, RoutedEventArgs e)
        {
            //On submit the data in the text field will be saved to the database and given an _id
        }

        /// <summary>
        /// handles the onClick event of the cancel button on wndProductAdd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCancel_Click(object sender, RoutedEventArgs e)
        {
            wndAddProduct.Hide();//Hides the add product window onClick of cancel
        }
    }
}
