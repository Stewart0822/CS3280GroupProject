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
        public static string getAllInvoices()
        {
            return "SELECT * FROM Invoices";
        }
        public static string getInvoicesForTotal(double total)
        {
            return "SELECT * FROM Invoices WHERE TotalCharge = " + total;
        }
        public static string getInvoiceForId(int id)
        {
            return "SELECT * FROM Invoices WHERE InvoiceNum = " + id;
        }
        public static string getInvoiceForDate(string date)
        {
            return "SELECT * FROM Invoices WHERE InvoiceDate = #" + date + "#";
        }
        public static string getInvoice(string date, double total)
        {
            return "SELECT * FROM Invoices WHERE InvoiceDate = #" + date + "# AND TotalCharge = " + total;
        }
        public static string getInvoiceByIDTotal(int id, double total)
        {
            return "SELECT * FROM Invoices WHERE InvoiceNum = " + id + " AND TotalCharge = " + total;
        }
        public static string getInvoiceByIDDate(int id, string date)
        {
            return "SELECT * FROM Invoices WHERE InvoiceNum = " + id + " AND InvoiceDate = #" + date +"#";
        }
        public static string getInvoiceByIDDateTotal(int id, string date, double total)
        {
            return "SELECT * FROM Invoices WHERE InvoiceNum = " + id + " AND InvoiceDate = #" + date + "# AND TotalCharge = " + total;
        }
        public static string getAllInvoiceIDs()
        {
            return "SELECT InvoiceNum FROM Invoices";
        }
        public static string getAllInvoiceTotals()
        {
            return "SELECT TotalCharge FROM Invoices";
        }
        #endregion
        #region InvoiceCommands
        public static string insertInvoice(string date, double total)
        {
            return "INSERT INTO Invoices(InvoiceDate,TotalCharge) VALUES (#" + date + "#," + total + ")";
        }
        public static string updateInvoice(int id, string date, double total)
        {
            return "UPDATE invoices SET InvoiceDate = #" + date + "#, TotalCharge = " + total + " WHERE InvoiceNum = " + id;
        }
        public static string deleteInvoice(int id)
        {
            return "DELETE FROM Invoices WHERE InvoiceNum = " + id;
        }
        #endregion
        #region Product
        public static string getAllProducts()
        {
            return "SELECT * FROM ItemDesc";
        }
        public static string checkProductExists(string s)
        {
            return "SELECT * FROM ItemDesc WHERE ItemCode = '" + s + "'";
        }
        public static string insertProduct(string ItemCode, string ItemDesc, string ItemCost)
        {
            return "INSERT INTO ItemDesc(ItemCode,ItemDesc,Cost) VALUES(" + "'"+ ItemCode +"', '" + ItemDesc + "', '" + ItemCost + "'" + ")";
        }
        public static string updateProductItemDesc(string ItemCode, string ItemDesc, string itemCost)
        {
            return "UPDATE ItemDesc SET ItemDesc = '" + ItemDesc + "', Cost = '" + itemCost + "' WHERE ItemCode = '" + ItemCode + "'";
        }
       
        public static string deleteProductLineItems(string itemCode)
        {
            return "DELETE * FROM LineItems WHERE ItemCode = '" + itemCode + "'";
        }
        public static string deleteProductItemDesc(string itemCode)
        {
            return "DELETE * FROM ItemDesc WHERE ItemCode = '" + itemCode + "'";
        }

        public static string getAllProductsInUse()
        {
            return "SELECT DISTINCT ItemCode FROM LineItems";
        }

        public static string getInvoiceIDsByProductCode(string itemCode)
        {
            return "SELECT DISTINCT InvoiceNum FROM LineItems WHERE ItemCode = '" + itemCode + "'";
        }
        #endregion
        #region LineItem

        public static string getLineItems()
        {
            return "SELECT * FROM LineItems";
        }
        public static string getLineItemsForInvoice(int invoiceId)
        {
            return "SELECT LI.InvoiceNum, LI.ItemCode, ID.ItemDesc, ID.Cost FROM LineItems LI INNER JOIN ItemDesc ID ON LI.ItemCode = ID.ItemCode  WHERE InvoiceNum = " + invoiceId;
        }
        public static string insertLineItem(int invoiceId, string ItemCode)
        {
            return "INSERT INTO LineItems(invoiceNum,ItemCode) VALUES (" + invoiceId  + ",'" + ItemCode + "')";
        }
        public static string removeLineItem(int lineNumber)
        {
            return "DELETEE FROM LineItems WHERE LineItemNumber = " + lineNumber;
        }
        public static string removeLineItems(int invoiceId)
        {
            return "DELETE FROM LineItems WHERE InvoiceNum = " + invoiceId;
        }
        #endregion
    }
}
