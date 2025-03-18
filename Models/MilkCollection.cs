using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace milkify.Models
{
    public class MilkCollection
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FarmerName { get; set; } = null!;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CollectionDate { get; set; } = DateTime.Now; 

        [Required]
        [Range(0.1, 1000, ErrorMessage = "Milk quantity must be between 0.1 and 1000 liters.")]
        public double Quantity { get; set; } 

      
        [Required]
        [Range(10, 100, ErrorMessage = "Rate must be between ₹10 and ₹100 per liter.")]
        public double RatePerLiter { get; set; } 

        [NotMapped]
        public double TotalPrice => Quantity * RatePerLiter; 

        [Required]
        public string MilkType { get; set; } = null!;

        public string Status { get; set; } = null!;

    }
}
