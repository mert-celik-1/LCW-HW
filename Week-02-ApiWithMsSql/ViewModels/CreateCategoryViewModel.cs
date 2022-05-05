using System.ComponentModel.DataAnnotations;

namespace ApiWithMsSql.ViewModels
{
    public class CreateCategoryViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}

