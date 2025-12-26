using LMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.BLL.Model
{
    public class BookDTO : BaseEntityDTO
    {
        [StringLength(50, ErrorMessage ="Max Length 50")]
        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; } = "";
        [StringLength(80, ErrorMessage ="Max length 80")]
        [Required(ErrorMessage ="Author is required")]
        public string Author { get; set; } = "";
        [StringLength(13)]
        public string ISBN { get; set; } = "";
        public int PublishedYear { get; set; }
        public int Rate { get; set; }
        public int CategoryId { get; set; }


        // Navigation Property
        public Category Category { get; set; } = new Category();
        public bool IsAvailable { get; set; }
    }
}
