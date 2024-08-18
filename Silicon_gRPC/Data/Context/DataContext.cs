using Microsoft.EntityFrameworkCore;

namespace Silicon_gRPC.Data.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<SubscribeRequest> Subscribers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SubscribeRequest>().HasKey(x => x.Email);
    }
}
