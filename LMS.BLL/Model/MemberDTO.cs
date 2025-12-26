using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.BLL.Model
{
    public class MemberDTO : BaseEntityDTO
    {
        [StringLength(50, ErrorMessage ="Max length is 50")]
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; } = "";
        [Required(ErrorMessage ="Email is required")]
        public string Email { get; set; } = "";
        [StringLength(14, ErrorMessage ="Max 14 Digits")]
        [Required(ErrorMessage ="Phone is required")]
        public string Phone { get; set; } = "";
        public DateTime MembershipDate { get; set; }
    }
}
