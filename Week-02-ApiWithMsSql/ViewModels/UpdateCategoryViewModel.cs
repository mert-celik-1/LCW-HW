using System.ComponentModel.DataAnnotations;

namespace ApiWithMsSql.ViewModels
{
    public class UpdateCategoryViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
