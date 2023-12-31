﻿namespace GiftShop.Web.ViewModels.CustomProduct
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static GiftShop.Common.ModelValidationConstants.Product;
    public class CustomProductViewModel
    {
        [Required]
        [MaxLength(NameMaxLenght)]
        [MinLength(NameMinLenght)]
        public string Name { get; set; } = null!;
        public IFormFile? Photo { get; set; }
        public string? ImageUrl { get; set; }
        public string? PhotoError { get; set; }

        public string? Description { get; set; }
        [Required]
        [MaxLength(SizeMaxLenght)]
        [MinLength(SizeMinLenght)]
        public string Size { get; set; } = null!;
        [Range(1,10)]
        public int Quantity { get; set; }

        public string? User { get; set; }
        public string? EmailAddress { get; set; }
    }
}
