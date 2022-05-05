namespace ApiWithMsSql.Entities
{
    public class Product:BaseEntity<string>
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
