using ApiWithMsSql.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApiWithMsSql.ViewModels
{
    public class ProductViewModel
    {
        
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
