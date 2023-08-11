namespace GiftShop.Web.ViewModels.CustomProduct
{
    using GiftShop.Web.ViewModels.Customer;
    using GiftShop.Web.ViewModels.DeliveryCompany;
    using GiftShop.Web.ViewModels.Packaging;
    using System.ComponentModel.DataAnnotations;
    using static GiftShop.Common.ModelValidationConstants.Product;
    public class CustomRequestViewModel
    {
        public Guid ProductId { get; set; }
        public Guid RequestId { get; set; }
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        [Required]
        [MaxLength(SizeMaxLenght)]
        [MinLength(SizeMinLenght)]
        public string Size { get; set; } = null!;
        public int Quantity { get; set; }
        public string? EmailAddress { get; set; }
        public decimal Price { get; set; }
        public string Date { get; set; } = null!;

        public CustomerViewModel CustomerViewModel { get; set; } = null!;

        public IEnumerable<DeliveryCompanyViewModel> DeliveryCompaniesNames { get; set; }
        [Required(ErrorMessage = "Please select a delivery company.")]
        public decimal DeliveryCompany { get; set; }
        public IEnumerable<PackagingViewModel> PackagesNames { get; set; }
        public decimal Packaging { get; set; }
    }
}
