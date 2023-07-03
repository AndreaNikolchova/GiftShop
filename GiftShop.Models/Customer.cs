
namespace GiftShop.Models
{
    using Microsoft.AspNetCore.Identity;
    public class Customer : IdentityUser<Guid>
    {

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;

    }
}
