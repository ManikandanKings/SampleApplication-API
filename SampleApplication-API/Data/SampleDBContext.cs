using Microsoft.EntityFrameworkCore;
using SampleApplication_API.Models.Domain;

namespace SampleApplication_API.Data
{
    public class SampleDBContext:DbContext
    {
        public SampleDBContext(DbContextOptions opt) : base(opt)
        {
            
        }

        public DbSet<Region> Region { get; set; }
        public  DbSet<Walks> Walks { get; set; }

    }
}
