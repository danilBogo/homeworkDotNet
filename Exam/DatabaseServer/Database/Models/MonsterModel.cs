using System.ComponentModel.DataAnnotations;
using Exam.Database.Interfaces;

namespace Exam.Database.Models
{
    public class MonsterModel : ICreature
    {
        [Key]
        public int MonsterId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int HitPoints { get; set; }

        [Required]
        public int AttackModifier { get; set; }
        
        [Required]
        public int DamageModifier { get; set; }
        
        [Required]
        public string Damage { get; set; }
        
        [Required]
        public int ArmorClass { get; set; }
        
        [Required]
        public int NumberAttacksPerRound { get; set; }
    }
}