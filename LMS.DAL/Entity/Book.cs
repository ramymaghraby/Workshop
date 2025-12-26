using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.DAL.Entity
{
    [Table("Books")]
    public class Book : BaseEntity
    {
        [Column("BookTitle"),StringLength(50)]
        public string Title { get; set; } = "";
        [Column("BookAuthor"), StringLength(80)]
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
