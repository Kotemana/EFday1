using Microsoft.EntityFrameworkCore;


namespace EFday1
{
    public class BookingDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Operation> Operations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"data source=DESKTOP-IAGJLVQ\SQLEXPRESS;Initial Catalog=PersonalBooking;Integrated Security=True;");
        }
    }
}
