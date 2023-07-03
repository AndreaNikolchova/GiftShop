namespace GiftShop.Models
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static GiftShop.Common.ModelValidationConstants.Product;
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; } = null!;

        [ForeignKey(nameof(Image))]
        public Guid ImageId { get; set; }
        public Image Images { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        public string? Description { get; set; }

        [Required]
        [MaxLength(SizeMaxLenght)]
        public string Size { get; set; } = null!;

        public int Count { get; set; }

        [ForeignKey(nameof(ProductType))]
        public int ProductTypeId { get; set; }
        public ProductType Type { get; set; } = null!;

        [ForeignKey(nameof(YarnType))]
        public int YarnTypeId { get; set; }
        public YarnType YarnType { get; set; }



    }
}
