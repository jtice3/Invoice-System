using Invoice_System.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Invoice_System
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        /// <summary>
        /// Object Used to pass information about selections to perform business logic.
        /// </summary>
        public clsSearchLogic clsSearchLogicManager;

        /// <summary>
        /// wndSearch Constructor initializes this screen and the clsSearchLogicManager object.
        /// </summary>
        public wndSearch()
        {
            InitializeComponent();
            clsSearchLogicManager = new clsSearchLogic();
        }

        /// <summary>
        /// Handles Errors that may occur
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                System.Windows.MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine + "HandleError Exception: " + e.Message);
            }
        }

        /// <summary>
        /// Selects the Invoice displays its information in the datagrid and comboboxes. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSelectInvoiceID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // If the change selected is not empty (changes when reopening the screen), this method will use the clsSearchLogicManager object to change its values that are used to populate the Search window.
                // This method will pass the InvoiceNum to the clsSearchLogicManager object's queryInvoiceNum method.
                // This method will then call the UpdateFields method to populate the datagrid and comboboxes appropriately.
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Limits the data shown in the datagrid to data that matches the selection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSelectDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // If the change selected is not empty, this method will use the clsSearchLogicManager object to change its values that are used to populate the Search window.
                // If there is already a Price selected, this method will pass the Date and Price to the clsSearchLogicManager object's queryInvoices method.
                // If there is only this new Date selected, this method will only pass the Date to the clsSearchLogicManager object's queryInvoices method (overloaded).
                // This method will then call the UpdateFields method to populate the datagrid and comboboxes appropriately.
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Limits the data shown in the datagrid to data that matches the selection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSelectPrice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // If the change selected is not empty, this method will use the clsSearchLogicManager object to change its values that are used to populate the Search window.
                // If there is already a Date selected, this method will pass the Date and Price to the clsSearchLogicManager object's queryInvoices method.
                // If there is only this new price selected, this method will only pass the Price to the clsSearchLogicManager object's queryInvoices method (overloaded).
                // This method will then call the UpdateFields method to populate the datagrid and comboboxes appropriately.
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Saves the selected Invoice information so the Main window will have access to it then closes the Search window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // If there is an invoice that is currently selected, clsSearchLogicManager object will store the Invoice information.
                // This will be done by calling the clsSearchLogicManager object's storeInfo(int InvoiceNum, DateTime InvoiceDate, int TotalCost) method.
                // InvoiceNum will be stored in an int iInvoiceNum,
                // InvoiceDate will be stored in a DateTime dateInvoiceDate,
                // and TotalCost will be stored in an int iTotalCost.
                // Because the clsSearchLogicManager object is public, this will make those values available to the Main window for its use.
                // The window will then be closed using the Hide method.
                this.Hide();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Exits the Search window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelSelection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // This method closes the Search window using the Hide method.
                this.Hide();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Clears the Search window and resets to its original state from the time the window was opened.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearSelection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // This method will be called to reset the Search window to its original state of when it was opened.
                // It will use the clsSearchLogicManager object to call refreshValues method.
                // Then it will call the UpdateFields method to populate the datagrid and comboboxes.
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Refreshes the screen items to portray accurate data and then displays the screen.
        /// </summary>
        /// <returns></returns>
        public bool? ShowDialogWithRefresh()
        {
            try
            {
                // This method will be called when showing the Search screen in order to refresh the datagrid and comboboxes to be accurate. 
                // The clsSearchLogicManager will call a refreshValues method which will run the logic needed to refresh the values for the screen including the list.
                // Then the class will update the datagrid and comboboxes with the values stored in the clsSearchLogicManager object by calling the UpdateFields method.
                // Finally, this method will run the ShowDialog method to show the screen.
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                        MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            return this.ShowDialog();
        }

        /// <summary>
        /// Uses the values stored in the clsSearchLogicManager object to populate the datagrid as well as the comboboxes.
        /// </summary>
        private void UpdateFields()
        {
            try
            {
                // This method is going to populate the Datagrid and comboboxes with the relevant information in the clsSearchLogicManager object.
                // It will use a list and its attributes to populate these items.
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                        MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
