namespace Store.Model
{
    public class Item
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; } = 0;
        public decimal Price { get; set; }
    }
}
