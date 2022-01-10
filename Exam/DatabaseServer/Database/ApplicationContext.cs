using Exam.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<MonsterModel> Monsters { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MonsterModel>().HasData(new MonsterModel
            {
                MonsterId = 1,
                Name = "Дворянин",
                HitPoints = 9,
                AttackModifier = 3,
                DamageModifier = 1,
                Damage = "1k8",
                ArmorClass = 15,
                NumberAttacksPerRound = 1
            });
            modelBuilder.Entity<MonsterModel>().HasData(new MonsterModel
            {
                MonsterId = 2,
                Name = "Аллозавр",
                HitPoints = 51,
                AttackModifier = 6,
                DamageModifier = 4,
                Damage = "2k10",
                ArmorClass = 13,
                NumberAttacksPerRound = 1
            });
            modelBuilder.Entity<MonsterModel>().HasData(new MonsterModel
            {
                MonsterId = 3,
                Name = "Древний облекс",
                HitPoints = 115,
                AttackModifier = 7,
                DamageModifier = 3,
                Damage = "4k6",
                ArmorClass = 16,
                NumberAttacksPerRound = 2
            });
        }
    }
}