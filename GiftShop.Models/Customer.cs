namespace GiftShop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;
    using static GiftShop.Common.ModelValidationConstants.Customer;
    public class Customer
    {
        public Customer()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public string UserId { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;
        [Required]
        [MaxLength(NameMaxLenght)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(NameMaxLenght)]
        public string LastName { get; set; } = null!;
        [Required]
        [MaxLength(AddressMaxLenght)]
        public string Address { get; set; } = null!;
        [Required]
        [MaxLength(AddressMaxLenght)]
        public string TownName { get; set; } = null!;

    }
}
