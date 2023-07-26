namespace GiftShop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid();
            this.Products = new List<Product>();
        }
        
        [Key]
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        public Guid DeliveryCompanyId { get; set; }

        [ForeignKey(nameof(DeliveryCompanyId))]
        public DeliveryCompany DeliveryCompany { get; set; } = null!;
        public IEnumerable<Product> Products { get; set; }
        public decimal Sum { get; set; }
        public Guid PackagingId { get; set; }
        [ForeignKey(nameof(PackagingId))]
        public Packaging Packaging { get; set; }
    }
}
