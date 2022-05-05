using System;

namespace ApiWithMsSql.Entities
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
