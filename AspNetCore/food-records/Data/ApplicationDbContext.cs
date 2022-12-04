using food_records.Models;
using Microsoft.EntityFrameworkCore;

namespace food_records.Data 
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<FoodRecord> FoodRecords { get; set; }
    }
}