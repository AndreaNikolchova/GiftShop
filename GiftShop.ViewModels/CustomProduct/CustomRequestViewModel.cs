namespace GiftShop.Web.ViewModels.CustomProduct
{
    using System.ComponentModel.DataAnnotations;
    using static GiftShop.Common.ModelValidationConstants.Product;
    public class CustomRequestViewModel
    {
        public Guid ProductId { get; set; }
        public Guid RequestId { get; set; }
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        [Required]
        [MaxLength(SizeMaxLenght)]
        [MinLength(SizeMinLenght)]
        public string Size { get; set; } = null!;
        public int Quantity { get; set; }
        public string? EmailAddress { get; set; }
        public string Price { get; set; } = null!;
        public string Date { get; set; } = null!;

    }
}
