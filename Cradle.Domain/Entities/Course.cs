using Cradle.Domain.Entities.Common;
using Cradle.Domain.Entities.LinkingEntities;

namespace Cradle.Domain.Entities
{
    public class Course : FullAuditedEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        //public DateTime? DateRegistered { get; set; }
        public decimal Price { get; set; }
        public string Difficulty { get; set; }
        public string ImageUrl { get; set; }
        //public DateTime? ExpiryDate { get; set; }
        public virtual ICollection<UserCourse> Students { get; set; }

        public Course()
        {
            Students = new List<UserCourse>();
        }
    }
}
