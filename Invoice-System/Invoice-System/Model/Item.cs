namespace Invoice_System.Model
{
    /// <summary>
    /// Item Class representing an Invoice Item from Database
    /// </summary>
    public class Item
    {
        public Item(char code, string desc, double cost)
        {
            ID = code;
            Description = desc;
            Cost = cost;
        }
        public int ID { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }

        public override string ToString()
        {
            return this.Description;
        }
    }
}
