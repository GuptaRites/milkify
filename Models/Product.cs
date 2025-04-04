﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace milkify.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Column("ImagePath", TypeName = "varchar(100)")]
        public string ImagePath { get; set; } = null!;

        [Column("Type", TypeName = "varchar(30)")]
        public string Type { get; set; } = null!;

        [Column("Title", TypeName = "varchar(200)")]
        public string Title { get; set; } = null!;

        [Column("Price", TypeName = "int")]
        public int Price { get; set; }

        [Column("Desc", TypeName = "varchar(500)")]
        public string Desc { get; set; } = null!;
    }
}
