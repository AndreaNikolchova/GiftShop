namespace GiftShop.Services.Cart
{
    using GiftShop.Data;
    using GiftShop.Services.Cart.Contracts;
    using GiftShop.Web.ViewModels.Cart;
    using GiftShop.Web.ViewModels.Product;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class CartService : ICartService
    {
        public GiftShopDbContext dbContext { get; set; }

        public CartService(GiftShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<CartViewModel> GetCartInformationAsync(string userId)
        {
            var cart = await dbContext.Cart
                .FirstOrDefaultAsync(x => x.UserId == userId);
            if (cart == null)
            {
                var cartViewModel = new CartViewModel();
                return cartViewModel;
            }
            var thisUserCartProducts = await dbContext.Cart
                .Where(x => x.UserId == userId)
                .Select(x => x.CartProduct.Select(x=>x.Product))
                .FirstAsync();
              
            var products = thisUserCartProducts
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Price = p.Price.ToString(),
                    Size = p.Size,
                    AllQuantity = p.Quantity,
                    Description = p.Description,
                    Type = dbContext.ProductTypes
                    .Where(x => x.Id == p.ProductTypeId)
                    .Select(x => x.Name)
                    .First(),

                })
                .ToList();

            var productsForView = new HashSet<ProductViewModel>();

            var model = new CartViewModel()
            {
                Products = products,
                UserId = userId

            };
            return model;
        }
        public async Task RemoveProductFromCart(string userId, Guid productId)
        {
            var cart = await dbContext.Cart
                .Where(x => x.UserId == userId)
                .Select(x=>x.CartProduct)
                .FirstAsync();

            var cartProduct = cart
                .FirstOrDefault(x=>x.ProductId==productId);
            this.dbContext.CartProducts.Remove(cartProduct);
            await dbContext.SaveChangesAsync();
        }
    }
}
