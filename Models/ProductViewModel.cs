using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace milkify.Models
{
    public class ProductViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Type", TypeName = "char")]
        public string Type { get; set; } = null!;

        [Required]
        [Column("Title", TypeName = "char")]
        public string Title { get; set; } = null!;


        [Required]
        [Column("Price", TypeName = "int")]
        public int Price { get; set; }

        [Required]
        [Column("Desc", TypeName = "char")]
        public string Desc { get; set; } = null!;

        [Required]
        [Column("ImagePath", TypeName = "char")]
        public IFormFile photo { get; set; } = null!;
    }
}
