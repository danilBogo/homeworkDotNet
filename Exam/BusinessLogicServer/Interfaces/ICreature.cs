namespace DatabaseBusinessLogic.Interfaces
{
    public interface ICreature
    {
        string Name { get; set; }
        
        int HitPoints { get; set; }
        
        int AttackModifier { get; set; }
        
        int DamageModifier { get; set; }
        
        string Damage { get; set; }
        
        int ArmorClass { get; set; }
        
        int NumberAttacksPerRound { get; set; }
    }
}