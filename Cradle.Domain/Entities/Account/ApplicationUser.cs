using Microsoft.AspNetCore.Identity;

namespace Cradle.Domain.Entities.Account
{
    public class ApplicationUser : IdentityUser
    {
        public string TenantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsSubscribed { get; set; }
        public bool IsStudent { get; set; }
        public ICollection<InternalMessage> Messages { get; set; }
        public ICollection<BillingInfo> BillingInfos { get; set; }
        public ApplicationUser()
        {
            Messages = new List<InternalMessage>();
            BillingInfos = new List<BillingInfo>();
        }
    }
}
