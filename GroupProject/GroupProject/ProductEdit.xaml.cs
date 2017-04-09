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
    public partial class ProductEdit : Window
    {
        public ProductEdit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// handles the onClick event of the submit button on wndProductEdit 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditSubmit_Click(object sender, RoutedEventArgs e)
        {
            //On Submit the current data in the text boxes will be updated in the database via _id
        }

        /// <summary>
        /// handles the onClick event of the cancel button on wndProductEdit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditCancel_Click(object sender, RoutedEventArgs e)
        {
            wndEditProduct.Hide();//hides the window onClick of cancel
        }
    }
}
