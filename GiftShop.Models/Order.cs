namespace GiftShop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid();
            this.IsDone = false;
            this.OrderProducts = new HashSet<OrderProduct>();
        }
        
        [Key]
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]  
        public Customer Customer { get; set; }
        public Guid DeliveryCompanyId { get; set; }

        [ForeignKey(nameof(DeliveryCompanyId))]
        public DeliveryCompany DeliveryCompany { get; set; } = null!;
        public decimal Sum { get; set; }
        public Guid PackagingId { get; set; }
        [ForeignKey(nameof(PackagingId))]
        public Packaging Packaging { get; set; }
        public bool IsDone { get; set; }
        public DateTime CreatedOn { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
