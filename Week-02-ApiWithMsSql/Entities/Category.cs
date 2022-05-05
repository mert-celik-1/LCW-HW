using System.Collections.Generic;

namespace ApiWithMsSql.Entities
{
    public class Category:BaseEntity<string>
    {
        public ICollection<Product> Products { get; set; }
    }
}
