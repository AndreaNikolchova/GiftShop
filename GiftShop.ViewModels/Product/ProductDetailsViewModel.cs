﻿namespace GiftShop.Web.ViewModels.Product
{
    public class ProductDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Price { get; set; } = null!;
        public string Size { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string YarnName { get; set; } = null!;


    }
}
