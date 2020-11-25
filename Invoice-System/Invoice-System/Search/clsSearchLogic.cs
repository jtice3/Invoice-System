using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_System.Search
{
    public class clsSearchLogic
    {
        /// <summary>
        /// clsSearchSQL object used to pass values that are needed to query Invoice database.
        /// </summary>
        private clsSearchSQL clsSearchSQLManager;

        /// <summary>
        /// integer used to store a specific InvoiceNum value
        /// </summary>
        public int iInvoiceNum;

        /// <summary>
        /// DateTime used to store a specific InvoiceDate value
        /// </summary>
        public DateTime dateInvoiceDate;

        /// <summary>
        /// integer used to store a specific TotalCost value
        /// </summary>
        public int iTotalCost;

        /// <summary>
        /// IList of clsSearchLogic objects that represent a row in the Invoice table.
        /// </summary>
        public IList<clsSearchLogic> clsSearchLogicList;

        /// <summary>
        /// clsSearchLogic Constructor initializing the clsSearchSQLManager object.
        /// </summary>
        public clsSearchLogic()
        {
            clsSearchSQLManager = new clsSearchSQL();
        }

        /// <summary>
        /// clsSearchLogic Constructor initializing the iInvoiceNum, dateInvoiceDate, and iTotalCost values for a specific Invoice.
        /// </summary>
        /// <param name="tempInvoiceNum"></param>
        /// <param name="tempInvoiceDate"></param>
        /// <param name="tempTotalCost"></param>
        public clsSearchLogic(int tempInvoiceNum, DateTime tempInvoiceDate, int tempTotalCost)
        {
            // This method sets the clsSearchLogic object's iInvoiceNum, dateInvoiceDate, and iTotalCost on creation of a new clsSearchLogic object.
            iInvoiceNum = tempInvoiceNum;
            dateInvoiceDate = tempInvoiceDate;
            iTotalCost = tempTotalCost;
        }

        /// <summary>
        /// Method to reset values that will be used in the Search window to populate datagrid and comboboxes.
        /// </summary>
        public void refreshValues()
        {
            try
            {
                // Uses the clsSearchSQL object to query the whole Invoice table and return a dataset.
                // Uses the dataset to loop through and create a new clsSearchLogic object using the overloaded operator to set its attributes.
                // While looping through and creating objects, each object is added to a new clsSearchLogicList (IList<clsSearchLogic>) which is used to populate the Search window.
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                       MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method accepts an InvoiceNum which is used by the clsSearchSQL object to set the iInvoiceNum, dateInvoiceDate, and iTotalCost.
        /// </summary>
        /// <param name="tempInvoiceNum"></param>
        public void queryInvoiceNum(int tempInvoiceNum)
        {
            try
            {
                // This method will use the clsSearchSQL object's querySpecificInvoiceNum(int tempInvoiceNum) method and store it's returned Invoice in a dataset
                // This method will then use the dataset to create a new clsSearchLogicList and adding to it the clsSearchLogic object
                // This clsSearchLogic object contains the values of the Invoice that is in the dataset.
                // This will set the needed values to populate the Search window.
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                       MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Uses the clsSearchSQL object to query and return a dataset to create a new List used to populate the Search window.
        /// </summary>
        /// <param name="tempInvoiceDate"></param>
        /// <param name="tempTotalCost"></param>
        public void queryInvoices(DateTime tempInvoiceDate, int tempTotalCost)
        {
            try
            {
                // This method will use the clsSearchSQL object's queryByDateAndCost method to retrieve a dataset and create a new clsSearchLogicList.
                // This List is used to populate the Search window.
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                       MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Uses the clsSearchSQL object to query and return a dataset to create a new List used to populate the Search window.
        /// </summary>
        /// <param name="tempTotalCost"></param>
        public void queryInvoices(int tempTotalCost)
        {
            try
            {
                // This method will use the clsSearchSQL object's queryByCost method to retrieve a dataset and create a new clsSearchLogicList.
                // This List is used to populate the Search window.
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                       MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Uses the clsSearchSQL object to query and return a dataset to create a new List used to populate the Search window.
        /// </summary>
        /// <param name="tempInvoiceDate"></param>
        public void queryInvoices(DateTime tempInvoiceDate)
        {
            try
            {
                // This method will use the clsSearchSQL object's queryByDate method to retrieve a dataset and create a new clsSearchLogicList.
                // This List is used to populate the Search window.
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                       MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
