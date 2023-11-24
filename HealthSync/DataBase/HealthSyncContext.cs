using HealthSync.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthSync.DataBase
{
    public class HealthSyncContext : DbContext
    {
        public DbSet<Medic> Medics { get; set; }
        public DbSet<Trainner> Trainners { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<InfoUser> InfoUsers { get; set; }
        public DbSet<InfoMenu> InfosMenus { get; set; }
        public DbSet<InfoTrainner> InfosTrainners { get; set; }

        public HealthSyncContext(DbContextOptions op) : base(op)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configura a chave composta da tabela associativa
            modelBuilder.Entity<InfoMenu>()
                .HasKey(me => new { me.MenuId, me.InfoUserId });

            //Configura a relação da tabela associativa com o ator
            modelBuilder.Entity<InfoMenu>()
                .HasOne(m => m.Menu)
                .WithMany(m => m.InfosMenus)
                .HasForeignKey(m => m.MenuId)
                .OnDelete(DeleteBehavior.NoAction);

            //Configura a relação da tabela associativa com o filme
            modelBuilder.Entity<InfoMenu>()
               .HasOne(i => i.InfoUser)
               .WithMany(i => i.InfosMenus)
               .HasForeignKey(i => i.InfoUserId)
               .OnDelete(DeleteBehavior.NoAction);

            //Configura a chave composta da tabela associativa
            modelBuilder.Entity<InfoTrainner>()
                .HasKey(me => new { me.TrainnerId, me.InfoUserId });

            //Configura a relação da tabela associativa com o ator
            modelBuilder.Entity<InfoTrainner>()
                .HasOne(m => m.Trainner)
                .WithMany(m => m.InfosTrainners)
                .HasForeignKey(m => m.TrainnerId)
                .OnDelete(DeleteBehavior.NoAction);

            //Configura a relação da tabela associativa com o filme
            modelBuilder.Entity<InfoTrainner>()
               .HasOne(i => i.InfoUser)
               .WithMany(i => i.InfosTrainners)
               .HasForeignKey(i => i.InfoUserId)
               .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
