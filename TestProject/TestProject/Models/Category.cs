﻿using System.ComponentModel.DataAnnotations;

namespace TestProject.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int price { get; set; }
    }
}
