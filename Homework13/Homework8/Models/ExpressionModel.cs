using System.ComponentModel.DataAnnotations;

namespace Homework8.Models
{
    public class ExpressionModel
    {
        [Key]
        public int ExpressionId { get; set; }
        
        public string ExpressionValue { get; set; }
        
        public string ExpressionResult { get; set; } 
    }
}