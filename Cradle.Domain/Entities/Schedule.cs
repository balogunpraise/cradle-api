using Cradle.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cradle.Domain.Entities
{
    public class Schedule : FullAuditedEntity
    {
        public string Title { get; set; }
        public string Note { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public bool IsRecurrent { get; set; }
        public string CoachId { get; set; }

        [ForeignKey("CoachId")]
        public Coach CoachFk { get; set; }
    }
}
