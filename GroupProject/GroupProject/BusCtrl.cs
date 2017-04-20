using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    public static class BusCtrl
    {
        /// <summary>
        /// Static dataaccess to access db
        /// </summary>
        private static Assignment6AirlineReservation.DataAccess dataAccess = new Assignment6AirlineReservation.DataAccess();
        //----------------------Product stuff------------------------

        public static void getProductList()
        {

        }

        public static List<Product> getProductsByInvoice(int invoiceID)
        {
            return null;
        }

        public static ProductWindow getProduct(int productID)
        {
            return null;
        }

        public static void addProduct(string name, string description, double amount)
        {

        }

        public static void updateProduct(Product p)
        {

        }

        public static void deleteProduct(int productID)
        {

        }

        //---------------------Search stuff---------------------------

        public static DataSet getInvoiceList(int id, DateTime date, double total)
        {
            return null;
        }

        //---------------------Main Window stuff----------------------

        public static Invoice getInvoiceByID(int id)
        {
            int numRows = 0;
            //DataSet dataAccess.ExecuteSQLStatement(SQLStrings.getInvoiceForId(id),ref numRows);
            return null;
        }

        public static void updateInvoice(Invoice i)
        {

        }

        public static void addInvoice(DateTime date, List<Product> prodList)
        {

        }

        public static void deleteInvoice(int id)
        {

        }
    }
}
