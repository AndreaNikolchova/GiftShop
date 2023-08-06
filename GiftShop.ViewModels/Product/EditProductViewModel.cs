namespace GiftShop.Web.ViewModels.Product
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;
    using static GiftShop.Common.ModelValidationConstants.Product;
    public class EditProductViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        [MinLength(NameMinLenght)]
        public string Name { get; set; } = null!;
  
        public IFormFile? Photo { get; set; }
        public string? ImageUrl { get; set; } 
        public string? PhotoError { get; set; }
        [Required]
        [MaxLength(DescriptionMaxLenght)]
        [MinLength(DescriptionMinLenght)]
        public string Description { get; set; } = null!;
        [Required]
        [MaxLength(SizeMaxLenght)]
        [MinLength(SizeMinLenght)]
        public string Size { get; set; } = null!;
        [Range(1, 10)]
        public int Quantity { get; set; }
        [Required]
        public string Price { get; set; } = null!;
        [Required]
        public string Type { get; set; } = null!;
        public IEnumerable<string>? Types { get; set; }
        [Required]
        public string YarnType { get; set; } = null!;
    }
}
