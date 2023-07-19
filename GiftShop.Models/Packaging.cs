namespace GiftShop.Models
{
    using System.ComponentModel.DataAnnotations;
    using static GiftShop.Common.ModelValidationConstants.Packaging;
    public class Packaging
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; } = null!;

        [Required]

        public decimal Price { get; set; }

    }
}
