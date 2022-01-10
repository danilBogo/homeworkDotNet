using DatabaseBusinessLogic.Interfaces;

namespace DatabaseBusinessLogic.Models
{
    public class MonsterModel : ICreature
    {
        public string Name { get; set; }

        public int HitPoints { get; set; }

        public int AttackModifier { get; set; }
        
        public int DamageModifier { get; set; }
        
        public string Damage { get; set; }
        
        public int ArmorClass { get; set; }
        
        public int NumberAttacksPerRound { get; set; }
    }
}