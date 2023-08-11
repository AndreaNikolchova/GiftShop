namespace GiftShop.Services.Tests
{
    using GiftShop.Data;
    using GiftShop.Models;
    using System;
    using System.Collections.Generic;

    public static class DatabaseSeeder
    {
        public static Cart Cart;
        public static CartProduct CartProduct;
        public static Product Product;
        public static void SeedDatabase(GiftShopDbContext dbContext)
        {
            Cart = new Cart()
            {
                Id = Guid.Parse("3a787d93-5a81-4bf8-b068-4c8227a1822e"),
                UserId = "3c63f6f4-4bae-45a1-8684-b0733c4907c3"
            };
            Product = new Product()
            {   
                Id = Guid.Parse("dd2c4893-8747-44c2-9471-885cb7b72df1"),
                Name = "TestName",
                Price = 1.00m,
                Description ="TestDescription",
                Size = "10cm",
                Quantity = 1
            };
            var cartProducts = new List<CartProduct>();

            CartProduct = new CartProduct()
            {
                CartId = Guid.Parse("3a787d93-5a81-4bf8-b068-4c8227a1822e"),
                ProductId = Guid.Parse("dd2c4893-8747-44c2-9471-885cb7b72df1")
            };
            cartProducts.Add(CartProduct);
            Cart.CartProduct = cartProducts;
            dbContext.Cart.Add(Cart);
            dbContext.SaveChanges();
        }

    }

}
