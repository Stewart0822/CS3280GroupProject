using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    static class SQLStrings
    {
        #region InvoiceSelects

        /// <summary>
        /// Creates a SQL query to return all rows and columns from the Invoices table.
        /// </summary>
        /// <returns>A SQL query</returns>
        public static string getAllInvoices()
        {
            return "SELECT * FROM Invoices";
        }

        /// <summary>
        /// Creates a SQL query to return all rows and columns from the Invoices table for a given cost.
        /// </summary>
        /// <param name="total">The invoice total</param>
        /// <returns>A SQL query</returns>
        public static string getInvoicesForTotal(double total)
        {
            return "SELECT * FROM Invoices WHERE TotalCharge = " + total;
        }

        /// <summary>
        /// Creates a SQL query to return all rows and columns from the Invoices table for a given invoice number.
        /// </summary>
        /// <param name="id">The invoice number</param>
        /// <returns>A SQL query</returns>
        public static string getInvoiceForId(int id)
        {
            return "SELECT * FROM Invoices WHERE InvoiceNum = " + id;
        }

        /// <summary>
        /// Creates a SQL query to return all rows and columns from the Invoices table for a given date.
        /// </summary>
        /// <param name="date">The invoice date</param>
        /// <returns>A SQL query</returns>
        public static string getInvoiceForDate(string date)
        {
            return "SELECT * FROM Invoices WHERE InvoiceDate = #" + date + "#";
        }

        /// <summary>
        /// Creates a SQL query to return all rows and columns from the Invoices table for a given date and cost.
        /// </summary>
        /// <param name="date">invoice date</param>
        /// <param name="total">invoice total cost</param>
        /// <returns>A SQL query</returns>
        public static string getInvoice(string date, double total)
        {
            return "SELECT * FROM Invoices WHERE InvoiceDate = #" + date + "# AND TotalCharge = " + total;
        }

        /// <summary>
        /// Creates a SQL query to return all rows and columns from the Invoices table for a given invoice number and cost.
        /// </summary>
        /// <param name="id">invoice number</param>
        /// <param name="total">invoice total</param>
        /// <returns>A SQL query</returns>
        public static string getInvoiceByIDTotal(int id, double total)
        {
            return "SELECT * FROM Invoices WHERE InvoiceNum = " + id + " AND TotalCharge = " + total;
        }

        /// <summary>
        /// Creates a SQL query to return all rows and columns from the Invoices table for a given invoice number and date.
        /// </summary>
        /// <param name="id">invoice number</param>
        /// <param name="date">invoice date</param>
        /// <returns>A SQL query</returns>
        public static string getInvoiceByIDDate(int id, string date)
        {
            return "SELECT * FROM Invoices WHERE InvoiceNum = " + id + " AND InvoiceDate = #" + date +"#";
        }

        /// <summary>
        /// Creates a SQL query to return all rows and columns from the Invoices table for a given invoice number, date, and total.
        /// </summary>
        /// <param name="id">invoice number</param>
        /// <param name="date">invoice date</param>
        /// <param name="total">invoice total</param>
        /// <returns>A SQL query</returns>
        public static string getInvoiceByIDDateTotal(int id, string date, double total)
        {
            return "SELECT * FROM Invoices WHERE InvoiceNum = " + id + " AND InvoiceDate = #" + date + "# AND TotalCharge = " + total;
        }

        /// <summary>
        /// Creates a SQL query to return all invoice numbers from the Invoices table.
        /// </summary>
        /// <returns>A SQL query</returns>
        public static string getAllInvoiceIDs()
        {
            return "SELECT InvoiceNum FROM Invoices";
        }

        /// <summary>
        /// Creates a SQL query to return all invoice totals from the Invoices table.
        /// </summary>
        /// <returns>A SQL query</returns>
        public static string getAllInvoiceTotals()
        {
            return "SELECT TotalCharge FROM Invoices";
        }

        /// <summary>
        /// Creates a SQL query to return the newest invoice from the Invoices table.
        /// </summary>
        /// <returns></returns>
        public static string getNewInvoice()
        {
            return "Select MAX(InvoiceNum) FROM Invoices";
        }

        #endregion


        #region InvoiceCommands

        /// <summary>
        /// Creates a SQL query to insert an invoice into the Invoices table.
        /// </summary>
        /// <param name="date">invoice date</param>
        /// <param name="total">invoice total</param>
        /// <returns>A SQL query</returns>
        public static string insertInvoice(string date, double total)
        {
            return "INSERT INTO Invoices(InvoiceDate,TotalCharge) VALUES (#" + date + "#," + total + ")";
        }

        /// <summary>
        /// Creates a SQL query to update an invoice in the Invoices table.
        /// </summary>
        /// <param name="id">invoice ID</param>
        /// <param name="date">invoice date</param>
        /// <param name="total">invoice total</param>
        /// <returns>A SQL query</returns>
        public static string updateInvoice(int id, string date, double total)
        {
            return "UPDATE invoices SET InvoiceDate = #" + date + "#, TotalCharge = " + total + " WHERE InvoiceNum = " + id;
        }

        /// <summary>
        /// Creates a SQL query to delete an invoice from the Invoices table.
        /// </summary>
        /// <param name="id">invoice ID</param>
        /// <returns>A SQL query</returns>
        public static string deleteInvoice(int id)
        {
            return "DELETE FROM Invoices WHERE InvoiceNum = " + id;
        }

        #endregion


        #region Product

        /// <summary>
        /// Creates a SQL query to get all products
        /// </summary>
        /// <returns>A SQL query</returns>
        public static string getAllProducts()
        {
            return "SELECT * FROM ItemDesc";
        }

        /// <summary>
        /// Creates a SQL query to get a specific product
        /// </summary>
        /// <param name="s">product code</param>
        /// <returns>A SQL query</returns>
        public static string checkProductExists(string s)
        {
            return "SELECT * FROM ItemDesc WHERE ItemCode = '" + s + "'";
        }

        /// <summary>
        /// Creates a SQL query to insert a product
        /// </summary>
        /// <param name="ItemCode">product code</param>
        /// <param name="ItemDesc">product description</param>
        /// <param name="ItemCost">product cost</param>
        /// <returns>A SQL query</returns>
        public static string insertProduct(string ItemCode, string ItemDesc, string ItemCost)
        {
            return "INSERT INTO ItemDesc(ItemCode,ItemDesc,Cost) VALUES(" + "'"+ ItemCode +"', '" + ItemDesc + "', '" + ItemCost + "'" + ")";
        }

        /// <summary>
        /// Creates a SQL query to update a product
        /// </summary>
        /// <param name="ItemCode">product code</param>
        /// <param name="ItemDesc">product description</param>
        /// <param name="ItemCost">product cost</param>
        /// <returns>A SQL query</returns>
        public static string updateProductItemDesc(string ItemCode, string ItemDesc, string itemCost)
        {
            return "UPDATE ItemDesc SET ItemDesc = '" + ItemDesc + "', Cost = '" + itemCost + "' WHERE ItemCode = '" + ItemCode + "'";
        }

        /// <summary>
        /// Creates a SQL query to delete a product from the LineItems table
        /// </summary>
        /// <param name="itemCode">product code</param>
        /// <returns>A SQL query</returns>
        public static string deleteProductLineItems(string itemCode)
        {
            return "DELETE * FROM LineItems WHERE ItemCode = '" + itemCode + "'";
        }

        /// <summary>
        /// Creates a SQL query to delete a product from the ItemDesc table
        /// </summary>
        /// <param name="itemCode">product code</param>
        /// <returns>A SQL query</returns>
        public static string deleteProductItemDesc(string itemCode)
        {
            return "DELETE * FROM ItemDesc WHERE ItemCode = '" + itemCode + "'";
        }

        /// <summary>
        /// Creates a SQL query to get all products attached to an invoice
        /// </summary>
        /// <returns>A SQL query</returns>
        public static string getAllProductsInUse()
        {
            return "SELECT DISTINCT ItemCode FROM LineItems";
        }

        /// <summary>
        /// Creates a SQL query to get all invoice IDs a product is attached to
        /// </summary>
        /// <param name="itemCode">product code</param>
        /// <returns>A SQL query</returns>
        public static string getInvoiceIDsByProductCode(string itemCode)
        {
            return "SELECT DISTINCT InvoiceNum FROM LineItems WHERE ItemCode = '" + itemCode + "'";
        }

        #endregion


        #region LineItem

        /// <summary>
        /// Creates a SQL query to get all line items for a given invoice ID
        /// </summary>
        /// <param name="invoiceId">invoice ID</param>
        /// <returns>A SQL query</returns>
        public static string getLineItemsForInvoice(int invoiceId)
        {
            return "SELECT LI.InvoiceNum, LI.ItemCode, ID.ItemDesc, ID.Cost FROM LineItems LI INNER JOIN ItemDesc ID ON LI.ItemCode = ID.ItemCode  WHERE InvoiceNum = " + invoiceId;
        }

        /// <summary>
        /// Creates a SQL query to attach products to invoices
        /// </summary>
        /// <param name="invoiceId">invoice number</param>
        /// <param name="ItemCode">product code</param>
        /// <returns>A SQL query</returns>
        public static string insertLineItem(int invoiceId, string ItemCode)
        {
            return "INSERT INTO LineItems(invoiceNum,ItemCode) VALUES (" + invoiceId  + ",'" + ItemCode + "')";
        }

        /// <summary>
        /// Creates a SQL query to delete product to invoice relationships
        /// 
        /// </summary>
        /// <param name="invoiceId">invoice number</param>
        /// <returns>A SQL query</returns>
        public static string removeLineItems(int invoiceId)
        {
            return "DELETE FROM LineItems WHERE InvoiceNum = " + invoiceId;
        }
        #endregion
    }
}
