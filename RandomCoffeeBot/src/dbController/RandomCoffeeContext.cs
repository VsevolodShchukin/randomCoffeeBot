using Microsoft.EntityFrameworkCore;

namespace RandomCoffeeBot.dbController;

public partial class RandomCoffeeContext : DbContext
{
    public RandomCoffeeContext()
    {
    }

    public RandomCoffeeContext(DbContextOptions<RandomCoffeeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User>? Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=C:\\\\\\\\Users\\v_pike\\RiderProjects\\RandomCoffeeBot\\randomCoffee.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Attempts).HasDefaultValueSql("0");
            entity.Property(e => e.Password).HasDefaultValueSql("SPD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
