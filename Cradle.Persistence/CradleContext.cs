using Cradle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Persistence
{
    public class CradleContext(DbContextOptions<CradleContext> options) : DbContext(options)
    {
        public DbSet<Course> Courses { get; set; }
    }
  
}
