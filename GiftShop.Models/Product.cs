namespace GiftShop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static GiftShop.Common.ModelValidationConstants.Product;
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        [Required]
        [MaxLength(SizeMaxLenght)]
        public string Size { get; set; } = null!;

        public int Quantity { get; set; }

        [ForeignKey(nameof(ProductType))]
        public Guid ProductTypeId { get; set; }
        public ProductType Type { get; set; } = null!;

        public Guid YarnTypeId { get; set; }
        [ForeignKey(nameof(YarnTypeId))]
        public YarnType YarnType { get; set; } = null!;




    }
}
