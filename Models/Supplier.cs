using System.ComponentModel.DataAnnotations;

namespace milkify.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Supplier name cannot exceed 100 characters.")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        public string Address { get; set; } = null!;

        [Required]
        [Phone]
        public string ContactNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [DataType(DataType.Date)]
        public DateTime RegisteredDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Active";
    }
}
