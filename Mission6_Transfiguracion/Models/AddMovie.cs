using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Transfiguracion.Models
{
    public class AddMovie //Creates model of what each record in AddMovie table should have 
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [ForeignKey("Category")] //Links to Cateogry.cs
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        [Required]
        public string Title { get; set; } = " ";
        
        [Required(ErrorMessage = "Required my dude")]
        [Range(1888, int.MaxValue)]
        public int Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        [Required]
        public bool Edited { get; set; }
        public string? LentTo { get; set; }
        [Required]
        public bool CopiedToPlex { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}
