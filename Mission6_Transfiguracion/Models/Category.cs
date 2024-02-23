using System.ComponentModel.DataAnnotations;

namespace Mission6_Transfiguracion.Models
{
    public class Category //Creates model of what each record in Categories table should have
    {
        [Key]
        [Required]
        public int CategoryId { get; set; } 
        public string? CategoryName { get; set; }
    }
}
