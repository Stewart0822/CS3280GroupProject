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
        private static DataAccessPoint.DataAccess dataAccess = new DataAccessPoint.DataAccess();
        
        
        //----------------------Product stuff------------------------
        /// <summary>
        /// returns a DataSet of all item from the ItemDesc table
        /// </summary>
        /// <param name="iRowCount"></param>
        /// <returns></returns>
        public static DataSet getProductDataSet(ref int iRowCount)
        {
            DataSet ds = new DataSet();
            return ds = dataAccess.ExecuteSQLStatement(SQLStrings.getAllProducts(), ref iRowCount);            
        }

        public static List<Product> getProductsByInvoice(int invoiceID)
        {
            return null;
        }

        public static ProductWindow getProduct(int productID)
        {
            return null;
        }

        public static void addProduct(string sItemCode, string sItemDesc, string sCost)
        {
            dataAccess.ExecuteNonQuery(SQLStrings.insertProduct(sItemCode, sItemDesc, sCost));
            Console.WriteLine("Data was inserted");
        }
        /// <summary>
        /// Updated items in ItemDesc based on ItemCode
        /// </summary>
        /// <param name="sItemCode"></param>
        /// <param name="sItemDesc"></param>
        /// <param name="sCost"></param>
        public static void updateProductItemDesc(string sItemCode, string sItemDesc, string sCost)
        {
            dataAccess.ExecuteNonQuery(SQLStrings.updateProductItemDesc(sItemCode, sItemDesc, sCost));
        }
        /// <summary>
        /// Deletes items form LineItems based on ItemCode
        /// </summary>
        /// <param name="itemCode"></param>
        public static void deleteProductLineItem(string itemCode)
        {
            dataAccess.ExecuteNonQuery(SQLStrings.deleteProductLineItems(itemCode));
        }
        /// <summary>
        /// Deletes items form ItemDesc based on ItemCode
        /// </summary>
        /// <param name="itemCode"></param>
        public static void deleteProductItemDesc(string itemCode)
        {
            dataAccess.ExecuteNonQuery(SQLStrings.deleteProductItemDesc(itemCode));
        }
        /// <summary>
        /// Checks to see it ItemCode already exists in database returns bool
        /// </summary>
        /// <param name="ItemCode"></param>
        /// <returns></returns>
        public static bool canInsert(string ItemCode)
        {
            int iRowCount = 0;
            dataAccess.ExecuteSQLStatement(SQLStrings.checkProductExists(ItemCode) , ref iRowCount);
            if (iRowCount > 0)
                return false;
            else
                return true;
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
