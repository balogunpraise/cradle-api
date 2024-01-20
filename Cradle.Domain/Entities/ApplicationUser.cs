using Cradle.Domain.Entities.LinkingEntities;

namespace Cradle.Domain.Entities
{
    public class ApplicationUser
    {
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
