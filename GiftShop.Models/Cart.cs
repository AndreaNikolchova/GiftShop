namespace GiftShop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Cart
    {
        public Cart()
        {
            this.Products = new HashSet<Product>();
        }
        [Key]
        public Guid Id { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
