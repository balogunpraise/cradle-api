using Cradle.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cradle.Domain.Entities
{
    public class Schedule : FullAuditedEntity
    {
        public string Title { get; set; }
        public string Note { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset FinishTime { get; set; }
        public bool IsRecurrent { get; set; }
        public Guid CoachId { get; set; }

        [ForeignKey("CoachId")]
        public Coach CoachFk { get; set; }
    }
}
