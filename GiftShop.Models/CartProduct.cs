namespace GiftShop.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    public class CartProduct
    {
        public Guid CartId { get; set; }
        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; } = null!;
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}
