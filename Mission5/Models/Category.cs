﻿// Model for movie categories

using System;
using System.ComponentModel.DataAnnotations;

namespace Mission5.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}