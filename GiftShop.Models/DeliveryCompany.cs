namespace GiftShop.Models
{
    using System.ComponentModel.DataAnnotations;
    public class DeliveryCompany
    {
        [Key]
        public int Id { get; set; }
        [Required]
        //Add max lenght
        public string Name { get; set; } = null!;
      
    }
}
