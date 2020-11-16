using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_System.Search
{

    /// <summary>
    /// Class that handles the logic
    /// </summary>
    public class clsSearchLogic
    {
        /// <summary>
        /// Used to query the db
        /// </summary>
        private clsSearchSQL clsSQLManager;

        /// <summary>
        /// Invoice number
        /// </summary>
        public int iInvoiceNum;

        /// <summary>
        /// Invoice date
        /// </summary>
        public DateTime dateInvoiceDate;

        /// <summary>
        /// Invoice cost
        /// </summary>
        public int iTotalCost;


        /// <summary>
        /// Default Constructor
        /// </summary>
        public clsSearchLogic()
        {
            clsSQLManager = new clsSearchSQL();
        }

        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <param name="invoiceDate"></param>
        /// <param name="totalCost"></param>
        public clsSearchLogic(int invoiceNum, DateTime invoiceDate, int totalCost)
        {
            iInvoiceNum = invoiceNum;
            dateInvoiceDate = invoiceDate;
            iTotalCost = totalCost;
        }

        /// <summary>
        /// Setter used to add query to search window
        /// </summary>
        /// <param name="invoiceNum"></param>
        public void queryInvoiceNum(int invoiceNum)
        {
            ///TODO
        }

        /// <summary>
        /// Query the db for date and total cost and populates the search window
        /// </summary>
        /// <param name="invoiceDate"></param>
        /// <param name="totalCost"></param>
        public void queryInvoiceDateCost(DateTime invoiceDate, int totalCost)
        {
            ///TODO
        }

        /// <summary>
        /// Query the db for total cost and populate the search window
        /// </summary>
        /// <param name="totalCost"></param>
        public void queryInvoiceCost(int totalCost)
        {
            ///TODO
        }

        /// <summary>
        /// Query the db for date and populate the search window
        /// </summary>
        /// <param name="tempInvoiceDate"></param>
        public void queryInvoiceDate(DateTime tempInvoiceDate)
        {
            ///TODO
        }
    }
}