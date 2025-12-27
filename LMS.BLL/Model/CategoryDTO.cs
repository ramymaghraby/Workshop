using LMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.BLL.Model
{
    public class CategoryDTO : BaseEntityDTO
    {
        
        [StringLength(50, ErrorMessage ="Max length is 50")]
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; } = "";
        [StringLength(150, ErrorMessage ="Max length is 150")]
        [Required(ErrorMessage ="Description is required")]
        public string Description { get; set; } = "";
    }
}
