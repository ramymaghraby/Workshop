using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.DAL.Entity
{
    [Table("Categories")]
    public class Category : BaseEntity
    {
        [Column("CategoryName", TypeName = "NVARCHAR(50)")]
        public string Name { get; set; } = "";
        [Column("CategoryDescription", TypeName = "NVARCHAR(150)")]
        public string Description { get; set; } = "";
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
