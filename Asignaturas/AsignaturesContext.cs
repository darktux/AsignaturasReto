using Asignatura.Models;
using Asignaturas.Models;
using Microsoft.EntityFrameworkCore;

namespace Asignaturas
{
    public class AsignaturesContext : DbContext
    {
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Asignature> Asignature { get; set; }
        public DbSet<AsignatureUser> AsignatureUser { get; set; }

        public AsignaturesContext(DbContextOptions<AsignaturesContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.User>(user =>
            {
                user.ToTable("User");
                user.HasKey(x => x.UserId);
                user.Property(x => x.Name).IsRequired().HasMaxLength(50);
                user.Property(x => x.Email).IsRequired().HasMaxLength(100);
                user.Property(x => x.IdentificationType);
                user.Property(x => x.IdentificationNumber);
                user.Property(x => x.CreationDate);
            });

            modelBuilder.Entity<Asignature>(asignature =>
            {
                asignature.ToTable("Asignature");
                asignature.HasKey(x => x.AsignatureId);
                //asignature.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
                asignature.Property(x => x.NameAsignature).IsRequired().HasMaxLength(50);
                asignature.Property(x => x.AreaTypes);
                asignature.Property(x => x.CreationDate);
                asignature.Ignore(x => x.Detail);
            });

            modelBuilder.Entity<AsignatureUser>(asignatureUser =>
            {
                asignatureUser.ToTable("AsignatureUser");
                asignatureUser.HasKey(x => x.AsignatureUserId);
                asignatureUser.Property(x => x.AsignatureId);
                asignatureUser.Property(x => x.UserId);
                //asignatureUser.HasOne(x => x.User)
                //    .WithMany(u => u.AsignatureUsers)
                //    .HasForeignKey(x => x.UserId);
                //asignatureUser.HasOne(x => x.Asignature)
                //    .WithMany(a => a.AsignatureUsers)
                //    .HasForeignKey(x => x.AsignatureId);
            });

        }
    }
}
