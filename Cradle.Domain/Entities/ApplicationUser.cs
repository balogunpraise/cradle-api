using Cradle.Domain.Entities.LinkingEntities;

namespace Cradle.Domain.Entities
{
    public class ApplicationUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsSubscribed { get; set; }
        public bool IsStudent { get; set; }
        public virtual ICollection<UserCourse> Courses { get; set; }
        public virtual ICollection<UserAssignment> Assignments { get; set; }
        public ICollection<InternalMessage> Messages { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<BillingInfo> BillingInfos { get; set; }
        public ApplicationUser()
        {
            Assignments = new List<UserAssignment>();
            Messages = new List<InternalMessage>();
            Transactions = new List<Transaction>();
            Courses = new List<UserCourse>();
            BillingInfos = new List<BillingInfo>();
        }
    }
}
