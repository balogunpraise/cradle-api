using Cradle.Domain.Entities.Common;

namespace Cradle.Domain.Entities
{
    public class BillingInfo : FullAuditedEntity
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string CardNumber { get; set; }
        public DateTime CardExpiration { get; set; }
        public string CVV { get; set; }
        public bool IsDefault { get; set; }
    }
}
