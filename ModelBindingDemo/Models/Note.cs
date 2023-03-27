using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelBindingDemo.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public int DeveloperId { get; set; }

        public Developer Developer { get; set; }
    }
}
