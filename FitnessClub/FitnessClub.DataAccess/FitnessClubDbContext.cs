using FitnessClub.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FitnessClub.DataAccess;

public class FitnessClubDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ClubEntity> Clubs { get; set; }
    public DbSet<TrainerEntity> Trainers { get; set; }

    public FitnessClubDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("user_claims");
        modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("user_logins").HasNoKey();
        modelBuilder.Entity<IdentityUserToken<int>>().ToTable("user_tokens").HasNoKey();;
        modelBuilder.Entity<UserRoleEntity>().ToTable("user_roles");
        modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("user_role_claims");
        modelBuilder.Entity<IdentityUserRole<int>>().ToTable("user_role_owners").HasNoKey();
        
        modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<UserEntity>().HasOne(x => x.Club)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.ClubId);

        modelBuilder.Entity<ClubEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<ClubEntity>().HasIndex(x => x.ExternalId).IsUnique();

        modelBuilder.Entity<TrainerEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<TrainerEntity>().HasIndex(x => x.ExternalId).IsUnique();
    }
}