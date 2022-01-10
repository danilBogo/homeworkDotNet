using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Exam.Database.Interfaces;

namespace UserInterface.Models.Index
{
    public class IndexFormViewModel : ICreature
    {
        [Required] 
        [DisplayName("Имя")] 
        public string Name { get; set; }

        [Required] 
        [DisplayName("Хит-поинты")] 
        public int HitPoints { get; set; }
        
        [Required] 
        [DisplayName("Модификатор атаки")] 
        public int AttackModifier { get; set; }
        
        [Required] 
        [DisplayName("Модификатор урона")] 
        public int DamageModifier { get; set; }
        
        [Required]
        [DisplayName("Урон")] 
        public string Damage { get; set; }
        
        [Required] 
        [DisplayName("Класс брони")] 
        public int ArmorClass { get; set; }
        
        [Required] 
        [DisplayName("Количество атак за раунд")] 
        public int NumberAttacksPerRound { get; set; }
    }
}