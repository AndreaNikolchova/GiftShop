namespace GiftShop.Web.ViewModels.Order
{
    using GiftShop.Web.ViewModels.Cart;
    using GiftShop.Web.ViewModels.Customer;
    using GiftShop.Web.ViewModels.DeliveryCompany;
    using GiftShop.Web.ViewModels.Packaging;

    public class OrderViewModel
    {
        public CartViewModel Cart { get; set; } = null!;
        public CustomerViewModel Customer { get; set; } = null!;
        public decimal Sum { get; set; }
        public string DeliveryCompanyName { get; set; } = null!;
        public IEnumerable<DeliveryCompanyViewModel> DeliveryCompanyNames { get; set; } = null!;
        public string PackagingName { get; set; }
        public IEnumerable<PackagingViewModel> Packagings { get; set; } = null!;

    }
}
