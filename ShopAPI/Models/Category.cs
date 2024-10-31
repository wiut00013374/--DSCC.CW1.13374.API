using System.ComponentModel.DataAnnotations;

namespace ShopAPI.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
