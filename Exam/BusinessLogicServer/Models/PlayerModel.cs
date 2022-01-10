using System.ComponentModel.DataAnnotations;
using DatabaseBusinessLogic.Interfaces;

namespace DatabaseBusinessLogic.Models
{
    public class PlayerModel : ICreature
    {
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