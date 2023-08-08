using System.ComponentModel.DataAnnotations;

namespace GiftShop.Web.ViewModels.Product
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string ImageUrl { get; set; } = null!;
        public int Quantity { get; set; }
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public string Size { get; set; } = null!;
        [Required]
        public string Price { get; set; } = null!;
        [Required]
        public string Type { get; set; } = null!;
    }
}
