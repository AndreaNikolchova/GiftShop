namespace GiftShop.Models
{
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

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int DeliveryCompanyId { get; set; }
        public IEnumerable<Product> Products { get; set; }

        public decimal Sum { get; set; }
    }
}
