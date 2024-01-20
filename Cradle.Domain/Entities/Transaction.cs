using Cradle.Domain.Entities.Account;
using Cradle.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cradle.Domain.Entities
{
    public class Transaction : FullAuditedEntity
    {
        public string TransRefrence { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsSuceeded { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser UserFk { get; set; }
        public int Amount { get; set; }
    }
}
