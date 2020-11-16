using System;
using System.Collections.Generic;

namespace Invoice_System.Model
{

    public class Invoice
    {

        public Invoice()
        {
            this.Items = new List<Item>();
            Date = DateTime.Now.Date;
        }
        public Invoice(int num, DateTime date)
        {
            Number = num;
            Date = date;
            Items = new List<Item>();
        }
        public int? Number { get; set; }
        public DateTime Date { get; set; }

        public List<Item> Items { get; set; }

        public double TotalCost
        {
            get
            {
                double total = 0;
                foreach (Item item in Items)
                {
                    total += item.Cost;
                }

                return total;
            }

        }
    }
}
