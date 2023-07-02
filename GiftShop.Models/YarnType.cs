namespace GiftShop.Models
{
    using System.ComponentModel.DataAnnotations;
    public class YarnType
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
    }
}