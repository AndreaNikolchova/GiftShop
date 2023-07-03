namespace GiftShop.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Order
    {
        public Order()
        {
            this.Products = new List<Product>();
        }
        [Key]
        public Guid Id { get; set; }
        public string Address { get; set; }

        public int DeliveryCompanyId { get; set; }
        public IEnumerable<Product> Products { get; set; }

        [ForeignKey(nameof(IdentityUser))]
        public int BuyerId { get; set; }
        public IdentityUser Buyer { get; set; }

        public decimal Sum { get; set; }
    }
}
