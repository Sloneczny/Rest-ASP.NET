using Microsoft.EntityFrameworkCore;

namespace webAPIrest.Entieties

{
    public class RestaurantDbContext : DbContext
    {
        private string _connectionSQL = "Server=BARTEK\\SQLEXPERS;Database=RestaurantDb;Trusted_Connection=True;";

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        
        // wymagania do tabel bazy danych
        //property 
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Address>()
                .Property(a => a.Street)
                .IsRequired();

            modelBuilder.Entity<Dish>()
                .Property(d => d.Name)
                .IsRequired();

             

                
            

                
        }
        // konfiguracja bazy danych i połączenie
        //configurate and conectionn data base
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(_connectionSQL);
        }

        //migracja w NuGet add-migration nazwa
        //tworzenie bazy update-database
    }
}
