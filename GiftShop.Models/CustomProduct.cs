namespace GiftShop.Models
{
    using System.ComponentModel.DataAnnotations;
    using static GiftShop.Common.ModelValidationConstants.Product;
    public class CustomProduct
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public string? ImageId { get; set; }

        [Required]
        [MaxLength(SizeMaxLenght)]

        public string Size { get; set; } = null!;

        public int Quantity { get; set; }

    }
}
