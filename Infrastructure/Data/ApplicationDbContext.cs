
using Microsoft.EntityFrameworkCore;
using Domain.Entity;
using System.Reflection.Metadata;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public int? CurrentUserId { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
  
        public DbSet<User> User { get; set; }
        public DbSet<Export> Exportexcel_histo { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

        public DbSet<UserTask> UserTask { get; set; }

        public DbSet<Project> Project { get; set; }
        public DbSet<Leaves> Leaves { get; set; }
        public DbSet<Tasks> Tasks { get; set; }

        public DbSet<Tblparametre> Tblparametres { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique()
            .HasDatabaseName("username");
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Tblparametre>(entity =>
            {
                entity.HasKey(e => new { e.CleParam, e.TypeParam })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("tblparametres");




                entity.Property(e => e.CleParam)
                    .HasMaxLength(30)
                    .HasColumnName("CLE_PARAM");

                entity.Property(e => e.TypeParam)
                    .HasMaxLength(30)
                    .HasColumnName("TYPE_PARAM");

                entity.Property(e => e.LibelleParam1)
                    .HasMaxLength(200)
                    .HasColumnName("LIBELLE_PARAM1");

                entity.Property(e => e.LibelleParam10)
                    .HasMaxLength(200)
                    .HasColumnName("LIBELLE_PARAM10");

                entity.Property(e => e.LibelleParam2)
                    .HasMaxLength(200)
                    .HasColumnName("LIBELLE_PARAM2");

                entity.Property(e => e.LibelleParam3)
                    .HasMaxLength(200)
                    .HasColumnName("LIBELLE_PARAM3");

                entity.Property(e => e.LibelleParam4)
                    .HasMaxLength(200)
                    .HasColumnName("LIBELLE_PARAM4");

                entity.Property(e => e.LibelleParam5)
                    .HasMaxLength(200)
                    .HasColumnName("LIBELLE_PARAM5");

                entity.Property(e => e.LibelleParam6)
                    .HasMaxLength(200)
                    .HasColumnName("LIBELLE_PARAM6");

                entity.Property(e => e.LibelleParam7)
                    .HasMaxLength(200)
                    .HasColumnName("LIBELLE_PARAM7");

                entity.Property(e => e.LibelleParam8)
                    .HasMaxLength(200)
                    .HasColumnName("LIBELLE_PARAM8");

                entity.Property(e => e.LibelleParam9)
                    .HasMaxLength(200)
                    .HasColumnName("LIBELLE_PARAM9");

                entity.Property(e => e.Param1)
                    .HasMaxLength(100)
                    .HasColumnName("PARAM1");

                entity.Property(e => e.Param10)
                    .HasMaxLength(100)
                    .HasColumnName("PARAM10");

                entity.Property(e => e.Param2)
                    .HasMaxLength(100)
                    .HasColumnName("PARAM2");

                entity.Property(e => e.Param3)
                    .HasMaxLength(100)
                    .HasColumnName("PARAM3");

                entity.Property(e => e.Param4)
                    .HasMaxLength(100)
                    .HasColumnName("PARAM4");

                entity.Property(e => e.Param5)
                    .HasMaxLength(100)
                    .HasColumnName("PARAM5");

                entity.Property(e => e.Param6)
                    .HasMaxLength(100)
                    .HasColumnName("PARAM6");

                entity.Property(e => e.Param7)
                    .HasMaxLength(100)
                    .HasColumnName("PARAM7");

                entity.Property(e => e.Param8)
                    .HasMaxLength(100)
                    .HasColumnName("PARAM8");

                entity.Property(e => e.Param9)
                    .HasMaxLength(100)
                    .HasColumnName("PARAM9");
            });


        }
        public override int SaveChanges()
        {
            var userId = CurrentUserId ?? 0;
           
            return base.SaveChanges();
        }




        //private void ExcludeProperty()
        //{
        //    foreach (var entry in ChangeTracker.Entries<UserTask>())
        //    {
        //        if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.State == EntityState.Deleted)
        //        {
        //            entry.Property(e => e.isLeave).IsModified = false;
        //        }
        //    }
        //}

      


    }
}
