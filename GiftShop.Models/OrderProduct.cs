namespace GiftShop.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    public class OrderProduct
    {
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;


    }
}
