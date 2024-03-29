﻿using Cradle.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Domain.Entities
{
    public class Grade : FullAuditedEntity
    {
        public string CourseName { get; set; }
        public string Purpose { get; set; }
        public float Score { get; set; }
        public string StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student StudentFk { get; set; }
    }
}
