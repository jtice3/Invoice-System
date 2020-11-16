using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Invoice_System.Model;

namespace Invoice_System.Search
{

    /// <summary>
    /// Class used to query the DB
    /// </summary>
    public class clsSearchSQL
    {
        /// <summary>
        /// DataAccess will be used to access the db
        /// </summary>
        private DataAccess db;

        /// <summary>
        /// SQL string
        /// </summary>
        private string sSQL;

        /// <summary>
        /// Constructor
        /// </summary>
        public clsSearchSQL()
        {
            db = new DataAccess();
        }

        /// <summary>
        /// Returns query
        /// </summary>
        /// <returns></returns>
        public DataSet queryInvoiceTable()
        {
            ///Int variable
            int iNum = 0;
            sSQL = "SELECT * FROM Invoices";
            return db.ExecuteSql(sSQL, ref iNum);
        }

        /// <summary>
        /// Returns a query by invoice number
        /// </summary>
        /// <param name="tempInvoiceNum"></param>
        /// <returns></returns>
        public DataSet querySpecificInvoiceNum(int tempInvoiceNum)
        {
            ///Int variable
            int iNum = 0;
            sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + tempInvoiceNum;
            return db.ExecuteSql(sSQL, ref iNum);
        }

        /// <summary>
        /// Returns a query by date
        /// </summary>
        /// <param name="tempInvoiceDate"></param>
        /// <returns></returns>
        public DataSet queryByDate(DateTime tempInvoiceDate)
        {
            ///Int variable
            int iNum = 0;
            sSQL = "SELECT * FROM Invoices WHERE InvoiceDate = #" + tempInvoiceDate.Date + "#";
            return db.ExecuteSql(sSQL, ref iNum);
        }

        /// <summary>
        /// Returns a query by cost
        /// </summary>
        /// <param name="tempTotalCost"></param>
        /// <returns></returns>
        public DataSet queryByCost(int tempTotalCost)
        {
            ///Int Variable
            int iRetVal = 0;
            sSQL = "SELECT * FROM Invoices WHERE TotalCost = " + tempTotalCost;
            return db.ExecuteSql(sSQL, ref iRetVal);
        }

        /// <summary>
        /// Returns a query by date and cost
        /// </summary>
        /// <param name="tempInvoiceDate"></param>
        /// <param name="tempTotalCost"></param>
        /// <returns></returns>
        public DataSet queryByDateAndCost(DateTime tempInvoiceDate, int tempTotalCost)
        {
            ///Int variable
            int iNum = 0;
            sSQL = "SELECT * FROM Invoices WHERE TotalCost = " + tempTotalCost + " and InvoiceDate = #" + tempInvoiceDate.Date + "#";
            return db.ExecuteSql(sSQL, ref iNum);
        }
    }
}
