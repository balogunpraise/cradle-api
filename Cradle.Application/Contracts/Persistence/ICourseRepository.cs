﻿using Cradle.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Application.Contracts.Persistence
{
    public interface ICourseRepository : IAsyncRepository<Course>
    {
        Task<bool> IsCourseNameAndDurationUnique(string name, string duration);
    }
}
