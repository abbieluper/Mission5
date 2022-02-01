// Model for Movies's Database

using System;
using System.ComponentModel.DataAnnotations;

namespace Mission5.Models
{
    public class MovieModel
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        // Build Foreign Key Relationship
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; } // pairing it with instance of that type 

        [Required]
        public string Title { get; set; }

        [Required]
        public string Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        //The fields below are optional
        public bool Edited { get; set; }

        public string Lent { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }
    }
}


