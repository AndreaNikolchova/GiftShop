namespace GiftShop.Models
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Image
    {
        //Fix
        [Key]
        public Guid Id { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
        public string? SavedUrl { get; set; }

        [NotMapped]
        public string SignedUrl { get; set; }
        public string? SavedFileName { get; set; }

    }
}
