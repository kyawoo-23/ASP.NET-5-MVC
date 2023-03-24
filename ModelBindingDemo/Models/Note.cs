using System;
using System.Collections.Generic;

namespace ModelBindingDemo.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }
    }
}
