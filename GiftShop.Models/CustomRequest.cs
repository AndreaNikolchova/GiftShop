namespace GiftShop.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CustomRequest
    {
        public CustomRequest()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid CustomProductId { get; set; }
        [ForeignKey(nameof(CustomProductId))]
        [Required]
        public CustomProduct CustomProduct { get; set; } = null!;
        [Required]
        public string UserId { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        [Required]
        public IdentityUser User { get; set; } = null!;

    }
}
