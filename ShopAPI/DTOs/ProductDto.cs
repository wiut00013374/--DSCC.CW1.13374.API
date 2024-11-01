using System.ComponentModel.DataAnnotations;

namespace ShopAPI.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [Range(0.01, 10000.00)]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
