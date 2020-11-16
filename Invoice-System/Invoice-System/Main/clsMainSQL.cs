using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Invoice_System.Model;

namespace Invoice_System.Main
{

    public class clsMainSQL
    {
        internal static clsMainSQL Instance { get; } = new clsMainSQL();

        public static clsMainSQL CreateInstance()
        {
            return Instance;
        }

        DataAccess DataAccess = DataAccess.Instance;

        DataSet DS;

        private clsMainSQL()
        {

        }

        public List<Item> GetAllItems()
        {
            List<Item> items = new List<Item>();


            string Sql = "SELECT * FROM ItemDesc";

            int retVal = 0;

            DS = DataAccess.ExecuteSql(Sql, ref retVal);

            foreach (DataRow dr in DS.Tables[0].Rows)
            {
                items.Add(new Item(System.Convert.ToChar(dr[0]), dr[1].ToString(), (float)System.Convert.ToDouble(dr[2])));
            }

            return items;

        }

        public Invoice GetInvoiceByID(int invoiceNum)
        {

            //Sql Statement
            string Sql = "SELECT * FROM Invoices WHERE InvoiceNum = " + invoiceNum;
            Invoice invoice = null;

            int retVal = 0;

            DS = DataAccess.ExecuteSql(Sql, ref retVal);
            //this should only pull one invoice
            DataRow dr = DS.Tables[0].Rows[0];

            invoice = new Invoice(System.Convert.ToInt32(dr[0]), (DateTime)dr[1]);


            return invoice;

        }

        public List<Item> GetItemsByInvoiceNum(int invoiceNum)
        {

            List<Item> items = new List<Item>();

            //Sql Statement
            string Sql = "SELECT ID.ItemCode, ID.ItemDesc, ID.Cost FROM ITemDesc ID " +
                "INNER JOIN LineItems LI ON ID.ItemCode = LI.ItemCode " +
                "WHERE LI.InvoiceNum = " + invoiceNum;

            int retVal = 0;

            DS = DataAccess.ExecuteSql(Sql, ref retVal);

            foreach (DataRow dr in DS.Tables[0].Rows)
            {
                items.Add(new Item(System.Convert.ToChar(dr[0]), dr[1].ToString(), (float)System.Convert.ToDouble(dr[2])));

            }
            return items;

        }


        public void UpdateInvoiceItems(Invoice invoice)
        {
            //Need to delete Lines from Invoice first, then update
            //Sql Statement
            string delete = "DELETE FROM LineItems WHERE InvoiceNum = " + invoice.Number;

            DataAccess.ExecuteNonQuery(delete);

            //Need to loop through Invoice items and add new rows
            int i = 1;// integer representing Line Item Number
            foreach (Item item in invoice.Items)
            {
                string Sql = "INSERT INTO LineItems(InvoiceNum, LineItemNum, ItemCode) VALUES ('"
                    + invoice.Number + "', '" + i + "', '" + item.ID + "')";
                DataAccess.ExecuteNonQuery(Sql);
                i++;//increment LineItemNumber
            }

        }

        public void UpdateDate(Invoice invoice)
        {

            //SQl Statement
            string Sql = "UPDATE Invoices SET Date = " + "#" + invoice.Date + "#" + " WHERE InvoiceNum = " + invoice.Number;
            DataAccess.ExecuteNonQuery(Sql);

        }

        public int InsertNewInvoice(Invoice newInvoice)
        {
            //Insert new Invoice first
            string Sql = "INSERT INTO Invoices(Date, TotalCost) VALUES('" + newInvoice.Date + "', '" + newInvoice.TotalCost + "')";

            DataAccess.ExecuteNonQuery(Sql);

            //Get that Invoice Number
            Sql = "SELECT TOP 1 InvoiceNum FROM Invoices ORDER BY InvoiceNum DESC";
            int retVal = 0;
            DS = DataAccess.ExecuteSql(Sql, ref retVal);
            int invoiceNum = System.Convert.ToInt32(DS.Tables[0].Rows[0][0]);

            //insert Line items
            int i = 1;//line item number
            foreach (Item item in newInvoice.Items)
            {
                Sql = "INSERT INTO LineItems(InvoiceNum, LineItemNum, ItemCode) VALUES('" + invoiceNum + "', '" + i + "', '" + item.ID + "')";
                DataAccess.ExecuteNonQuery(Sql);
                i++;

            }

            return invoiceNum;

        }
        public void DeleteInvoice(Invoice invoice)
        {

            //need to delete from Line Items first
            //Sql statement
            string Sql = "DELETE FROM LineItems WHERE InvoiceNum = " + invoice.Number;
            DataAccess.ExecuteNonQuery(Sql);

            //delete from Invoices
            Sql = "DELETE FROM Invoices WHERE InvoiceNum = " + invoice.Number;
            DataAccess.ExecuteNonQuery(Sql);
        }
    }
}