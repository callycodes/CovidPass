using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace covidpassbackend.Models
{
    public partial class CovidPassContext : DbContext
    {
        public CovidPassContext()
        {
        }

        public CovidPassContext(DbContextOptions<CovidPassContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vaccine> Vaccines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=covidpass;Username=postgres;Password=password");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("tests");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateOfTest)
                    .HasColumnType("date")
                    .HasColumnName("dateOfTest");

                entity.Property(e => e.Result).HasColumnName("result");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.UserId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userId")
                    .HasPrincipalKey(p => p.Uid);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Uid, "users_uid_key")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "users_email_key")
                    .IsUnique();


                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("dateOfBirth");

                entity.Property(e => e.Password).HasColumnName("password");
                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.FirstName).HasColumnName("firstName");

                entity.Property(e => e.LastName).HasColumnName("lastName");

                entity.Property(e => e.Uid).HasColumnName("uid");
            });

            modelBuilder.Entity<Vaccine>(entity =>
            {
                entity.ToTable("vaccines");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.DateOfVaccine)
                    .HasColumnType("date")
                    .HasColumnName("dateOfVaccine");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.UserId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Vaccines)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userId")
                    .HasPrincipalKey(p => p.Uid);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
