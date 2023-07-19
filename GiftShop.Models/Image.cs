namespace GiftShop.Models
{
    using System.ComponentModel.DataAnnotations;
    using static GiftShop.Common.ModelValidationConstants.Image;

    public class Image
    {
        
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(UrlMaxLenght)]
        public string ImageUrl { get; set; } = null!;


    }
}
