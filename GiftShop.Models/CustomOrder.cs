namespace GiftShop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class CustomOrder
    {
        public CustomOrder()
        {
            this.Id = Guid.NewGuid();
            this.IsDone = false;
        }
        [Key]
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; } = null!;
        public Guid ProduductId { get; set; }
        [ForeignKey(nameof(ProduductId))]
        public CustomProduct Product { get; set; } = null!;
        public Guid DeliveryCompanyId { get; set; }
        [ForeignKey(nameof(DeliveryCompanyId))]
        public DeliveryCompany DeliveryCompany { get; set; } = null!;
        public Guid PackagingId { get; set; }
        [ForeignKey(nameof(PackagingId))]
        public Packaging Packaging { get; set; } = null!;
        public decimal Sum { get; set; }
        public bool IsDone { get; set; }    
        public DateTime CreatedOn { get; set; }
    }
}
