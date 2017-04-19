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
        #endregion
        #region Product
        public static string getAllProducts()
        {
            return "SELECT * FROM ItemDesc";
        }
        public static string insertProduct(string ItemCode, string ItemDesc, double itemCost)
        {
            return "INSERT INTO itemDesc(ItemCode,ItemDesc,Cost) VALUES(" + ItemCode +"," + ItemDesc + "," + itemCost + ")";
        }
        public static string updateProduct(string ItemCode, string ItemDesc, double itemCost)
        {
            return "UPDATE itemDesc SET ItemDesc = '" + ItemDesc + "', Cost = " + itemCost + ")";
        }
        #endregion
        public static string getLineItems()
        {
            return "SELECT * FROM LineItems";
        }
        public static string getLineItemsForInvoice(int invoiceId)
        {
            return "SELECT * FROM LineItems WHERE InvoiceNum = " + invoiceId;
        }
        public static string insertLineItem(int invoiceId, string ItemCode, int LineNumber)
        {
            return "INSERT INTO LineItems(invoiceNum,LineItemNum,ItemCode) VALUES (" + invoiceId + "," + LineNumber + ",'" + ItemCode + "')";
        }
    }
}
