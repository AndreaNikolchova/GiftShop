namespace GiftShop.Web.ViewModels.Order
{
    using GiftShop.Web.ViewModels.Cart;
    using GiftShop.Web.ViewModels.Customer;
    using GiftShop.Web.ViewModels.DeliveryCompany;
    using GiftShop.Web.ViewModels.Packaging;
    using GiftShop.Web.ViewModels.Product;

    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public CartViewModel Cart { get; set; } = null!;
        public IEnumerable<ProductViewModel> Products { get; set; } = null!;
        
        public CustomerViewModel Customer { get; set; } = null!;
        public string Email  { get; set; } = null!;
        public decimal Sum { get; set; }
        public decimal DeliveryCompany{ get; set; }
        public IEnumerable<DeliveryCompanyViewModel> DeliveryCompanyNames { get; set; } 
        public decimal Packaging{ get; set; }
        public IEnumerable<PackagingViewModel> Packagings { get; set; } 
        public DateTime CreatedOn { get; set; }

    }
}
