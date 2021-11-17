using System.ComponentModel.DataAnnotations;
using Homework7.HtmlServices;

namespace Homework7.Models
{
    public class UserProfile
    {
        [Required(ErrorMessage = "Поле является обязательным")]
        [MaxLength(30, ErrorMessage = "Максимальная длина 30 символов")]
        [Display(Name = "Фамилия")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Поле является обязательным")]
        [MaxLength(30, ErrorMessage = "Максимальная длина 30 символов")]
        [Display(Name = "Имя")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Поле является обязательным")]
        [MaxLength(30, ErrorMessage = "Максимальная длина 30 символов")]
        [Display(Name = "Отчество")]
        public string? Patronymic { get; set; }
        
        [Required(ErrorMessage = "Поле является обязательным")]
        [Display(Name = "Пол")]
        public Sex Sex { get; set; }
        
        [Required(ErrorMessage = "Поле является обязательным")]
        [Range(18, 100, ErrorMessage = "Вы слишком молодой или старый")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }
    }
}