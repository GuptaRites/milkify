using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace milkify.Models
{
    public class UserRegister
    {
        [Key]
        public int Id { get; set; }

        [Column("User", TypeName ="char")]
        public string name { get; set; }

        [Column("EmailId", TypeName = "char")]
        public string email { get; set; }

        [Column("Password", TypeName = "char")]
        public string password { get; set; }
        

    }
}
