namespace GiftShop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;

    public class Cart
    {
        public Cart()
        {
            this.CartProduct = new HashSet<CartProduct>();
        }
        [Key]
        public Guid Id { get; set; }

        public string UserId {get; set;}

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set;}
        public ICollection<CartProduct> CartProduct { get; set; }

    }
}
