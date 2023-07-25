using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo_Project.Model
{
    public class Note
    {
        
        private String title;
        private String description;
        private int id;

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get => title; set => title = value; }

        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Description { get => description; set => description = value; }
        public int Id { get => id; set => id = value; }
    }
}