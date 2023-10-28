using FitnessClub.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessClub.DataAccess;

public class FitnessClubDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ClubEntity> Clubs { get; set; }
    
    public FitnessClubDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.ExternalId).IsUnique();
        
        modelBuilder.Entity<ClubEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<ClubEntity>().HasIndex(x => x.ExternalId).IsUnique();
    }
}