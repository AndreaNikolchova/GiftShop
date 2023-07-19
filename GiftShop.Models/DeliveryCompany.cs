namespace GiftShop.Models
{
    using System.ComponentModel.DataAnnotations;
    using static GiftShop.Common.ModelValidationConstants.DeliveryCompany;
    public class DeliveryCompany
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; } = null!;
      
    }
}
