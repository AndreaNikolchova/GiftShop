namespace GiftShop.Web.ViewModels.Order
{
    using GiftShop.Web.ViewModels.Customer;
    using GiftShop.Web.ViewModels.CustomProduct;
    using GiftShop.Web.ViewModels.DeliveryCompany;
    using GiftShop.Web.ViewModels.Packaging;
    public class CustomOrderViewModel
    {
        public Guid Id { get; set; }
        public CustomerViewModel Customer { get; set; } = null!;
        public Guid DeliveryCompanyId { get; set; }

        public DeliveryCompanyViewModel DeliveryCompany { get; set; } = null!;
        public CustomProductViewModel Product { get; set; } = null!;
        public decimal Sum { get; set; }
        public DateTime CreatedOn { get; set; }
        public PackagingViewModel Packaging { get; set; } = null!;
    }
}
