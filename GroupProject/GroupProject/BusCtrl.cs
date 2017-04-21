using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace GroupProject
{
    public static class BusCtrl
    {
        /// <summary>
        /// Static data access to access db
        /// </summary>
        private static DataAccess dataAccess = new DataAccess();


        #region Product Methods
        //--------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------Begin Product Methods------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Adds a product.
        /// </summary>
        /// <param name="sItemCode">The item code</param>
        /// <param name="sItemDesc">The item description</param>
        /// <param name="sCost">The item cost</param>
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

        /// <summary>
        /// Gets all products codes attached to an invoice.
        /// </summary>
        /// <returns>A List of product codes</returns>
        public static List<string> getAllProductsInUse()
        {
            int numRows = 0;
            DataSet ds = dataAccess.ExecuteSQLStatement(SQLStrings.getAllProductsInUse(), ref numRows);

            List<string> list = new List<string>();

            for (int i = 0; i < numRows; i++)
            {
                string itemCode = ds.Tables[0].Rows[i][0].ToString();
                list.Add(itemCode);
            }

            return list;
        }

        /// <summary>
        /// Gets all invoice numbers for a given product code.
        /// </summary>
        /// <param name="productCode">The product code</param>
        /// <returns>A List of invoice numbers</returns>
        public static List<int> getAllInvoiceIDsByProduct(string productCode)
        {
            int numRows = 0;
            DataSet ds = dataAccess.ExecuteSQLStatement(SQLStrings.getInvoiceIDsByProductCode(productCode), ref numRows);

            List<int> list = new List<int>();

            for (int i = 0; i < numRows; i++)
            {
                int invoiceNum = Int32.Parse(ds.Tables[0].Rows[i][0].ToString());
                list.Add(invoiceNum);
            }

            return list;
        }

        //--------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------End Product Methods-------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------
        #endregion


        #region Search Methods
        //--------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------Begin Search Methods-------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets a DataSet of all invoices based on the search filters.
        /// </summary>
        /// <param name="id">Invoice ID.</param>
        /// <param name="date">Invoice Date.</param>
        /// <param name="total">Invoice Total.</param>
        /// <returns>A DataSet of all invoices based on the search filters.</returns>
        public static DataSet getInvoiceList(int id, DateTime? date, double total)
        {
            try
            {
                int numRows = 0;
                string query = "";
                if (id == -1)
                {
                    if (date == null)
                    {
                        if (total == -1.0)      //no id, no date, no total
                        {
                            query = SQLStrings.getAllInvoices();
                        }
                        else                    //no id, no date, total
                        {
                            query = SQLStrings.getInvoicesForTotal(total);
                        }
                    }
                    else
                    {
                        if (total == -1.0)      //no id, date, no total
                        {
                            query = SQLStrings.getInvoiceForDate(((DateTime)date).ToShortDateString());
                        }
                        else                    //no id, date, total
                        {
                            query = SQLStrings.getInvoice(((DateTime)date).ToShortDateString(), total);
                        }
                    }
                }
                else
                {
                    if (date == null)
                    {
                        if (total == -1.0)      //id, no date, no total
                        {
                            query = SQLStrings.getInvoiceForId(id);
                        }
                        else                    //id, no date, total
                        {
                            query = SQLStrings.getInvoiceByIDTotal(id, total);
                        }
                    }
                    else
                    {
                        if (total == -1.0)      //id, date, no total
                        {
                            query = SQLStrings.getInvoiceByIDDate(id, ((DateTime)date).ToShortDateString());
                        }
                        else                    //id, date, total
                        {
                            query = SQLStrings.getInvoiceByIDDateTotal(id, ((DateTime)date).ToShortDateString(), total);
                        }
                    }
                }

                return dataAccess.ExecuteSQLStatement(query, ref numRows);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Gets a list of all invoice IDs.
        /// </summary>
        /// <returns>A list of all invoice IDs.</returns>
        public static BindingList<int> getInvoiceIDs()
        {
            try
            {
                int numRows = 0;

                DataSet ds = dataAccess.ExecuteSQLStatement(SQLStrings.getAllInvoiceIDs(), ref numRows);

                BindingList<int> list = new BindingList<int>();

                for (int i = 0; i < numRows; i++)
                {
                    int id = Int32.Parse(ds.Tables[0].Rows[i][0].ToString());
                    list.Add(id);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Gets a list of all invoice totals.
        /// </summary>
        /// <returns>A list of all invoice totals.</returns>
        public static BindingList<double> getInvoiceTotals()
        {
            try
            {
                int numRows = 0;

                DataSet ds = dataAccess.ExecuteSQLStatement(SQLStrings.getAllInvoiceTotals(), ref numRows);

                BindingList<double> list = new BindingList<double>();

                for (int i = 0; i < numRows; i++)
                {
                    double total = Double.Parse(ds.Tables[0].Rows[i][0].ToString());
                    list.Add(total);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------End Search Methods---------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------
        #endregion


        #region Main Window Methods
        //--------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------Begin Main Window Methods-----------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------

        public static Invoice getInvoiceByID(int id)
        {
            try
            {
                int numRows = 0;
                DataSet ds = dataAccess.ExecuteSQLStatement(SQLStrings.getInvoiceForId(id),ref numRows);
                if (numRows > 1)
                    throw new Exception("Query returns multiple invoices for id " + id);
                Invoice invoice = new Invoice();
                invoice.ID = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                invoice.Date = DateTime.Parse(ds.Tables[0].Rows[0][1].ToString());
                DataSet invoiceProducts = dataAccess.ExecuteSQLStatement(SQLStrings.getLineItemsForInvoice(id), ref numRows);
                if(numRows == 0) //no products on invoice
                {
                    return invoice;
                }
                List<Product> products = new List<Product>();
                double totalCost = 0;
                foreach(DataRow row in invoiceProducts.Tables[0].Rows)
                {
                    Product product = new Product();
                    product.ProductCode = row[1].ToString();
                    product.ProductDescription = row[2].ToString();
                    product.ProductCost = double.Parse(row[3].ToString());
                    product.inDB = true;
                    totalCost += product.ProductCost;
                    products.Add(product);
                }
                invoice.products = products;
                return invoice;
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + ":" +
                        MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        public static void updateInvoice(Invoice i, List<Product> invoiceProducts)
        {
            double invoiceTotal = 0;
            foreach(Product product in invoiceProducts)
            {
                invoiceTotal += product.ProductCost;
                if(!product.inDB)
                    dataAccess.ExecuteNonQuery(SQLStrings.insertLineItem(i.ID, product.ProductCode));
            }
            dataAccess.ExecuteNonQuery(SQLStrings.updateInvoice(i.ID, i.Date.ToShortDateString(), invoiceTotal));
        }

        public static int addInvoice(DateTime date, List<Product> prodList)
        {
            double invoiceTotal = 0;
            foreach(Product p in prodList)
            {
                invoiceTotal += p.ProductCost;
            }
            dataAccess.ExecuteNonQuery(SQLStrings.insertInvoice(date.ToShortDateString(), invoiceTotal));
            int newId = int.Parse(dataAccess.ExecuteScalarSQL(SQLStrings.getInvoice(date.ToShortDateString(),invoiceTotal)));
            foreach(Product p in prodList)
            {
                dataAccess.ExecuteNonQuery(SQLStrings.insertLineItem(newId, p.ProductCode));
            }
            return newId;
        }

        public static void deleteInvoice(int id)
        {
            dataAccess.ExecuteNonQuery(SQLStrings.removeLineItems(id));
            dataAccess.ExecuteNonQuery(SQLStrings.deleteInvoice(id));
        }

        public static List<Product> getProductList()
        {
            int numRows = 0;
            DataSet ds = dataAccess.ExecuteSQLStatement(SQLStrings.getAllProducts(), ref numRows);
            if (numRows == 0)
                return null;
            List<Product> products = new List<Product>();
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                Product p = new Product();
                p.ProductCode = row[0].ToString();
                p.ProductDescription = row[1].ToString();
                p.ProductCost = double.Parse(row[2].ToString());
                products.Add(p);
            }
            return products;
        }

        //--------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------End Main Window Methods------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------
        #endregion
    }
}

        
